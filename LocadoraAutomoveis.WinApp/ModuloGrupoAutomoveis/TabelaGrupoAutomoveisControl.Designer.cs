﻿namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    partial class TabelaGrupoAutomoveisControl
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
            tabelaGrupoAuto = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaGrupoAuto).BeginInit();
            SuspendLayout();
            // 
            // tabelaGrupoAuto
            // 
            tabelaGrupoAuto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaGrupoAuto.Dock = DockStyle.Fill;
            tabelaGrupoAuto.Location = new Point(0, 0);
            tabelaGrupoAuto.Name = "tabelaGrupoAuto";
            tabelaGrupoAuto.RowTemplate.Height = 25;
            tabelaGrupoAuto.Size = new Size(150, 150);
            tabelaGrupoAuto.TabIndex = 0;
            // 
            // TabelaGrupoAutomoveis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabelaGrupoAuto);
            Name = "TabelaGrupoAutomoveis";
            ((System.ComponentModel.ISupportInitialize)tabelaGrupoAuto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaGrupoAuto;
    }
}
