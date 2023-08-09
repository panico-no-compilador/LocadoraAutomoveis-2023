namespace LocadoraAutomoveis.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            menu = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            disciplinaMenuItem = new ToolStripMenuItem();
            materiasMenuItem = new ToolStripMenuItem();
            questoesMenuItem = new ToolStripMenuItem();
            testesMenuItem = new ToolStripMenuItem();
            configPreçosToolStripMenuItem = new ToolStripMenuItem();
            cuponsParceirosToolStripMenuItem = new ToolStripMenuItem();
            funcionarosToolStripMenuItem = new ToolStripMenuItem();
            grupoDeAutoToolStripMenuItem = new ToolStripMenuItem();
            planosECobrançasToolStripMenuItem = new ToolStripMenuItem();
            taxasEServiçosToolStripMenuItem = new ToolStripMenuItem();
            toolbox = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnVizualizar = new ToolStripButton();
            btnDevolucao = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnCadastrarCupom = new ToolStripButton();
            btnCadastrarParceiros = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnPrecosCombustiveis = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            labelTipoCadastro = new ToolStripLabel();
            statusStrip1 = new StatusStrip();
            labelRodape = new ToolStripStatusLabel();
            panelRegistros = new Panel();
            menu.SuspendLayout();
            toolbox.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(686, 24);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { disciplinaMenuItem, materiasMenuItem, questoesMenuItem, testesMenuItem, configPreçosToolStripMenuItem, cuponsParceirosToolStripMenuItem, funcionarosToolStripMenuItem, grupoDeAutoToolStripMenuItem, planosECobrançasToolStripMenuItem, taxasEServiçosToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // disciplinaMenuItem
            // 
            disciplinaMenuItem.Name = "disciplinaMenuItem";
            disciplinaMenuItem.ShortcutKeys = Keys.F1;
            disciplinaMenuItem.Size = new Size(203, 22);
            disciplinaMenuItem.Text = "Aluguel";
            // 
            // materiasMenuItem
            // 
            materiasMenuItem.Name = "materiasMenuItem";
            materiasMenuItem.ShortcutKeys = Keys.F2;
            materiasMenuItem.Size = new Size(203, 22);
            materiasMenuItem.Text = "Automóveis";
            // 
            // questoesMenuItem
            // 
            questoesMenuItem.Name = "questoesMenuItem";
            questoesMenuItem.ShortcutKeys = Keys.F3;
            questoesMenuItem.Size = new Size(203, 22);
            questoesMenuItem.Text = "Clientes";
            // 
            // testesMenuItem
            // 
            testesMenuItem.Name = "testesMenuItem";
            testesMenuItem.ShortcutKeys = Keys.F4;
            testesMenuItem.Size = new Size(203, 22);
            testesMenuItem.Text = "Condutores";
            // 
            // configPreçosToolStripMenuItem
            // 
            configPreçosToolStripMenuItem.Name = "configPreçosToolStripMenuItem";
            configPreçosToolStripMenuItem.ShortcutKeys = Keys.F5;
            configPreçosToolStripMenuItem.Size = new Size(203, 22);
            configPreçosToolStripMenuItem.Text = "Preços Combustíveis";
            configPreçosToolStripMenuItem.Click += configPreçosToolStripMenuItem_Click;
            // 
            // cuponsParceirosToolStripMenuItem
            // 
            cuponsParceirosToolStripMenuItem.Name = "cuponsParceirosToolStripMenuItem";
            cuponsParceirosToolStripMenuItem.ShortcutKeys = Keys.F6;
            cuponsParceirosToolStripMenuItem.Size = new Size(203, 22);
            cuponsParceirosToolStripMenuItem.Text = "Cupons Parceiros";
            // 
            // funcionarosToolStripMenuItem
            // 
            funcionarosToolStripMenuItem.Name = "funcionarosToolStripMenuItem";
            funcionarosToolStripMenuItem.ShortcutKeys = Keys.F7;
            funcionarosToolStripMenuItem.Size = new Size(203, 22);
            funcionarosToolStripMenuItem.Text = "Funcionarios";
            // 
            // grupoDeAutoToolStripMenuItem
            // 
            grupoDeAutoToolStripMenuItem.Name = "grupoDeAutoToolStripMenuItem";
            grupoDeAutoToolStripMenuItem.ShortcutKeys = Keys.F8;
            grupoDeAutoToolStripMenuItem.Size = new Size(203, 22);
            grupoDeAutoToolStripMenuItem.Text = "Grupo de Auto";
            grupoDeAutoToolStripMenuItem.Click += grupoDeAutoToolStripMenuItem_Click;
            // 
            // planosECobrançasToolStripMenuItem
            // 
            planosECobrançasToolStripMenuItem.Name = "planosECobrançasToolStripMenuItem";
            planosECobrançasToolStripMenuItem.ShortcutKeys = Keys.F9;
            planosECobrançasToolStripMenuItem.Size = new Size(203, 22);
            planosECobrançasToolStripMenuItem.Text = "Planos e Cobranças";
            planosECobrançasToolStripMenuItem.Click += planosECobrançasToolStripMenuItem_Click;
            // 
            // taxasEServiçosToolStripMenuItem
            // 
            taxasEServiçosToolStripMenuItem.Name = "taxasEServiçosToolStripMenuItem";
            taxasEServiçosToolStripMenuItem.ShortcutKeys = Keys.F10;
            taxasEServiçosToolStripMenuItem.Size = new Size(203, 22);
            taxasEServiçosToolStripMenuItem.Text = "Taxas e Serviços";
            taxasEServiçosToolStripMenuItem.Click += taxasEServiçosToolStripMenuItem_Click;
            // 
            // toolbox
            // 
            toolbox.Enabled = false;
            toolbox.ImageScalingSize = new Size(20, 20);
            toolbox.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator2, btnVizualizar, btnDevolucao, toolStripSeparator3, btnCadastrarCupom, btnCadastrarParceiros, toolStripSeparator1, btnPrecosCombustiveis, toolStripSeparator4, labelTipoCadastro });
            toolbox.Location = new Point(0, 24);
            toolbox.Name = "toolbox";
            toolbox.Size = new Size(686, 32);
            toolbox.TabIndex = 1;
            toolbox.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnInserir.ImageScaling = ToolStripItemImageScaling.None;
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(5);
            btnInserir.Size = new Size(72, 29);
            btnInserir.Text = "Adicionar";
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(5);
            btnEditar.Size = new Size(51, 29);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(5);
            btnExcluir.Size = new Size(56, 29);
            btnExcluir.Text = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 32);
            // 
            // btnVizualizar
            // 
            btnVizualizar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnVizualizar.ImageScaling = ToolStripItemImageScaling.None;
            btnVizualizar.ImageTransparentColor = Color.Magenta;
            btnVizualizar.Name = "btnVizualizar";
            btnVizualizar.Padding = new Padding(5);
            btnVizualizar.Size = new Size(70, 29);
            btnVizualizar.Text = "Vizualizar";
            // 
            // btnDevolucao
            // 
            btnDevolucao.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDevolucao.ImageScaling = ToolStripItemImageScaling.None;
            btnDevolucao.ImageTransparentColor = Color.Magenta;
            btnDevolucao.Name = "btnDevolucao";
            btnDevolucao.Padding = new Padding(5);
            btnDevolucao.Size = new Size(67, 29);
            btnDevolucao.Text = "Devolver";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 32);
            // 
            // btnCadastrarCupom
            // 
            btnCadastrarCupom.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnCadastrarCupom.ImageScaling = ToolStripItemImageScaling.None;
            btnCadastrarCupom.ImageTransparentColor = Color.Magenta;
            btnCadastrarCupom.Name = "btnCadastrarCupom";
            btnCadastrarCupom.Padding = new Padding(5);
            btnCadastrarCupom.Size = new Size(61, 29);
            btnCadastrarCupom.Text = "Cupom";
            // 
            // btnCadastrarParceiros
            // 
            btnCadastrarParceiros.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnCadastrarParceiros.ImageScaling = ToolStripItemImageScaling.None;
            btnCadastrarParceiros.ImageTransparentColor = Color.Magenta;
            btnCadastrarParceiros.Name = "btnCadastrarParceiros";
            btnCadastrarParceiros.Padding = new Padding(5);
            btnCadastrarParceiros.Size = new Size(69, 29);
            btnCadastrarParceiros.Text = "Parceiros";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 32);
            // 
            // btnPrecosCombustiveis
            // 
            btnPrecosCombustiveis.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnPrecosCombustiveis.ImageScaling = ToolStripItemImageScaling.None;
            btnPrecosCombustiveis.ImageTransparentColor = Color.Magenta;
            btnPrecosCombustiveis.Name = "btnPrecosCombustiveis";
            btnPrecosCombustiveis.Padding = new Padding(5);
            btnPrecosCombustiveis.Size = new Size(93, 29);
            btnPrecosCombustiveis.Text = "Combustíveis";
            btnPrecosCombustiveis.Click += btnPrecosCombustiveis_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 32);
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new Size(90, 29);
            labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelRodape });
            statusStrip1.Location = new Point(0, 399);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(686, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(52, 17);
            labelRodape.Text = "[rodapé]";
            // 
            // panelRegistros
            // 
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 56);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(686, 343);
            panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 421);
            Controls.Add(panelRegistros);
            Controls.Add(statusStrip1);
            Controls.Add(toolbox);
            Controls.Add(menu);
            MainMenuStrip = menu;
            MinimumSize = new Size(702, 458);
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Locadora de Automóveis 1.0";
            WindowState = FormWindowState.Maximized;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            toolbox.ResumeLayout(false);
            toolbox.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem disciplinaMenuItem;
        private ToolStrip toolbox;
        private StatusStrip statusStrip1;
        private Panel panelRegistros;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripStatusLabel labelRodape;
        private ToolStripButton btnPrecosCombustiveis;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel labelTipoCadastro;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem materiasMenuItem;
        private ToolStripMenuItem questoesMenuItem;
        private ToolStripButton btnCadastrarParceiros;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem testesMenuItem;
        private ToolStripButton btnDuplicar;
        private ToolStripButton btnDevolucao;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem configPreçosToolStripMenuItem;
        private ToolStripMenuItem cuponsParceirosToolStripMenuItem;
        private ToolStripMenuItem funcionarosToolStripMenuItem;
        private ToolStripMenuItem grupoDeAutoToolStripMenuItem;
        private ToolStripMenuItem planosECobrançasToolStripMenuItem;
        private ToolStripMenuItem taxasEServiçosToolStripMenuItem;
        private ToolStripButton btnVizualizar;
        private ToolStripButton btnCadastrarCupom;
    }
}