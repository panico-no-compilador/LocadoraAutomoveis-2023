using LocadoraAutomoveis.Aplicacao.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloConfiguracaoPrecos
{
    public class ControladorConfiguracaoPrecos : ControladorBase
    {
        IRepositorioConfiguracaoPrecos repositorioConfiguracaoPrecos;
        ServicoConfiguracaoPrecos servicoConfiguracaoPrecos;
        TabelaConfiguracaoPrecosControl tabelaConfiguracaoPrecos;
        public ControladorConfiguracaoPrecos(
            IRepositorioConfiguracaoPrecos repositorioConfiguracaoPrecos, 
            ServicoConfiguracaoPrecos servicoConfiguracaoPrecos
            )
        {
            this.repositorioConfiguracaoPrecos = repositorioConfiguracaoPrecos;
            this.servicoConfiguracaoPrecos = servicoConfiguracaoPrecos;
        }
        public override void ConfigurarPrecoCombustiveis()
        {
            Guid id = tabelaConfiguracaoPrecos.ObtemIdSelecionado();

            Combustivel combustivelSelecionado = repositorioConfiguracaoPrecos.SelecionarPorId(id);

            if (combustivelSelecionado == null)
            {
                MessageBox.Show("Selecione um Preço de Combustivel primeiro",
                "Configuracao de Precos de Combustiveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaConfiguracaoPrecoForm tela = new TelaConfiguracaoPrecoForm();

            tela.onGravarRegistro += servicoConfiguracaoPrecos.Editar;

            tela.ConfigurarCombustivel(combustivelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaConfiguracaoPrecos.ObtemIdSelecionado();

            Combustivel disciplinaSelecionada = repositorioConfiguracaoPrecos.SelecionarPorId(id);

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione um Preço de Combustivel primeiro",
                "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Preço de Combustivel?",
               "Exclusão de Preço de Combustivel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoConfiguracaoPrecos.Excluir(disciplinaSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Preço de Combustivel",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarDisciplinas();
            }
        }
        public override void Editar()
        {
            Guid id = tabelaConfiguracaoPrecos.ObtemIdSelecionado();

            Combustivel disciplinaSelecionada = repositorioConfiguracaoPrecos.SelecionarPorId(id);

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione um preços de combustivel primeiro",
                "Edição de Preço de Combustivel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaConfiguracaoPrecoForm tela = new TelaConfiguracaoPrecoForm();

            tela.onGravarRegistro += servicoConfiguracaoPrecos.Editar;

            tela.ConfigurarCombustivel(disciplinaSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }
        public override void Inserir()
        {
            TelaConfiguracaoPrecoForm tela = new TelaConfiguracaoPrecoForm();

            tela.onGravarRegistro += servicoConfiguracaoPrecos.Inserir;

            tela.ConfigurarCombustivel(new Combustivel());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxConfiguracaoPrecos();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaConfiguracaoPrecos == null)
                tabelaConfiguracaoPrecos = new TabelaConfiguracaoPrecosControl();

            CarregarDisciplinas();

            return tabelaConfiguracaoPrecos;
        }
        private void CarregarDisciplinas()
        {
            List<Combustivel> disciplinas = repositorioConfiguracaoPrecos.SelecionarTodos();

            tabelaConfiguracaoPrecos.AtualizarRegistros(disciplinas);

            mensagemRodape = string.Format("Visualizando {0} preços de combustive{1}", disciplinas.Count, disciplinas.Count == 1 ? "l" : "is");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
