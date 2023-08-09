namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    partial class TabelaAutomoveisControl
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
            tabelaAutomovel = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaAutomovel).BeginInit();
            SuspendLayout();
            // 
            // tabelaAutomovel
            // 
            tabelaAutomovel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaAutomovel.Dock = DockStyle.Fill;
            tabelaAutomovel.Location = new Point(0, 0);
            tabelaAutomovel.Name = "tabelaAutomovel";
            tabelaAutomovel.RowTemplate.Height = 25;
            tabelaAutomovel.Size = new Size(150, 150);
            tabelaAutomovel.TabIndex = 0;
            // 
            // TabelaAutomoveisControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaAutomovel);
            Name = "TabelaAutomoveisControl";
            ((System.ComponentModel.ISupportInitialize)tabelaAutomovel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaAutomovel;
    }
}
