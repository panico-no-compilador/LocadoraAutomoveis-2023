namespace LocadoraAutomoveis.WinApp.ModuloFuncionarios
{
    partial class TabelaFuncionariosControl
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
            tabelaFuncionarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaFuncionarios).BeginInit();
            SuspendLayout();
            // 
            // tabelaFuncionarios
            // 
            tabelaFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaFuncionarios.Dock = DockStyle.Fill;
            tabelaFuncionarios.Location = new Point(0, 0);
            tabelaFuncionarios.Name = "tabelaFuncionarios";
            tabelaFuncionarios.RowTemplate.Height = 25;
            tabelaFuncionarios.Size = new Size(150, 150);
            tabelaFuncionarios.TabIndex = 0;
            // 
            // TabelaFuncionariosControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaFuncionarios);
            Name = "TabelaFuncionariosControl";
            ((System.ComponentModel.ISupportInitialize)tabelaFuncionarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaFuncionarios;
    }
}
