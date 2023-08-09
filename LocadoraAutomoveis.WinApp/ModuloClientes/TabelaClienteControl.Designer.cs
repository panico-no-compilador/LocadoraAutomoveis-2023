namespace LocadoraAutomoveis.WinApp.ModuloClientes
{
    partial class tabelaCliente
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
            tabelaClientecontrol = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaClientecontrol).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            tabelaClientecontrol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaClientecontrol.Dock = DockStyle.Fill;
            tabelaClientecontrol.Location = new Point(0, 0);
            tabelaClientecontrol.Name = "dataGridView1";
            tabelaClientecontrol.RowTemplate.Height = 25;
            tabelaClientecontrol.Size = new Size(150, 150);
            tabelaClientecontrol.TabIndex = 0;
            // 
            // tabelaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaClientecontrol);
            Name = "tabelaCliente";
            ((System.ComponentModel.ISupportInitialize)tabelaClientecontrol).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaClientecontrol;
    }
}
