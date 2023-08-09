using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloConfiguracaoPrecos;

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
            Guid id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            GrupoAutomovel GrupoAutomoveisSelecionada = repositorioGrupoAutomoveis.SelecionarPorId(id);

            if (GrupoAutomoveisSelecionada == null)
            {
                MessageBox.Show("Selecione um grupo de automoveis primeiro",
                "Exclusão de grupo de automoveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja realmente excluir o grupo de automoveis {GrupoAutomoveisSelecionada.Tipo}?",
               "Exclusão de grupo de automoveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoGrupoAutomoveis.Excluir(GrupoAutomoveisSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de grupo de automoveis",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarGrupoAutomoveis();
            }
        }

        public override void Inserir()
        {
            TelaGrupoAutomoveisForm tela = new TelaGrupoAutomoveisForm();

            tela.onGravarRegistro += servicoGrupoAutomoveis.Inserir;

            tela.ConfigurarGrupoAutomoveis(new GrupoAutomovel());

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
            List<GrupoAutomovel> GrupoAutomoveiss = repositorioGrupoAutomoveis.SelecionarTodos();

            tabelaGrupoAutomoveis.AtualizarRegistros(GrupoAutomoveiss);

            mensagemRodape = string.Format("Visualizando {0} grupo de automoveis{1}", GrupoAutomoveiss.Count, GrupoAutomoveiss.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
        public override void Editar()
        {
            Guid id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            GrupoAutomovel grupAutoSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(id);

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
