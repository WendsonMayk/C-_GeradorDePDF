using appMail.core.classes;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cms;
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

            //Configurations buttons names
            lblName.Text = "Nome";
            lblEndereco.Text = "Endereço";
            lblAge.Text = "Idade";
            lblAproved.Text = "Aprovado";
            chkAproved.Text = "sim";
            lblcomercial.Text = "By: Wendson Magalhães";
            btnSave.Text = "Salvar";
            btnCancel.Text = "Cancelar";
            lblCargo.Text = "Cargo";

            //Configurations about the form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            //Configuration tabindex 
            txtNome.TabIndex = 0;
            txtIdade.TabIndex = 1;
            txtEndereco.TabIndex = 2;
            txtCargo.TabIndex = 3;
            chkAproved.TabIndex = 4;



        }

        inicio inicio = new inicio();
        public event Action OnPessoaAdded;

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pessoas> pessoas;

                if (File.Exists(inicio.getPath()))
                {
                    string jsonAntigo = File.ReadAllText(inicio.getPath());
                    pessoas = JsonConvert.DeserializeObject<List<Pessoas>>(jsonAntigo) ?? new List<Pessoas>();
                }
                else
                {
                    pessoas = new List<Pessoas>();
                }

                var novaPessoa = new Pessoas
                {
                    nome = txtNome.Text,
                    idade = Convert.ToInt32(txtIdade.Value),
                    endereco = txtEndereco.Text,
                    cargo = txtCargo.Text,
                    aprovado = chkAproved.Checked ? true : false,

                };


                pessoas.Add(novaPessoa);

                string jsonAtualizado = JsonConvert.SerializeObject(pessoas, Formatting.Indented);

                File.WriteAllText(inicio.getPath(), jsonAtualizado);

                MessageBox.Show("Candidato inserido com sucesso");
                cleanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message);
            }
        }

        private void cleanData()
        {
            txtNome.Text = string.Empty;
            txtIdade.Value = 18;
            txtCargo.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            chkAproved.Checked = false;
        }

        private void addPessoas_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnPessoaAdded?.Invoke();
        }

        private void lblcomercial_Click(object sender, EventArgs e)
        {

        }
    }
}


