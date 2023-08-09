namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    partial class TelaCupomForm
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
            lbl3 = new Label();
            label4 = new Label();
            txtNome = new TextBox();
            CboxParceiro = new ComboBox();
            BtnGravar = new Button();
            Cancelar = new Button();
            CboxDataValidade = new DateTimePicker();
            TxtValor = new MaskedTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 41);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 80);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Valor :";
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new Point(36, 119);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(84, 15);
            lbl3.TabIndex = 2;
            lbl3.Text = "Data Validade :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 152);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 3;
            label4.Text = "Parceiro :";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(126, 38);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(257, 23);
            txtNome.TabIndex = 4;
            // 
            // CboxParceiro
            // 
            CboxParceiro.FormattingEnabled = true;
            CboxParceiro.Location = new Point(126, 152);
            CboxParceiro.Name = "CboxParceiro";
            CboxParceiro.Size = new Size(164, 23);
            CboxParceiro.TabIndex = 7;
            // 
            // BtnGravar
            // 
            BtnGravar.DialogResult = DialogResult.OK;
            BtnGravar.Location = new Point(215, 211);
            BtnGravar.Name = "BtnGravar";
            BtnGravar.Size = new Size(75, 37);
            BtnGravar.TabIndex = 8;
            BtnGravar.Text = "Gravar";
            BtnGravar.UseVisualStyleBackColor = true;
            BtnGravar.Click += BtnGravar_Click;
            // 
            // Cancelar
            // 
            Cancelar.DialogResult = DialogResult.Cancel;
            Cancelar.Location = new Point(308, 211);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(75, 37);
            Cancelar.TabIndex = 9;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = true;
            // 
            // CboxDataValidade
            // 
            CboxDataValidade.Format = DateTimePickerFormat.Short;
            CboxDataValidade.Location = new Point(126, 113);
            CboxDataValidade.Name = "CboxDataValidade";
            CboxDataValidade.Size = new Size(100, 23);
            CboxDataValidade.TabIndex = 6;
            CboxDataValidade.Value = new DateTime(2023, 8, 3, 0, 0, 0, 0);
            // 
            // TxtValor
            // 
            TxtValor.Location = new Point(126, 77);
            TxtValor.Name = "TxtValor";
            TxtValor.Size = new Size(100, 23);
            TxtValor.TabIndex = 10;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 260);
            Controls.Add(TxtValor);
            Controls.Add(Cancelar);
            Controls.Add(BtnGravar);
            Controls.Add(CboxParceiro);
            Controls.Add(CboxDataValidade);
            Controls.Add(txtNome);
            Controls.Add(label4);
            Controls.Add(lbl3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaCupomForm";
            Text = "Cadastro De Cupom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lbl3;
        private Label label4;
        private TextBox txtNome;
        private DateTimePicker DateTimePicker;
        private ComboBox CboxParceiro;
        private Button BtnGravar;
        private Button Cancelar;
        private DateTimePicker CboxDataValidade;
        private MaskedTextBox TxtValor;
    }
}