namespace appMail
{
    partial class inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btn = new Button();
            label1 = new Label();
            btnSave = new Button();
            btnExclude = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 152);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 254);
            dataGridView1.TabIndex = 0;
            // 
            // btn
            // 
            btn.Location = new Point(713, 123);
            btn.Name = "btn";
            btn.Size = new Size(75, 23);
            btn.TabIndex = 1;
            btn.Text = "button1";
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 134);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(278, 412);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 35);
            btnSave.TabIndex = 3;
            btnSave.Text = "button1";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExclude
            // 
            btnExclude.Location = new Point(413, 412);
            btnExclude.Name = "btnExclude";
            btnExclude.Size = new Size(129, 35);
            btnExclude.TabIndex = 5;
            btnExclude.Text = "button2";
            btnExclude.UseVisualStyleBackColor = true;
            btnExclude.Click += btnExclude_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(632, 123);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "button1";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(810, 459);
            Controls.Add(btnAdd);
            Controls.Add(btnExclude);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(btn);
            Controls.Add(dataGridView1);
            Name = "inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "inicio";
            Load += inicio_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn;
        private Label label1;
        private Button btnSave;
        private Button btnExclude;
        private Button btnAdd;
    }
}