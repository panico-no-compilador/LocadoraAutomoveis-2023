using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    internal class ControladorAutomoveis : ControladorBase
    {
        IRepositorioAutomoveis repositorioAutomoveis;
        TabelaAutomoveisControl tabelaAutomoveis;
        ServicoAutomoveis servicoAutomoveis;
        public ControladorAutomoveis(
            IRepositorioAutomoveis repositorioAutomoveis,
            ServicoAutomoveis servicoAutomoveis
            )
        {
            this.repositorioAutomoveis = repositorioAutomoveis;
            this.servicoAutomoveis = servicoAutomoveis;
        }
        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
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
            List<Automovel> disciplinas = repositorioAutomoveis.SelecionarTodos();

            tabelaAutomoveis.AtualizarRegistros(disciplinas);

            mensagemRodape = string.Format("Visualizando {0} automove{1}", disciplinas.Count, disciplinas.Count == 1 ? "is" : "l");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
