﻿namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    partial class TabelaPlanoCobranca
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
            tabelaPlanoCobranca = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaPlanoCobranca).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            tabelaPlanoCobranca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaPlanoCobranca.Dock = DockStyle.Fill;
            tabelaPlanoCobranca.Location = new Point(0, 0);
            tabelaPlanoCobranca.Name = "dataGridView1";
            tabelaPlanoCobranca.Size = new Size(150, 150);
            tabelaPlanoCobranca.TabIndex = 0;
            // 
            // TabelaPlanoCobranca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaPlanoCobranca);
            Name = "TabelaPlanoCobranca";
            ((System.ComponentModel.ISupportInitialize)tabelaPlanoCobranca).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaPlanoCobranca;
    }
}
