using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloPlanosCobranca;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        IRepositorioGrupoAutomoveis _repositorioGrupo;
        IRepositorioPlanoCobranca _repositorioPlano;
        ServicoPlanoCobranca servicoPlano;
        TabelaPlanoCobrancaControl tabelaPlanoCobranca;
        public ControladorPlanoCobranca(
            IRepositorioGrupoAutomoveis repositorioGrupo,
            IRepositorioPlanoCobranca repositorioPlano,
            ServicoPlanoCobranca servicoPlano
            )
        {
            _repositorioGrupo = repositorioGrupo;
            _repositorioPlano = repositorioPlano;
            this.servicoPlano = servicoPlano;
        }

        public override void Inserir()
        {
            List<GrupoAutomovel> listGrupoAutomoveis = _repositorioGrupo.SelecionarTodos();
            TelaPlanoCobrancaForm tela = new TelaPlanoCobrancaForm(listGrupoAutomoveis);

            tela.onGravarRegistro += servicoPlano.Inserir;

            tela.ConfigurarPlanoCobranca(new PlanoCobranca());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanoCobranca();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobrancaControl();

            CarregarPlanoCobranca();

            return tabelaPlanoCobranca;
        }
        private void CarregarPlanoCobranca()
        {
            List<PlanoCobranca> planosCobrancaList = _repositorioPlano.SelecionarTodos(incluirCategoriaGrupAuto : true);

            tabelaPlanoCobranca.AtualizarRegistros(planosCobrancaList);

            mensagemRodape = string.Format("Visualizando {0} Plano{1} de Cobrança{1}", planosCobrancaList.Count, planosCobrancaList.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
        public override void Editar()
        {
            Guid id = tabelaPlanoCobranca.ObtemIdSelecionado();

            PlanoCobranca automovelSelecionado = _repositorioPlano.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione uma plano cobrança primeiro",
                "Edição de Plano Automoveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<GrupoAutomovel> grupoAutomoveis = _repositorioGrupo.SelecionarTodos();

            TelaPlanoCobrancaForm tela = new TelaPlanoCobrancaForm(grupoAutomoveis);

            tela.onGravarRegistro += servicoPlano.Editar;

            tela.ConfigurarPlanoCobranca(automovelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanoCobranca();
            }
        }
        public override void Excluir()
        {
            Guid id = tabelaPlanoCobranca.ObtemIdSelecionado();

            PlanoCobranca planoSelecionado = _repositorioPlano.SelecionarPorId(id);

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                "Exclusão de Plano de Cobranças", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir um plano de cobrança?",
               "Exclusão de Plano de Cobranças", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoPlano.Excluir(planoSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Plano de Cobranças", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarPlanoCobranca();
            }
        }
    }
}
