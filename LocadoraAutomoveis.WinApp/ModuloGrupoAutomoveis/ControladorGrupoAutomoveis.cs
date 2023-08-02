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
            TelaGrupoAutomoveisForm tela = new TelaGrupoAutomoveisForm();

            tela.onGravarRegistro += servicoGrupoAutomoveis.Inserir;

            tela.ConfigurarGrupoAutomoveis(new GrupoAutomoveis());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoAutomoveis();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoAutomoveis();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoAutomoveis == null)
                tabelaGrupoAutomoveis = new TabelaGrupoAutomoveisControl();

            CarregarGrupoAutomoveis();

            return tabelaGrupoAutomoveis;
        }

        private void CarregarGrupoAutomoveis()
        {
            List<GrupoAutomoveis> disciplinas = repositorioGrupoAutomoveis.SelecionarTodos();

            tabelaGrupoAutomoveis.AtualizarRegistros(disciplinas);

            mensagemRodape = string.Format("Visualizando {0} grupo de automoveis{1}", disciplinas.Count, disciplinas.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
        public override void Editar()
        {
            Guid id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            GrupoAutomoveis grupAutoSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(id);

            if (grupAutoSelecionado == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaGrupoAutomoveisForm tela = new TelaGrupoAutomoveisForm();

            tela.onGravarRegistro += servicoGrupoAutomoveis.Editar;

            tela.ConfigurarGrupoAutomoveis(grupAutoSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoAutomoveis();
            }
        }
    }
}
