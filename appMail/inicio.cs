using appMail.core.classes;
using Newtonsoft.Json;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using appMail.forms;
using DotNetEnv;
using System.Threading.Tasks.Dataflow;

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
            // Obtém o diretório bin\Debug ou bin\Release
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Sobe para a pasta do projeto a partir do bin\Debug ou bin\Release
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            // Constrói o caminho para o arquivo
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
            string relativePath = Path.Combine(projectDirectory, @"core\.envUser");

            // Carrega o arquivo .env usando o caminho especificado
            Env.Load(relativePath);
        }

        //corpo html do email;
        private string htmlBody()
        {
            string body = @"
    <!DOCTYPE html>
    <html lang='pt-BR'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <style>
            body {
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 0;
                background-color: #f4f4f4;
            }
            .header {
                background: black; /* Cabeçalho preto */
                color: #007bff; /* Cor do nome */
                padding: 10px 20px;
                text-align: left;
                display: flex;
                align-items: center;
            }
            .header h1 {
                margin: 0;
                padding-right: 10px; /* Espaçamento entre o texto e o ícone */
            }
            .content {
                padding: 20px;
                color: #333;
            }
            .footer {
                background: #f1f1f1;
                text-align: center;
                padding: 10px 20px;
                font-size: 12px;
            }
            .footer a {
                color: #007bff;
                text-decoration: none;
            }
            .icon {
                font-size: 30px; /* Tamanho do ícone da tag */
                color: purple; /* Cor do ícone da tag */
                margin-left: 5px; /* Espaçamento do ícone em relação ao nome */
            }
        </style>
    </head>
    <body>
        <div class='header'>
            <span class='icon'>&#60;&#47;&#62;</span> 
            <h1>Wendson Magalhães</h1>
        </div>
        <div class='content'>
            <p>Olá candidato! Ansioso para o resultado da seleção?,</p>
            <p>Informamos que o processo seletivo chegou ao fim. Em anexo, você encontrará o edital com os candidatos aprovados.</p>
            <p>Se você tiver alguma dúvida, entre em contato com o suporte.</p>
        </div>
        <div class='footer'>
            <p>Este é um e-mail gerado automaticamente. Não é necessário responder.</p>
            <p>&copy; 2024 Wendson Magalhães </>. Todos os direitos reservados.</p>
        </div>
    </body>
    </html>";

            return body;
        }

        private void CarregarColunasDataGridView()
        {
            //Desabilita a opção de inserir dados no datagridview
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Idade", "Idade");
            dataGridView1.Columns.Add("Endereco", "Endereço");
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
            dataGridView1.Columns["Endereco"].ReadOnly = false; // Coluna Endereço editável
            dataGridView1.Columns["Cargo"].ReadOnly = false;     // Coluna Cargo readonly
            dataGridView1.Columns["Aprovado"].ReadOnly = false; // Coluna Aprovado editável
        }

        private void inicio_Load(object sender, EventArgs e)
        {
            try
            {
                // Ler o conteúdo do arquivo
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
                    MessageBox.Show("Arquivo JSON não encontrando, confira o método path()");
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

                        // Adicionar título ao PDF
                        Paragraph title = new Paragraph("Relatório Processo Seletivo")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20);
                        documento.Add(title);


                        iText.Layout.Element.Image headerImage = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imagePath()))
                            .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                            .SetWidth(200); // Altere para o valor desejado, ou utilize GetWidth() para ajustá-lo

                        documento.Add(headerImage);



                        // Adicionar uma tabela
                        Table table = new Table(5); // 5 colunas: Nome, Idade, Endereço, Cargo, Aprovado

                        // Adicionar cabeçalhos da tabela
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Nome")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Idade")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Endereço")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Cargo")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Aprovado")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));

                        // Adicionar dados da lista de pessoas
                        foreach (var pessoa in pessoas)
                        {
                            table.AddCell(pessoa.nome);
                            table.AddCell(pessoa.idade.ToString());
                            table.AddCell(pessoa.endereco);
                            table.AddCell(pessoa.cargo);
                            table.AddCell(pessoa.aprovado ? "Sim" : "Não");
                        }

                        // Adicionar a tabela ao documento
                        documento.Add(table);
                    }
                }
                // Exibir mensagem de sucesso
                MessageBox.Show("PDF GERADO COM SUCESSO!");
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
            DialogResult resultado = MessageBox.Show("Deseja continuar?", "Confirmação", MessageBoxButtons.YesNo);
            if (resultado != DialogResult.Yes)
            {
                MessageBox.Show("Ação cancelada");
            }
            else
            {

                try
                {
                    // Verificar se alguma linha está selecionada no DataGridView
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
                            MessageBox.Show("Arquivo JSON não encontrado.");
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
                // Ler o conteúdo do arquivo
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
                    // Código de envio de e-mail
                    mail.sendEmail(new List<string> { "jacileny.lima1@gmail.com" }, //Adicione o email ou os e-mails para quem vc quer enviar
                        subject: "PROCESSO SELETIVO",
                        body: htmlBody(),
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

    }
}