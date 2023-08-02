using LocadoraAutomoveis.Aplicacao.ModuloCuponsParceiros;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    public class ControladorParceiro : ControladorBase
    {
        private IRepositorioParceiro repositorioParceiro;
        private TabelaParceiroControl tabelaParceiro;
        private ServicoParceiro servicoParceiro;

        public ControladorParceiro
            (
            IRepositorioParceiro repositorioParceiro,
            ServicoParceiro servicoParceiro
            )
        {
            this.repositorioParceiro = repositorioParceiro;
            this.servicoParceiro = servicoParceiro;
        }
        public override void Inserir()
        {
            TelaParceiroForm tela = new TelaParceiroForm();

            tela.onGravarRegistro += servicoParceiro.Inserir;
            tela.ConfigurarParceiro(new Parceiro());
            DialogResult resultado = tela.ShowDialog();

            if ( resultado == DialogResult.OK )
            {
                CarregarParceiros();
            }
            
        }

        public override void Editar()
        {
            Guid id = tabelaParceiro.ObtemIdSelecionado();
            Parceiro parceiroSelecionado = repositorioParceiro.SelecionarPorId(id);

            if(parceiroSelecionado == null)
            {
                MessageBox.Show("Seleciona um parceiro Primeiro",
                    "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaParceiroForm tela = new TelaParceiroForm();
            tela.onGravarRegistro += servicoParceiro.Editar;
            tela.ConfigurarParceiro(parceiroSelecionado);
            DialogResult resultado = tela.ShowDialog();
            if(resultado == DialogResult.OK )
            {
                CarregarParceiros();
            }
        }
        public override void Excluir()
        {
            Guid id = tabelaParceiro.ObtemIdSelecionado();

            Parceiro parceiroSelecionado = repositorioParceiro.SelecionarPorId(id);
            if(parceiroSelecionado == null)
            {
                MessageBox.Show("Selecione um Parceiro Primeiro",
                    "Exclusão de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o parceiro ? ",
                "Exclusão de Parceiro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoParceiro.Excluir(parceiroSelecionado);

                if(resultado.IsFailed )
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Disciplinas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CarregarParceiros();
            }
            {

            }
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxParceiro();
        }
        public override UserControl ObtemListagem()
        {
            if(tabelaParceiro == null)
            {
                tabelaParceiro = new TabelaParceiroControl();
            }
            CarregarParceiros();
            return tabelaParceiro;
                
        }

        private void CarregarParceiros()
        {
            List<Parceiro> parceiros = repositorioParceiro.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(parceiros);

            mensagemRodape = string.Format("Visualizando {0} parceiro{1}", parceiros.Count, parceiros.Count == 1 ? "" : "s");
            TelaPrincipal.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
