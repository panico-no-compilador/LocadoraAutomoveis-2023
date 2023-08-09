namespace LocadoraAutomoveis.WinApp.ModuloConfiguracaoPrecos
{
    partial class TabelaConfiguracaoPrecosControl
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
            tabelaConfiguracaoPrecos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaConfiguracaoPrecos).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            tabelaConfiguracaoPrecos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaConfiguracaoPrecos.Dock = DockStyle.Fill;
            tabelaConfiguracaoPrecos.Location = new Point(0, 0);
            tabelaConfiguracaoPrecos.Name = "dataGridView1";
            tabelaConfiguracaoPrecos.Size = new Size(150, 150);
            tabelaConfiguracaoPrecos.TabIndex = 0;
            // 
            // TabelaConfiguracaoPrecosControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaConfiguracaoPrecos);
            Name = "TabelaConfiguracaoPrecosControl";
            ((System.ComponentModel.ISupportInitialize)tabelaConfiguracaoPrecos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaConfiguracaoPrecos;
    }
}
