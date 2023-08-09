using LocadoraAutomoveis.Aplicacao.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloPlanosCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloTaxasServicos;
using LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using LocadoraAutomoveis.Infra.Arquivo.Compartilhado;
using LocadoraAutomoveis.Infra.Arquivo.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanosCobranca;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxasServicos;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.ModuloTaxasServicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraAutomoveis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private static ContextoDados contextoDados;
        private Dictionary<string, ControladorBase> controladores;
        private ControladorBase controlador;

        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;
            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;
            controladores = new Dictionary<string, ControladorBase>();


            ConfigurarControladores();
        }
        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape()
        {
            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }

        private void ConfigurarControladores()
        {
            //instancia do servico, repositorio, validador || controladores.Add()
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuracao.GetConnectionString("SqlServer");
            var optionsBuilder = new DbContextOptionsBuilder<LocadoraAutomoveisDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var dbContext = new LocadoraAutomoveisDbContext(optionsBuilder.Options);

            contextoDados = new ContextoDados(carregarDados: true);

            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisOrm(dbContext);
            IRepositorioPlanoCobranca repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);
            IRepositorioTaxasServicos repositorioTaxasServicos = new RepositorioTaxasServicos(dbContext);
            IRepositorioConfiguracaoPrecos repositorioConfiguracaoPrecos = new RepositorioConfiguracaoPrecosArquivoJson(contextoDados);

            ValidadorGrupoAutomoveis validationRules = new ValidadorGrupoAutomoveis();
            ValidadorPlanoCobranca validationRules1 = new ValidadorPlanoCobranca();
            ValidadorTaxasServicos validationRules2 = new ValidadorTaxasServicos();
            ValidadorConfiguracaoPrecos validation = new ValidadorConfiguracaoPrecos();

            ServicoGrupoAutomoveis servicoGrupoAutomoveis = new ServicoGrupoAutomoveis(repositorioGrupoAutomoveis, validationRules);
            ServicoPlanoCobranca servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca, validationRules1);
            ServicoTaxasServicos servicoTaxasServicos = new ServicoTaxasServicos(repositorioTaxasServicos, validationRules2);
            ServicoConfiguracaoPrecos servicoConfiguracaoPrecos = new ServicoConfiguracaoPrecos(repositorioConfiguracaoPrecos, validation);

            controladores.Add("ControladorGrupoAutomoveis", new ControladorGrupoAutomoveis(repositorioGrupoAutomoveis, servicoGrupoAutomoveis));
            controladores.Add("ControladorPlanoCobranca", new ControladorPlanoCobranca(repositorioGrupoAutomoveis, repositorioPlanoCobranca, servicoPlanoCobranca));
            controladores.Add("ControladorTaxasServicos", new ControladorTaxasServicos(repositorioTaxasServicos, validationRules2, servicoTaxasServicos));
            controladores.Add("ControladorConfiguracaoPrecos", new ControladorConfiguracaoPrecos());
        }
        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void grupoDeAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorGrupoAutomoveis"]);
        }
        private void planosECobranšasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorPlanoCobranca"]);
        }
        private void taxasEServišosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorTaxasServicos"]);
        }
        private void configPrešosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorConfiguracaoPrecos"]);
        }
        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            this.controlador = controladorBase;

            ConfigurarToolbox();

            ConfigurarListagem();

            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }
        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }
        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnPrecosCombustiveis_Click(object sender, EventArgs e)
        {
            controlador.ConfigurarPrecoCombustiveis();
        }
    }
}