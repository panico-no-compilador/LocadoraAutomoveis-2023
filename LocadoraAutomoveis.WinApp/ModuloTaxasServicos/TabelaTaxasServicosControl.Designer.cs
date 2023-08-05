namespace LocadoraAutomoveis.WinApp.ModuloTaxasServicos
{
    partial class TabelaTaxasServicosControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabelaTaxasServicos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaTaxasServicos).BeginInit();
            SuspendLayout();
            // 
            // tabelaTaxasServicos
            // 
            tabelaTaxasServicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaTaxasServicos.Dock = DockStyle.Fill;
            tabelaTaxasServicos.Location = new Point(0, 0);
            tabelaTaxasServicos.Name = "tabelaTaxasServicos";
            tabelaTaxasServicos.RowTemplate.Height = 25;
            tabelaTaxasServicos.Size = new Size(150, 150);
            tabelaTaxasServicos.TabIndex = 0;
            // 
            // TabelaTaxasServicosControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaTaxasServicos);
            Name = "TabelaTaxasServicosControl";
            ((System.ComponentModel.ISupportInitialize)tabelaTaxasServicos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaTaxasServicos;
    }
}
