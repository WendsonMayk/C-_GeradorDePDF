using appMail.core.classes;
using Newtonsoft.Json;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using appMail.forms;
using DotNetEnv;

namespace appMail
{
    public partial class inicio : Form
    {
        public inicio()
        {
            InitializeComponent();
            CarregarColunasDataGridView();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            //Configuration 
            label1.Text = "generator pdf v1.0";


            //Buttons texts
            btn.Text = "Gerar PDF";
            btnSave.Text = "Salvar";
            btnExclude.Text = "Excluir";
            btnAdd.Text = "adicionar";
            btnEmail.Text = "Enviar Email";


            //Configuration buttons Colors
            btn.BackColor = System.Drawing.Color.Orange;
            btnSave.BackColor = System.Drawing.Color.Green;
            btnExclude.BackColor = System.Drawing.Color.Red;


            //Configuration buttons Cursors
            btn.Cursor = Cursors.Hand;
            btnSave.Cursor = Cursors.Hand;
            btnExclude.Cursor = Cursors.Hand;


            //Configuration buttons ForeColor
            btnSave.ForeColor = System.Drawing.Color.White;
            btnExclude.ForeColor = System.Drawing.Color.White;
        }

        //Aqui insira o caminho do arquivo json
        private string path()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string relativePath = Path.Combine(projectDirectory, @"core\database\database.json");
            FileInfo filepath = new FileInfo(relativePath);

            return filepath.ToString();
        }

        private string imagePath()
        {
            // Obt�m o diret�rio bin\Debug ou bin\Release
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Sobe para a pasta do projeto a partir do bin\Debug ou bin\Release
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            // Constr�i o caminho para o arquivo
            string relativePath = Path.Combine(projectDirectory, @"core\imagens\logo.png");
            // Cria o FileInfo com o caminho final
            FileInfo filepath = new FileInfo(relativePath);

            return filepath.ToString();
        }

        private string pdfPath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string relativePath = Path.Combine(projectDirectory, @"core\archieve-pdf\relatorio.pdf");
            FileInfo filepath = new FileInfo(relativePath);

            return filepath.ToString();
        }

        private void startEnvoriment()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string relativePath = Path.Combine(projectDirectory, @"core\.env");
            
            // Carrega o arquivo .env usando o caminho especificado
            Env.Load(relativePath);
        }


        private void CarregarColunasDataGridView()
        {
            //Desabilita a op��o de inserir dados no datagridview
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Idade", "Idade");
            dataGridView1.Columns.Add("Endereco", "Endere�o");
            dataGridView1.Columns.Add("Cargo", "Cargo");
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Aprovado",
                HeaderText = "Aprovado",
                TrueValue = true,
                FalseValue = false
            };

            dataGridView1.Columns.Add(checkBoxColumn);

            // Tornar algumas colunas somente leitura
            dataGridView1.Columns["Nome"].ReadOnly = false;      // Coluna Nome readonly
            dataGridView1.Columns["Idade"].ReadOnly = false;     // Coluna Idade readonly
            dataGridView1.Columns["Endereco"].ReadOnly = false; // Coluna Endere�o edit�vel
            dataGridView1.Columns["Cargo"].ReadOnly = false;     // Coluna Cargo readonly
            dataGridView1.Columns["Aprovado"].ReadOnly = false; // Coluna Aprovado edit�vel
        }

        private void inicio_Load(object sender, EventArgs e)
        {
            try
            {
                // Ler o conte�do do arquivo
                string json = File.ReadAllText(path());

                // Desserializar o JSON para uma lista de objetos Pessoa
                List<Pessoas> pessoas = JsonConvert.DeserializeObject<List<Pessoas>>(json);


                foreach (var pessoa in pessoas)
                {
                    dataGridView1.Rows.Add(pessoa.nome, pessoa.idade, pessoa.endereco, pessoa.cargo, pessoa.aprovado);
                }
                //// Definir a lista como fonte de dados do DataGridView
                //dataGridView1.DataSource = pessoas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(path()))
                {
                    MessageBox.Show("Arquivo JSON n�o encontrando, confira o m�todo path()");
                    return;
                }

                string json = File.ReadAllText(path());
                // Desserializar o JSON para uma lista de objetos Pessoa
                List<Pessoas> pessoas = JsonConvert.DeserializeObject<List<Pessoas>>(json);


                using (PdfWriter writer = new PdfWriter(pdfPath()))
                {
                    using (PdfDocument pdfDoc = new PdfDocument(writer))
                    {
                        Document documento = new Document(pdfDoc);

                        // Adicionar t�tulo ao PDF
                        Paragraph title = new Paragraph("Relat�rio Processo Seletivo")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20);
                        documento.Add(title);


                        iText.Layout.Element.Image headerImage = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imagePath()))
                            .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                            .SetWidth(200); // Altere para o valor desejado, ou utilize GetWidth() para ajust�-lo

                        documento.Add(headerImage);



                        // Adicionar uma tabela
                        Table table = new Table(5); // 5 colunas: Nome, Idade, Endere�o, Cargo, Aprovado

                        // Adicionar cabe�alhos da tabela
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Nome")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Idade")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Endere�o")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Cargo")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Aprovado")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));

                        // Adicionar dados da lista de pessoas
                        foreach (var pessoa in pessoas)
                        {
                            table.AddCell(pessoa.nome);
                            table.AddCell(pessoa.idade.ToString());
                            table.AddCell(pessoa.endereco);
                            table.AddCell(pessoa.cargo);
                            table.AddCell(pessoa.aprovado ? "Sim" : "N�o");
                        }

                        // Adicionar a tabela ao documento
                        documento.Add(table);
                    }
                }
                // Exibir mensagem de sucesso
                MessageBox.Show("PDF gerado com sucesso FINALMENTE!! VIADINHO");
            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pessoas> pessoas = new List<Pessoas>();

                // Percorrer as linhas do DataGridView e coletar os dados
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Ignorar linhas vazias
                    if (row.IsNewRow) continue;

                    var pessoa = new Pessoas
                    {
                        nome = row.Cells["Nome"].Value.ToString(),
                        idade = Convert.ToInt32(row.Cells["Idade"].Value),
                        endereco = row.Cells["Endereco"].Value.ToString(),
                        cargo = row.Cells["Cargo"].Value.ToString(),
                        aprovado = Convert.ToBoolean(row.Cells["Aprovado"].Value)
                    };

                    pessoas.Add(pessoa);
                }

                // Serializar a lista de pessoas em JSON
                string json = JsonConvert.SerializeObject(pessoas, Formatting.Indented);


                File.WriteAllText(path(), json);

                // Exibir mensagem de sucesso
                MessageBox.Show("Dados salvos com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message);
            }
        }

        private void btnExclude_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja continuar?", "Confirma��o", MessageBoxButtons.YesNo);
            if (resultado != DialogResult.Yes)
            {
                MessageBox.Show("A��o cancelada");
            }
            else
            {

                try
                {
                    // Verificar se alguma linha est� selecionada no DataGridView
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Obter a linha selecionada
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        string nomeParaExcluir = selectedRow.Cells["Nome"].Value.ToString();

                        if (File.Exists(path()))
                        {
                            string json = File.ReadAllText(path());
                            List<Pessoas> pessoas = JsonConvert.DeserializeObject<List<Pessoas>>(json);
                            pessoas = pessoas.Where(p => p.nome != nomeParaExcluir).ToList();
                            string jsonAtualizado = JsonConvert.SerializeObject(pessoas, Formatting.Indented);
                            File.WriteAllText(path(), jsonAtualizado);
                            dataGridView1.Rows.Remove(selectedRow);
                            MessageBox.Show("Pessoa removida com sucesso.");
                        }
                        else
                        {
                            MessageBox.Show("Arquivo JSON n�o encontrado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecione uma linha para excluir.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir a pessoa: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addPessoas addPessoas = new addPessoas();

            addPessoas.OnPessoaAdded += LoadData;   // Assine o evento para carregar os dados quando uma nova pessoa for adicionada

            addPessoas.ShowDialog();
        }


        public string getPath()
        {
            return this.path();
        }


        public void LoadData()
        {
            dataGridView1.Rows.Clear(); // Limpa as linhas atuais antes de carregar os dados

            try
            {
                // Ler o conte�do do arquivo
                string json = File.ReadAllText(path());

                // Desserializar o JSON para uma lista de objetos Pessoa
                List<Pessoas> pessoas = JsonConvert.DeserializeObject<List<Pessoas>>(json);

                // Adicionar os dados ao DataGridView
                foreach (var pessoa in pessoas)
                {
                    dataGridView1.Rows.Add(pessoa.nome, pessoa.idade, pessoa.endereco, pessoa.cargo, pessoa.aprovado); ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            startEnvoriment();
            
            var email = Environment.GetEnvironmentVariable("EMAIL_USER");
            var password = Environment.GetEnvironmentVariable("PASSWORD_USER");
            var smtp = Environment.GetEnvironmentVariable("SMTP_USER");

            Email mail = new Email(smtp, email, password);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = true;


            try
            {
                // Executa o envio de e-mail em uma tarefa separada
                await Task.Run(() =>
                {
                    // C�digo de envio de e-mail
                    mail.sendEmail(new List<string> { "jacileny.lima.1@gmail.com" },
                        subject: "PROCESSO SELETIVO",
                        body: "Segue em anexo o edital dos candidatos aprovados no processo seletivo",
                        attachments: new List<string> { pdfPath() });
                });

                // Quando o e-mail for enviado com sucesso
                MessageBox.Show("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                // Se houver erro
                MessageBox.Show($"Erro ao enviar o e-mail: {ex.Message}");
            }
            finally
            {
                // Ao final, independente de sucesso ou falha
                progressBar.Visible = false;  // Esconde o ProgressBar
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

       
  
        }
    }
}