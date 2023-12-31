﻿using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    partial class TelaPlanoCobrancaForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGravar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            cmbCategoriaGrupAuto = new ComboBox();
            gbConfiguracao = new GroupBox();
            txtKmDisponiveis = new NumericUpDown();
            txtPrecoKm = new NumericUpDown();
            txtPrecoDiaria = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cmbTipoPlanos = new ComboBox();
            label2 = new Label();
            gbConfiguracao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKmDisponiveis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoKm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoDiaria).BeginInit();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(182, 229);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(263, 229);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 5;
            label1.Text = "Grupo de Automóveis:";
            // 
            // cmbCategoriaGrupAuto
            // 
            cmbCategoriaGrupAuto.FormattingEnabled = true;
            cmbCategoriaGrupAuto.Location = new Point(162, 17);
            cmbCategoriaGrupAuto.Name = "cmbCategoriaGrupAuto";
            cmbCategoriaGrupAuto.Size = new Size(176, 23);
            cmbCategoriaGrupAuto.TabIndex = 1;
            // 
            // gbConfiguracao
            // 
            gbConfiguracao.Controls.Add(txtKmDisponiveis);
            gbConfiguracao.Controls.Add(txtPrecoKm);
            gbConfiguracao.Controls.Add(txtPrecoDiaria);
            gbConfiguracao.Controls.Add(label5);
            gbConfiguracao.Controls.Add(label4);
            gbConfiguracao.Controls.Add(label3);
            gbConfiguracao.Controls.Add(cmbTipoPlanos);
            gbConfiguracao.Controls.Add(label2);
            gbConfiguracao.Location = new Point(30, 50);
            gbConfiguracao.Name = "gbConfiguracao";
            gbConfiguracao.Size = new Size(308, 173);
            gbConfiguracao.TabIndex = 7;
            gbConfiguracao.TabStop = false;
            gbConfiguracao.Text = "Configuração de Planos";
            // 
            // txtKmDisponiveis
            // 
            txtKmDisponiveis.Location = new Point(132, 127);
            txtKmDisponiveis.Maximum = new decimal(new int[] { 9000000, 0, 0, 0 });
            txtKmDisponiveis.Name = "txtKmDisponiveis";
            txtKmDisponiveis.Size = new Size(159, 23);
            txtKmDisponiveis.TabIndex = 5;
            txtKmDisponiveis.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPrecoKm
            // 
            txtPrecoKm.DecimalPlaces = 2;
            txtPrecoKm.Location = new Point(132, 93);
            txtPrecoKm.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            txtPrecoKm.Name = "txtPrecoKm";
            txtPrecoKm.Size = new Size(159, 23);
            txtPrecoKm.TabIndex = 4;
            txtPrecoKm.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPrecoDiaria
            // 
            txtPrecoDiaria.DecimalPlaces = 2;
            txtPrecoDiaria.Location = new Point(132, 64);
            txtPrecoDiaria.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            txtPrecoDiaria.Name = "txtPrecoDiaria";
            txtPrecoDiaria.Size = new Size(159, 23);
            txtPrecoDiaria.TabIndex = 3;
            txtPrecoDiaria.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 129);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 6;
            label5.Text = "Km Disponíveis:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 93);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 5;
            label4.Text = "Preço por Km:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 64);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 2;
            label3.Text = "Preço Diária:";
            // 
            // cmbTipoPlanos
            // 
            cmbTipoPlanos.FormattingEnabled = true;
            cmbTipoPlanos.Location = new Point(132, 32);
            cmbTipoPlanos.Name = "cmbTipoPlanos";
            cmbTipoPlanos.Size = new Size(159, 23);
            cmbTipoPlanos.TabIndex = 2;
            cmbTipoPlanos.SelectedIndexChanged += cmbTipoPlanos_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 35);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 0;
            label2.Text = "Tipos de Planos:";
            // 
            // TelaPlanoCobrancaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 286);
            Controls.Add(gbConfiguracao);
            Controls.Add(cmbCategoriaGrupAuto);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaPlanoCobrancaForm";
            Text = "Cadastro de Grupo Automoveis";
            gbConfiguracao.ResumeLayout(false);
            gbConfiguracao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtKmDisponiveis).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoKm).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoDiaria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private Label label1;
        private ComboBox cmbCategoriaGrupAuto;
        private GroupBox gbConfiguracao;
        private Label label2;
        private ComboBox cmbTipoPlanos;
        private Label label3;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private NumericUpDown txtPrecoKm;
        private NumericUpDown txtPrecoDiaria;
        private NumericUpDown txtKmDisponiveis;
    }
}