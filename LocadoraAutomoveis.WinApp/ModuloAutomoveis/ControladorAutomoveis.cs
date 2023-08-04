using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;
using System.Drawing.Drawing2D;

namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    internal class ControladorAutomoveis : ControladorBase
    {
        IRepositorioAutomoveis repositorioAutomoveis;
        IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        TabelaAutomoveisControl tabelaAutomoveis;
        ServicoAutomoveis servicoAutomoveis;
        public ControladorAutomoveis(
            IRepositorioAutomoveis repositorioAutomoveis,
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis,
            ServicoAutomoveis servicoAutomoveis
            )
        {
            this.repositorioAutomoveis = repositorioAutomoveis;
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.servicoAutomoveis = servicoAutomoveis;
        }
        public override void Inserir()
        {
            List<GrupoAutomovel> disciplinas = repositorioGrupoAutomoveis.SelecionarTodos();

            TelaAutomoveisForm tela = new TelaAutomoveisForm(disciplinas);

            tela.onGravarRegistro += servicoAutomoveis.Inserir;

            tela.ConfigurarAutomovel(new Automovel());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAutomovel();
            }
        }
        public override void Excluir()
        {
            throw new NotImplementedException();
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxAutomovel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAutomoveis == null)
                tabelaAutomoveis = new TabelaAutomoveisControl();

            CarregarAutomovel();

            return tabelaAutomoveis;
        }
        private void CarregarAutomovel()
        {
            List<Automovel> automoveis = repositorioAutomoveis.SelecionarTodos(incluirCategoriaGrupAuto: true);

            tabelaAutomoveis.AtualizarRegistros(automoveis);

            mensagemRodape = string.Format("Visualizando {0} automove{1}", automoveis.Count, automoveis.Count == 1 ? "is" : "l");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
