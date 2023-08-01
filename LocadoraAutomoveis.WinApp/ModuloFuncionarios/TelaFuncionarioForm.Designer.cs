namespace LocadoraAutomoveis.WinApp.ModuloFuncionarios
{
    partial class TelaFuncionarioForm
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
            lblNome = new Label();
            lblAdmissao = new Label();
            lblSalario = new Label();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtAdmissao = new DateTimePicker();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(24, 50);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblAdmissao
            // 
            lblAdmissao.AutoSize = true;
            lblAdmissao.Location = new Point(5, 93);
            lblAdmissao.Name = "lblAdmissao";
            lblAdmissao.Size = new Size(62, 15);
            lblAdmissao.TabIndex = 1;
            lblAdmissao.Text = "Admissao:";
            // 
            // lblSalario
            // 
            lblSalario.AutoSize = true;
            lblSalario.Location = new Point(24, 133);
            lblSalario.Name = "lblSalario";
            lblSalario.Size = new Size(45, 15);
            lblSalario.TabIndex = 2;
            lblSalario.Text = "Salario:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(83, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(83, 125);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(120, 23);
            textBox3.TabIndex = 5;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(356, 172);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(437, 172);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtAdmissao
            // 
            txtAdmissao.Format = DateTimePickerFormat.Short;
            txtAdmissao.Location = new Point(83, 87);
            txtAdmissao.Name = "txtAdmissao";
            txtAdmissao.Size = new Size(120, 23);
            txtAdmissao.TabIndex = 10;
            // 
            // TelaFuncionarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 207);
            Controls.Add(txtAdmissao);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(lblSalario);
            Controls.Add(lblAdmissao);
            Controls.Add(lblNome);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaFuncionarioForm";
            ShowIcon = false;
            Text = "Cadastro de Funcionario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblAdmissao;
        private Label lblSalario;
        private TextBox textBox1;
        private TextBox textBox3;
        private Button btnGravar;
        private Button btnCancelar;
        private DateTimePicker txtAdmissao;
    }
}