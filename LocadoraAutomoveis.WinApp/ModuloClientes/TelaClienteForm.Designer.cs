namespace LocadoraAutomoveis.WinApp.ModuloClientes
{
    partial class TelaClienteForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            TxtNome = new TextBox();
            TxtEmail = new TextBox();
            TxtTelefone = new TextBox();
            label10 = new Label();
            label11 = new Label();
            RBTNPessoaFisica = new RadioButton();
            RBTNPessoaJuridica = new RadioButton();
            TxtCpf = new TextBox();
            TxtCnpj = new TextBox();
            TxtCidade = new TextBox();
            TxtEstado = new TextBox();
            BTNGravar = new Button();
            BTNCancelar = new Button();
            label5 = new Label();
            TxtBairro = new TextBox();
            TxtRua = new TextBox();
            TxtNumero = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 38);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 67);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Email :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Telefone :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 135);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 3;
            label4.Text = "Tipo De Cliente :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 184);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 5;
            label6.Text = "CPF :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(188, 184);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 6;
            label7.Text = "CPNJ :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 224);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 7;
            label8.Text = "Estado : ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 268);
            label9.Name = "label9";
            label9.Size = new Size(44, 15);
            label9.TabIndex = 8;
            label9.Text = "Bairro :";
            // 
            // TxtNome
            // 
            TxtNome.Location = new Point(83, 35);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(259, 23);
            TxtNome.TabIndex = 9;
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(83, 64);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(259, 23);
            TxtEmail.TabIndex = 10;
            // 
            // TxtTelefone
            // 
            TxtTelefone.Location = new Point(83, 94);
            TxtTelefone.Name = "TxtTelefone";
            TxtTelefone.Size = new Size(118, 23);
            TxtTelefone.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(188, 229);
            label10.Name = "label10";
            label10.Size = new Size(50, 15);
            label10.TabIndex = 12;
            label10.Text = "Cidade :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(32, 303);
            label11.Name = "label11";
            label11.Size = new Size(33, 15);
            label11.TabIndex = 13;
            label11.Text = "Rua :";
            // 
            // RBTNPessoaFisica
            // 
            RBTNPessoaFisica.AutoSize = true;
            RBTNPessoaFisica.Location = new Point(117, 133);
            RBTNPessoaFisica.Name = "RBTNPessoaFisica";
            RBTNPessoaFisica.Size = new Size(93, 19);
            RBTNPessoaFisica.TabIndex = 14;
            RBTNPessoaFisica.TabStop = true;
            RBTNPessoaFisica.Text = "Pessoa Física";
            RBTNPessoaFisica.UseVisualStyleBackColor = true;
            RBTNPessoaFisica.CheckedChanged += RBTNPessoaFisica_CheckedChanged;
            // 
            // RBTNPessoaJuridica
            // 
            RBTNPessoaJuridica.AutoSize = true;
            RBTNPessoaJuridica.Location = new Point(240, 135);
            RBTNPessoaJuridica.Name = "RBTNPessoaJuridica";
            RBTNPessoaJuridica.Size = new Size(104, 19);
            RBTNPessoaJuridica.TabIndex = 15;
            RBTNPessoaJuridica.TabStop = true;
            RBTNPessoaJuridica.Text = "Pessoa Jurídica";
            RBTNPessoaJuridica.UseVisualStyleBackColor = true;
            RBTNPessoaJuridica.CheckedChanged += RBTNPessoaJuridica_CheckedChanged;
            // 
            // TxtCpf
            // 
            TxtCpf.Location = new Point(69, 181);
            TxtCpf.Name = "TxtCpf";
            TxtCpf.Size = new Size(100, 23);
            TxtCpf.TabIndex = 16;
            // 
            // TxtCnpj
            // 
            TxtCnpj.Location = new Point(240, 181);
            TxtCnpj.Name = "TxtCnpj";
            TxtCnpj.Size = new Size(100, 23);
            TxtCnpj.TabIndex = 17;
            // 
            // TxtCidade
            // 
            TxtCidade.Location = new Point(240, 224);
            TxtCidade.Name = "TxtCidade";
            TxtCidade.Size = new Size(100, 23);
            TxtCidade.TabIndex = 18;
            // 
            // TxtEstado
            // 
            TxtEstado.Location = new Point(69, 221);
            TxtEstado.Name = "TxtEstado";
            TxtEstado.Size = new Size(100, 23);
            TxtEstado.TabIndex = 19;
            // 
            // BTNGravar
            // 
            BTNGravar.DialogResult = DialogResult.OK;
            BTNGravar.Location = new Point(177, 373);
            BTNGravar.Name = "BTNGravar";
            BTNGravar.Size = new Size(75, 37);
            BTNGravar.TabIndex = 20;
            BTNGravar.Text = "Gravar";
            BTNGravar.UseVisualStyleBackColor = true;
            BTNGravar.Click += BTNGravar_Click_1;
            // 
            // BTNCancelar
            // 
            BTNCancelar.DialogResult = DialogResult.Cancel;
            BTNCancelar.Location = new Point(267, 373);
            BTNCancelar.Name = "BTNCancelar";
            BTNCancelar.Size = new Size(75, 37);
            BTNCancelar.TabIndex = 21;
            BTNCancelar.Text = "Cancelar";
            BTNCancelar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 338);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 22;
            label5.Text = "Número :";
            // 
            // TxtBairro
            // 
            TxtBairro.Location = new Point(69, 265);
            TxtBairro.Name = "TxtBairro";
            TxtBairro.Size = new Size(271, 23);
            TxtBairro.TabIndex = 23;
            // 
            // TxtRua
            // 
            TxtRua.Location = new Point(71, 300);
            TxtRua.Name = "TxtRua";
            TxtRua.Size = new Size(271, 23);
            TxtRua.TabIndex = 24;
            // 
            // TxtNumero
            // 
            TxtNumero.Location = new Point(71, 338);
            TxtNumero.Name = "TxtNumero";
            TxtNumero.Size = new Size(47, 23);
            TxtNumero.TabIndex = 25;
            // 
            // TelaClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 419);
            Controls.Add(TxtNumero);
            Controls.Add(TxtRua);
            Controls.Add(TxtBairro);
            Controls.Add(label5);
            Controls.Add(BTNCancelar);
            Controls.Add(BTNGravar);
            Controls.Add(TxtEstado);
            Controls.Add(TxtCidade);
            Controls.Add(TxtCnpj);
            Controls.Add(TxtCpf);
            Controls.Add(RBTNPessoaJuridica);
            Controls.Add(RBTNPessoaFisica);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(TxtTelefone);
            Controls.Add(TxtEmail);
            Controls.Add(TxtNome);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaClienteForm";
            Text = "Cadastro Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox TxtNome;
        private TextBox TxtEmail;
        private TextBox TxtTelefone;
        private Label label10;
        private Label label11;
        private RadioButton RBTNPessoaFisica;
        private RadioButton RBTNPessoaJuridica;
        private TextBox TxtCpf;
        private TextBox TxtCnpj;
        private TextBox TxtCidade;
        private TextBox TxtEstado;
        private Button BTNGravar;
        private Button BTNCancelar;
        private Label label5;
        private TextBox TxtBairro;
        private TextBox TxtRua;
        private TextBox TxtNumero;
    }
}