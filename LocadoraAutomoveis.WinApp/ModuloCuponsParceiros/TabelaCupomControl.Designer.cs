namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    partial class TabelaCupomControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            tabelaCupons = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaCupons).BeginInit();
            SuspendLayout();
            // 
            // TabelaCupons
            // 
            tabelaCupons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaCupons.Dock = DockStyle.Fill;
            tabelaCupons.Location = new Point(0, 0);
            tabelaCupons.Name = "TabelaCupons";
            tabelaCupons.RowTemplate.Height = 25;
            tabelaCupons.Size = new Size(150, 150);
            tabelaCupons.TabIndex = 0;
            
            // 
            // TabelaCupomControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaCupons);
            Name = "TabelaCupomControl";
            ((System.ComponentModel.ISupportInitialize)tabelaCupons).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaCupons;
    }
}
