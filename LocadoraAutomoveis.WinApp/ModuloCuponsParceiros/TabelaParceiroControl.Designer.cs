namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    partial class TabelaParceiroControl
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
            tabelaParceiros = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaParceiros).BeginInit();
            SuspendLayout();
            // 
            // tabelaParceiros
            // 
            tabelaParceiros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaParceiros.Dock = DockStyle.Fill;
            tabelaParceiros.Location = new Point(0, 0);
            tabelaParceiros.Name = "tabelaParceiros";
            tabelaParceiros.RowTemplate.Height = 25;
            tabelaParceiros.Size = new Size(469, 390);
            tabelaParceiros.TabIndex = 0;
            // 
            // TabelaParceiroControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaParceiros);
            Name = "TabelaParceiroControl";
            Size = new Size(469, 390);
            ((System.ComponentModel.ISupportInitialize)tabelaParceiros).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView grid;
        private DataGridView tabelaParceiros;
    }
}
