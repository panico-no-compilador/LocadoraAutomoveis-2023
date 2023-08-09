namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    partial class TabelaPlanoCobrancaControl
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
            TabelaPlanoCobranca = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)TabelaPlanoCobranca).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            TabelaPlanoCobranca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaPlanoCobranca.Dock = DockStyle.Fill;
            TabelaPlanoCobranca.Location = new Point(0, 0);
            TabelaPlanoCobranca.Name = "dataGridView1";
            TabelaPlanoCobranca.Size = new Size(150, 150);
            TabelaPlanoCobranca.TabIndex = 0;
            // 
            // TabelaPlanoCobranca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TabelaPlanoCobranca);
            Name = "TabelaPlanoCobranca";
            ((System.ComponentModel.ISupportInitialize)TabelaPlanoCobranca).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView TabelaPlanoCobranca;
    }
}
