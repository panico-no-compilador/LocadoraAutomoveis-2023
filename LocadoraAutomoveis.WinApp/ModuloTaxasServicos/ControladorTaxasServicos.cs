using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloTaxasServicos;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis;
using System.Drawing.Drawing2D;

namespace LocadoraAutomoveis.WinApp.ModuloTaxasServicos
{
    public class ControladorTaxasServicos : ControladorBase
    {
        IRepositorioTaxasServicos repositorioTaxasServicos;
        IValidadorTaxasServicos validadorTaxasServicos;
        ServicoTaxasServicos servicoTaxasServicos;

        TabelaTaxasServicosControl tabelaTaxasServicos;
        public ControladorTaxasServicos(
            IRepositorioTaxasServicos repositorioTaxasServicos,
            IValidadorTaxasServicos validadorTaxasServicos,
            ServicoTaxasServicos servicoTaxasServicos
            )
        {
            this.repositorioTaxasServicos = repositorioTaxasServicos;
            this.validadorTaxasServicos = validadorTaxasServicos;
            this.servicoTaxasServicos = servicoTaxasServicos;
        }

        public override void Excluir()
        {
            Guid id = tabelaTaxasServicos.ObtemIdSelecionado();

            TaxasServicos taxasServicosSelecionada = repositorioTaxasServicos.SelecionarPorId(id);

            if (taxasServicosSelecionada == null)
            {
                MessageBox.Show("Selecione um taxas de serviços primeiro",
                "Exclusão de taxas de serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja realmente excluir o taxas de serviços {taxasServicosSelecionada.Nome}?",
               "Exclusão de taxas de serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoTaxasServicos.Excluir(taxasServicosSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de taxas de serviços",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarTaxasServicos();
            }
        }
        public override void Editar()
        {
            Guid id = tabelaTaxasServicos.ObtemIdSelecionado();

            TaxasServicos taxaServicoSelecionado = repositorioTaxasServicos.SelecionarPorId(id);

            if (taxaServicoSelecionado == null)
            {
                MessageBox.Show("Selecione uma taxa de serviço primeiro",
                "Edição de Taxas de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaTaxasServicosForm tela = new TelaTaxasServicosForm();

            tela.onGravarRegistro += servicoTaxasServicos.Editar;

            tela.ConfigurarTaxaServicos(taxaServicoSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxasServicos();
            }
        }
        public override void Inserir()
        {
            TelaTaxasServicosForm tela = new TelaTaxasServicosForm();

            tela.onGravarRegistro += servicoTaxasServicos.Inserir;

            tela.ConfigurarTaxaServicos(new TaxasServicos());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxasServicos();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxasServicos();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxasServicos == null)
                tabelaTaxasServicos = new TabelaTaxasServicosControl();

            CarregarTaxasServicos();

            return tabelaTaxasServicos;
        }

        private void CarregarTaxasServicos()
        {
            List<TaxasServicos> taxasServicos = repositorioTaxasServicos.SelecionarTodos();

            tabelaTaxasServicos.AtualizarRegistros(taxasServicos);

            mensagemRodape = string.Format("Visualizando {0} Taxa{1} de Serviço{1}", taxasServicos.Count, taxasServicos.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
