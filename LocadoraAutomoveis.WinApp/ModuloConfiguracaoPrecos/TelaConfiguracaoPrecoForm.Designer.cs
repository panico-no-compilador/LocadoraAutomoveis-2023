namespace LocadoraAutomoveis.WinApp.ModuloConfiguracaoPrecos
{
    partial class TelaConfiguracaoPrecoForm
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
            btnGravar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtGasPreco = new NumericUpDown();
            txtDieselPreco = new NumericUpDown();
            txtEtanolPreco = new NumericUpDown();
            txtGasolinaPreco = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)txtGasPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDieselPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEtanolPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGasolinaPreco).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 58);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 0;
            label2.Text = "Gasolina:";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(182, 289);
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
            btnCancelar.Location = new Point(263, 289);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 107);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 5;
            label1.Text = "Gás:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 150);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 6;
            label3.Text = "Diesel:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 193);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 7;
            label4.Text = "Etanol:";
            // 
            // txtGasPreco
            // 
            txtGasPreco.DecimalPlaces = 2;
            txtGasPreco.Location = new Point(85, 101);
            txtGasPreco.Name = "txtGasPreco";
            txtGasPreco.Size = new Size(253, 23);
            txtGasPreco.TabIndex = 8;
            txtGasPreco.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDieselPreco
            // 
            txtDieselPreco.DecimalPlaces = 2;
            txtDieselPreco.Location = new Point(85, 146);
            txtDieselPreco.Name = "txtDieselPreco";
            txtDieselPreco.Size = new Size(253, 23);
            txtDieselPreco.TabIndex = 9;
            txtDieselPreco.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEtanolPreco
            // 
            txtEtanolPreco.DecimalPlaces = 2;
            txtEtanolPreco.Location = new Point(85, 191);
            txtEtanolPreco.Name = "txtEtanolPreco";
            txtEtanolPreco.Size = new Size(253, 23);
            txtEtanolPreco.TabIndex = 10;
            txtEtanolPreco.TextAlign = HorizontalAlignment.Center;
            // 
            // txtGasolinaPreco
            // 
            txtGasolinaPreco.DecimalPlaces = 2;
            txtGasolinaPreco.Location = new Point(85, 56);
            txtGasolinaPreco.Name = "txtGasolinaPreco";
            txtGasolinaPreco.Size = new Size(253, 23);
            txtGasolinaPreco.TabIndex = 11;
            txtGasolinaPreco.TextAlign = HorizontalAlignment.Center;
            // 
            // TelaConfiguracaoPrecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 346);
            Controls.Add(txtGasolinaPreco);
            Controls.Add(txtEtanolPreco);
            Controls.Add(txtDieselPreco);
            Controls.Add(txtGasPreco);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label2);
            Name = "TelaConfiguracaoPrecoForm";
            Text = "Cadastro de Preço de Combustivel";
            ((System.ComponentModel.ISupportInitialize)txtGasPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDieselPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEtanolPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGasolinaPreco).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private Label label1;
        private Label label3;
        private Label label4;
        private NumericUpDown txtGasPreco;
        private NumericUpDown txtDieselPreco;
        private NumericUpDown txtEtanolPreco;
        private NumericUpDown txtGasolinaPreco;
    }
}