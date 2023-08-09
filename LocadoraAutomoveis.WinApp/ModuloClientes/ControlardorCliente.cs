using LocadoraAutomoveis.Aplicacao.ModuloClientes;
using LocadoraAutomoveis.Aplicacao.ModuloCuponsParceiros;
using LocadoraAutomoveis.Dominio.ModuloClientes;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.ModuloCuponsParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloClientes
{
    public class ControlardorCliente : ControladorBase
    {
        private IRepositorioCliente repositorioCliente;

        private ServicoCliente servicoCliente;
        private tabelaCliente  tabelaCliente;
        

        public ControlardorCliente(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }

       
        public override void Excluir()
        {
            Guid id = tabelaCliente.ObtemIdSelecionado();
            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(id);

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Cupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a cliente?",
               "Exclusão de cupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCliente.Excluir(clienteSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de cupons",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            CarregarClientes();
        }
        private void CarregarClientes()
        {
            List<Cliente> cupons = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(cupons);

            mensagemRodape = string.Format("Visualizando {0} cliente{1}", cupons.Count, cupons.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override void Inserir()
        {
           
            TelaClienteForm tela = new TelaClienteForm();

            tela.onGravarRegistro += servicoCliente.Inserir;

            tela.ConfigurarCliente(new Cliente());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new tabelaCliente();

            CarregarClientes();
            return tabelaCliente;
        }
    }
}
