using appMail.core.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appMail.forms
{
    public partial class addPessoas : Form
    {
        public addPessoas()
        {
            InitializeComponent();

            // Título do Formulário
            this.Text = "Formulário de Cadastro";
            this.Size = new System.Drawing.Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label para Nome
            Label lblNome = new Label { Text = "Nome:", Location = new System.Drawing.Point(20, 20) };
            TextBox txtNome = new TextBox { Location = new System.Drawing.Point(100, 20), Width = 250 };

            // Label para Idade
            Label lblIdade = new Label { Text = "Idade:", Location = new System.Drawing.Point(20, 60) };
            NumericUpDown nudIdade = new NumericUpDown { Location = new System.Drawing.Point(100, 60), Width = 50, Minimum = 0, Maximum = 120 };

            // Label para Endereço
            Label lblEndereco = new Label { Text = "Endereço:", Location = new System.Drawing.Point(20, 100) };
            TextBox txtEndereco = new TextBox { Location = new System.Drawing.Point(100, 100), Width = 250 };

            // Label para Cargo
            Label lblCargo = new Label { Text = "Cargo:", Location = new System.Drawing.Point(20, 140) };
            ComboBox cmbCargo = new ComboBox { Location = new System.Drawing.Point(100, 140), Width = 250 };
            cmbCargo.Items.AddRange(new string[] { "Assistente Administrativo", "Gerente", "Analista", "Desenvolvedor" });

            // Label para Aprovado
            Label lblAprovado = new Label { Text = "Aprovado:", Location = new System.Drawing.Point(20, 180) };
            CheckBox chkAprovado = new CheckBox { Location = new System.Drawing.Point(100, 180) };

            // Botão Salvar
            Button btnSalvar = new Button { Text = "Salvar", Location = new System.Drawing.Point(100, 220) };
            btnSalvar.Click += (s, e) =>
            {
                // Validação dos dados
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Por favor, insira um nome válido.");
                    return;
                }

                if (nudIdade.Value < 0 || nudIdade.Value > 120)
                {
                    MessageBox.Show("Por favor, insira uma idade válida entre 0 e 120.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEndereco.Text))
                {
                    MessageBox.Show("Por favor, insira um endereço válido.");
                    return;
                }

                if (cmbCargo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecione um cargo.");
                    return;
                }

                // Criação do objeto para armazenar os dados
                var pessoa = new Pessoas
                {
                    nome = txtNome.Text,
                    idade = (int)nudIdade.Value,
                    endereco = txtEndereco.Text,
                    cargo = cmbCargo.SelectedItem.ToString(),
                    aprovado = chkAprovado.Checked
                };

                // Salvar em JSON
                List<Pessoas> pessoas;
                string jsonPath = "pessoas.json";

                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    pessoas = JsonConvert.DeserializeObject<List<Pessoas>>(json) ?? new List<Pessoas>();
                }
                else
                {
                    pessoas = new List<Pessoas>();
                }

                pessoas.Add(pessoa);
                string jsonAtualizado = JsonConvert.SerializeObject(pessoas, Formatting.Indented);
                File.WriteAllText(jsonPath, jsonAtualizado);

                // Exibir mensagem de sucesso
                MessageBox.Show("Dados salvos com sucesso!");
                ClearFields(txtNome, nudIdade, txtEndereco, cmbCargo, chkAprovado);
            };

            // Adiciona todos os controles ao Formulário
            this.Controls.Add(lblNome);
            this.Controls.Add(txtNome);
            this.Controls.Add(lblIdade);
            this.Controls.Add(nudIdade);
            this.Controls.Add(lblEndereco);
            this.Controls.Add(txtEndereco);
            this.Controls.Add(lblCargo);
            this.Controls.Add(cmbCargo);
            this.Controls.Add(lblAprovado);
            this.Controls.Add(chkAprovado);
            this.Controls.Add(btnSalvar);
        }


        private void ClearFields(TextBox txtNome, NumericUpDown nudIdade, TextBox txtEndereco, ComboBox cmbCargo, CheckBox chkAprovado)
        {
            // Limpa os campos após salvar
            txtNome.Clear();
            nudIdade.Value = 0;
            txtEndereco.Clear();
            cmbCargo.SelectedIndex = -1;
            chkAprovado.Checked = false;
        }
    }
}
