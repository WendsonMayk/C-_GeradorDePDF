namespace appMail.forms
{
    partial class addPessoas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            lblAge = new Label();
            lblEndereco = new Label();
            lblAproved = new Label();
            txtNome = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtEndereco = new TextBox();
            chkAproved = new CheckBox();
            lblcomercial = new Label();
            txtIdade = new NumericUpDown();
            lblCargo = new Label();
            txtCargo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)txtIdade).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(27, 75);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(27, 116);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(38, 15);
            lblAge.TabIndex = 1;
            lblAge.Text = "label2";
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(12, 155);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(38, 15);
            lblEndereco.TabIndex = 2;
            lblEndereco.Text = "label3";
            // 
            // lblAproved
            // 
            lblAproved.AutoSize = true;
            lblAproved.Location = new Point(12, 227);
            lblAproved.Name = "lblAproved";
            lblAproved.Size = new Size(38, 15);
            lblAproved.TabIndex = 3;
            lblAproved.Text = "label4";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(71, 72);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(300, 23);
            txtNome.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(84, 297);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "button1";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(227, 297);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "button2";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(71, 152);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(300, 23);
            txtEndereco.TabIndex = 8;
            // 
            // chkAproved
            // 
            chkAproved.AutoSize = true;
            chkAproved.Location = new Point(71, 226);
            chkAproved.Name = "chkAproved";
            chkAproved.Size = new Size(83, 19);
            chkAproved.TabIndex = 9;
            chkAproved.Text = "checkBox1";
            chkAproved.UseVisualStyleBackColor = true;
            // 
            // lblcomercial
            // 
            lblcomercial.AutoSize = true;
            lblcomercial.Location = new Point(227, 226);
            lblcomercial.Name = "lblcomercial";
            lblcomercial.Size = new Size(38, 15);
            lblcomercial.TabIndex = 10;
            lblcomercial.Text = "label1";
            lblcomercial.Click += lblcomercial_Click;
            // 
            // txtIdade
            // 
            txtIdade.Location = new Point(71, 114);
            txtIdade.Name = "txtIdade";
            txtIdade.Size = new Size(300, 23);
            txtIdade.TabIndex = 11;
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Location = new Point(27, 193);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(38, 15);
            lblCargo.TabIndex = 12;
            lblCargo.Text = "label2";
            // 
            // txtCargo
            // 
            txtCargo.Location = new Point(71, 190);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(300, 23);
            txtCargo.TabIndex = 13;
            // 
            // addPessoas
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(401, 338);
            Controls.Add(txtCargo);
            Controls.Add(lblCargo);
            Controls.Add(txtIdade);
            Controls.Add(lblcomercial);
            Controls.Add(chkAproved);
            Controls.Add(txtEndereco);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNome);
            Controls.Add(lblAproved);
            Controls.Add(lblEndereco);
            Controls.Add(lblAge);
            Controls.Add(lblName);
            Name = "addPessoas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "addPessoas";
            FormClosing += addPessoas_FormClosing;
            ((System.ComponentModel.ISupportInitialize)txtIdade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblAge;
        private Label lblEndereco;
        private Label lblAproved;
        private TextBox txtNome;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtEndereco;
        private CheckBox chkAproved;
        private Label lblcomercial;
        private NumericUpDown txtIdade;
        private Label lblCargo;
        private TextBox txtCargo;
    }
}