using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloPlanosCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloTaxasServicos;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanosCobranca;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxasServicos;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.ModuloAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.ModuloTaxasServicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraAutomoveis.WinApp.ModuloCuponsParceiros;
using LocadoraAutomoveis.Infra.Orm.ModuloCuponsParceiros;
using LocadoraAutomoveis.Aplicacao.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.ModuloCuponsParceiros;
using LocadoraAutomoveis.Dominio.ModuloClientes;
using LocadoraAutomoveis.Infra.Orm.ModuloClientes;
using LocadoraAutomoveis.Aplicacao.ModuloClientes;
using LocadoraAutomoveis.WinApp.ModuloClientes;

namespace LocadoraAutomoveis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
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

            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisOrm(dbContext);
            IRepositorioPlanoCobranca repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);
            IRepositorioTaxasServicos repositorioTaxasServicos = new RepositorioTaxasServicos(dbContext);
            IRepositorioParceiro repositorioParceiro = new RepositorioParceiroEmOrm(dbContext);
            IRepositorioCupom repositorioCupom = new RepositorioCupomEmOrm(dbContext);
            IRepositorioAutomoveis repositorioAutomoveis = new RepositorioAutomoveisOrm(dbContext);
            IRepositorioCliente repositorioCliente = new RepositorioClienteEmOrm(dbContext);


            ValidadorGrupoAutomoveis validadorGrupoAutomoveis = new ValidadorGrupoAutomoveis();
            ValidadorPlanoCobranca validadorPlanoCobranca = new ValidadorPlanoCobranca();
            ValidadorTaxasServicos validadorTaxasServicos = new ValidadorTaxasServicos();
            ValidadorParceiro validadorParceiro = new ValidadorParceiro();
            ValidadorCupom validadorCupom = new ValidadorCupom();
            ValidadorAutomoveis validadorAutomoveis = new ValidadorAutomoveis();
            ValidadorCliente validadorCliente = new ValidadorCliente();

            ServicoGrupoAutomoveis servicoGrupoAutomoveis = new ServicoGrupoAutomoveis(repositorioGrupoAutomoveis, validadorGrupoAutomoveis);
            ServicoPlanoCobranca servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca, validadorPlanoCobranca);
            ServicoTaxasServicos servicoTaxasServicos = new ServicoTaxasServicos(repositorioTaxasServicos, validadorTaxasServicos);
            ServicoParceiro servicoParceiro = new ServicoParceiro(repositorioParceiro, validadorParceiro);
            ServicoCupom servicoCupom = new ServicoCupom(repositorioCupom, validadorCupom);
            ServicoAutomoveis servicoAutomoveis = new ServicoAutomoveis(repositorioAutomoveis, validadorAutomoveis);
            ServicoCliente servicoCliente = new ServicoCliente(repositorioCliente, validadorCliente);

            controladores.Add("ControladorGrupoAutomoveis", new ControladorGrupoAutomoveis(repositorioGrupoAutomoveis, servicoGrupoAutomoveis));
            controladores.Add("ControladorPlanoCobranca", new ControladorPlanoCobranca(repositorioGrupoAutomoveis, repositorioPlanoCobranca, servicoPlanoCobranca));
            controladores.Add("ControladorTaxasServicos", new ControladorTaxasServicos(repositorioTaxasServicos, validadorTaxasServicos, servicoTaxasServicos));
            controladores.Add("ControladorParceiro", new ControladorParceiro(repositorioParceiro, servicoParceiro));
            controladores.Add("ControladorCliente", new ControlardorCliente(repositorioCliente, servicoCliente));
            controladores.Add("ControladorCupom", new ControladorCupom(repositorioCupom, repositorioParceiro, servicoCupom));
            controladores.Add("ControladorAutomoveis", new ControladorAutomoveis(repositorioAutomoveis, repositorioGrupoAutomoveis, servicoAutomoveis));
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
        private void materiasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorAutomoveis"]);
        }

        private void grupoDeAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorGrupoAutomoveis"]);
        }
        private void planosECobrançasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorPlanoCobranca"]);
        }
        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorTaxasServicos"]);
        }
        private void cuponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorCupom"]);
        }
        private void cuponsParceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorParceiro"]);
        }
        private void ClientesMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorCliente"]);
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

    }
}