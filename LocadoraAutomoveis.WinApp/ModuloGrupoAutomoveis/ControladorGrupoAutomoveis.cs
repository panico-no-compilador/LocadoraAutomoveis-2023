using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    public class ControladorGrupoAutomoveis : ControladorBase
    {
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        private ServicoGrupoAutomoveis servicoGrupoAutomoveis;
        private TabelaGrupoAutomoveisControl tabelaGrupoAutomoveis;
        public ControladorGrupoAutomoveis(
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis, 
            ServicoGrupoAutomoveis servicoGrupoAutomoveis
            )
        {
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.servicoGrupoAutomoveis = servicoGrupoAutomoveis;
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
            return new ConfiguracaoToolboxGrupoAutomoveis();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoAutomoveis == null)
                tabelaGrupoAutomoveis = new TabelaGrupoAutomoveisControl();

            CarregarDisciplinas();

            return tabelaGrupoAutomoveis;
        }

        private void CarregarDisciplinas()
        {
            List<GrupoAutomoveis> disciplinas = repositorioGrupoAutomoveis.SelecionarTodos();

            tabelaGrupoAutomoveis.AtualizarRegistros(disciplinas);

            mensagemRodape = string.Format("Visualizando {0} disciplina{1}", disciplinas.Count, disciplinas.Count == 1 ? "" : "s");

            TelaPrincipal.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
