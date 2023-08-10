namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    partial class TelaAutomoveisForm
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
            btnGravar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            cmbGrupAutomoveis = new ComboBox();
            label2 = new Label();
            txtModelo = new TextBox();
            label3 = new Label();
            txtMarca = new TextBox();
            label4 = new Label();
            txtCor = new TextBox();
            label5 = new Label();
            cmbTipoCombustivel = new ComboBox();
            label6 = new Label();
            txtCapacidadeCombustivel = new TextBox();
            pictureBox1 = new PictureBox();
            btnBuscarFoto = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label7 = new Label();
            label8 = new Label();
            txtAno = new TextBox();
            label9 = new Label();
            txtPlaca = new TextBox();
            openFile = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(154, 409);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 3;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(235, 409);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 172);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 5;
            label1.Text = "Grupo de Automóveis:";
            // 
            // cmbGrupAutomoveis
            // 
            cmbGrupAutomoveis.FormattingEnabled = true;
            cmbGrupAutomoveis.Location = new Point(152, 169);
            cmbGrupAutomoveis.Name = "cmbGrupAutomoveis";
            cmbGrupAutomoveis.Size = new Size(158, 23);
            cmbGrupAutomoveis.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 210);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 7;
            label2.Text = "Modelo:";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(152, 207);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(158, 23);
            txtModelo.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 248);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 9;
            label3.Text = "Marca:";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(152, 245);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(158, 23);
            txtMarca.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(117, 286);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 11;
            label4.Text = "Cor:";
            // 
            // txtCor
            // 
            txtCor.Location = new Point(152, 283);
            txtCor.Name = "txtCor";
            txtCor.Size = new Size(158, 23);
            txtCor.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 324);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 13;
            label5.Text = "Tipo de Combustível:";
            // 
            // cmbTipoCombustivel
            // 
            cmbTipoCombustivel.FormattingEnabled = true;
            cmbTipoCombustivel.Location = new Point(152, 321);
            cmbTipoCombustivel.Name = "cmbTipoCombustivel";
            cmbTipoCombustivel.Size = new Size(109, 23);
            cmbTipoCombustivel.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 362);
            label6.Name = "label6";
            label6.Size = new Size(124, 15);
            label6.TabIndex = 15;
            label6.Text = "Capacidade em Litros:";
            // 
            // txtCapacidadeCombustivel
            // 
            txtCapacidadeCombustivel.Location = new Point(152, 359);
            txtCapacidadeCombustivel.Name = "txtCapacidadeCombustivel";
            txtCapacidadeCombustivel.Size = new Size(158, 23);
            txtCapacidadeCombustivel.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(152, 12);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // btnBuscarFoto
            // 
            btnBuscarFoto.Location = new Point(235, 39);
            btnBuscarFoto.Name = "btnBuscarFoto";
            btnBuscarFoto.Size = new Size(75, 40);
            btnBuscarFoto.TabIndex = 18;
            btnBuscarFoto.Text = "Buscar Foto";
            btnBuscarFoto.UseVisualStyleBackColor = true;
            btnBuscarFoto.Click += btnBuscarFoto_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(112, 64);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 19;
            label7.Text = "Foto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(116, 134);
            label8.Name = "label8";
            label8.Size = new Size(32, 15);
            label8.TabIndex = 20;
            label8.Text = "Ano:";
            // 
            // txtAno
            // 
            txtAno.Location = new Point(152, 131);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(158, 23);
            txtAno.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(110, 96);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 22;
            label9.Text = "Placa:";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(154, 93);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(107, 23);
            txtPlaca.TabIndex = 23;
            // 
            // openFileDialog1
            // 
            openFile.FileName = "openFileDialog1";
            // 
            // TelaAutomoveisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 470);
            Controls.Add(txtPlaca);
            Controls.Add(label9);
            Controls.Add(txtAno);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnBuscarFoto);
            Controls.Add(pictureBox1);
            Controls.Add(txtCapacidadeCombustivel);
            Controls.Add(label6);
            Controls.Add(cmbTipoCombustivel);
            Controls.Add(label5);
            Controls.Add(txtCor);
            Controls.Add(label4);
            Controls.Add(txtMarca);
            Controls.Add(label3);
            Controls.Add(txtModelo);
            Controls.Add(label2);
            Controls.Add(cmbGrupAutomoveis);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaAutomoveisForm";
            Text = "Cadastro de Automoveis";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private Label label1;
        private ComboBox cmbGrupAutomoveis;
        private Label label2;
        private TextBox txtModelo;
        private Label label3;
        private TextBox txtMarca;
        private Label label4;
        private TextBox txtCor;
        private Label label5;
        private ComboBox cmbTipoCombustivel;
        private Label label6;
        private TextBox txtCapacidadeCombustivel;
        private PictureBox pictureBox1;
        private Button btnBuscarFoto;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label7;
        private Label label8;
        private TextBox txtAno;
        private Label label9;
        private TextBox txtPlaca;
        private OpenFileDialog openFile;
    }
}