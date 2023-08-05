namespace LocadoraAutomoveis.WinApp.ModuloTaxasServicos
{
    partial class TelaTaxasServicosForm
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
            label2 = new Label();
            txtNome = new TextBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            gboxPlanoCalculo = new GroupBox();
            rbtnPrecoFixo = new RadioButton();
            rbtnCobrancaDiaria = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            gboxPlanoCalculo.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 58);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 0;
            label2.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(85, 55);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(253, 23);
            txtNome.TabIndex = 2;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(182, 205);
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
            btnCancelar.Location = new Point(263, 205);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 98);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 5;
            label1.Text = "Preço:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(85, 96);
            numericUpDown1.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            // 
            // gboxPlanoCalculo
            // 
            gboxPlanoCalculo.Controls.Add(rbtnCobrancaDiaria);
            gboxPlanoCalculo.Controls.Add(rbtnPrecoFixo);
            gboxPlanoCalculo.Location = new Point(35, 128);
            gboxPlanoCalculo.Name = "gboxPlanoCalculo";
            gboxPlanoCalculo.Size = new Size(303, 71);
            gboxPlanoCalculo.TabIndex = 7;
            gboxPlanoCalculo.TabStop = false;
            gboxPlanoCalculo.Text = "Plano de Calculo";
            // 
            // rbtnPrecoFixo
            // 
            rbtnPrecoFixo.AutoSize = true;
            rbtnPrecoFixo.Location = new Point(19, 32);
            rbtnPrecoFixo.Name = "rbtnPrecoFixo";
            rbtnPrecoFixo.Size = new Size(80, 19);
            rbtnPrecoFixo.TabIndex = 0;
            rbtnPrecoFixo.TabStop = true;
            rbtnPrecoFixo.Text = "Preço Fixo";
            rbtnPrecoFixo.UseVisualStyleBackColor = true;
            // 
            // rbtnCobrancaDiaria
            // 
            rbtnCobrancaDiaria.AutoSize = true;
            rbtnCobrancaDiaria.Location = new Point(128, 32);
            rbtnCobrancaDiaria.Name = "rbtnCobrancaDiaria";
            rbtnCobrancaDiaria.Size = new Size(109, 19);
            rbtnCobrancaDiaria.TabIndex = 1;
            rbtnCobrancaDiaria.TabStop = true;
            rbtnCobrancaDiaria.Text = "Cobrança Diária";
            rbtnCobrancaDiaria.UseVisualStyleBackColor = true;
            // 
            // TelaTaxasServicosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 262);
            Controls.Add(gboxPlanoCalculo);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Name = "TelaTaxasServicosForm";
            Text = "Cadastro de Taxas de Serviços";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            gboxPlanoCalculo.ResumeLayout(false);
            gboxPlanoCalculo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtNome;
        private Button btnGravar;
        private Button btnCancelar;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private GroupBox gboxPlanoCalculo;
        private RadioButton rbtnPrecoFixo;
        private RadioButton rbtnCobrancaDiaria;
    }
}