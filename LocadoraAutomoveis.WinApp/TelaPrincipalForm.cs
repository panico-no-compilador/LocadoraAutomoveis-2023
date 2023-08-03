using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.WinApp.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCuponsParceiros;
using LocadoraAutomoveis.Aplicacao.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.ModuloCuponsParceiros;

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
            //var migracoesPendentes = dbContext.Database.GetPendingMigrations();

            //if (migracoesPendentes.Count() > 0)
            //{
            //    dbContext.Database.Migrate();
            //}

            IRepositorioParceiro repositorioParceiro = new RepositorioParceiroEmOrm(dbContext);
            ValidadorParceiro validadorParceiro = new ValidadorParceiro();
            ServicoParceiro servicoParceiro = new ServicoParceiro(repositorioParceiro, validadorParceiro);
            controladores.Add("ControladorParceiro", new ControladorParceiro(repositorioParceiro, servicoParceiro));

            IRepositorioCupom repositorioCupom = new RepositorioCupomEmOrm(dbContext);
            ValidadorCupom validadorCupom = new ValidadorCupom();
            ServicoCupom servicoCupom = new ServicoCupom(repositorioCupom,validadorCupom);
            controladores.Add("ControladorCupom", new ControladorCupom(repositorioCupom,repositorioParceiro, servicoCupom));

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

        private void cuponsParceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorParceiro"]);
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

        private void cuponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorCupom"]);
        }
    }
}