using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloClientes;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Compartilhado.Extensoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloClientes
{
    public partial class TelaClienteForm : Form
    {
        private Cliente cliente;

        public event GravarRegistroDelegate<Cliente> onGravarRegistro;

        public TelaClienteForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Cliente ObterCliente()
        {
            cliente.Nome = TxtNome.Text;
            cliente.Cidade = TxtCidade.Text;
            cliente.Telefone = TxtTelefone.Text;
            cliente.Email = TxtEmail.Text;
            cliente.CpfOUCnpj = TxtCpf.Text;
            cliente.Numero = TxtNumero.Text;
            cliente.Rua = TxtRua.Text;
            cliente.Bairro = TxtBairro.Text;
            cliente.Estado = TxtEstado.Text;
            if (RBTNPessoaFisica.Checked == true)
            {
                cliente.TipoPessoa = TipoPessoaEnum.PessoaFisica;
            }
            else
            {
                cliente.TipoPessoa = TipoPessoaEnum.PessoaJuridica;
            }
            return cliente;



        }

        public void ConfigurarCliente(Cliente cliente)
        {

            this.cliente = cliente;
            TxtNome.Text = cliente.Nome;
            TxtTelefone.Text = cliente.Telefone;
            TxtEmail.Text = cliente.Email;
            if (RBTNPessoaFisica.Checked == true)
            {
                TxtCpf.Text = cliente.CpfOUCnpj;

            }
            else
            {
                TxtCnpj.Text = cliente.CpfOUCnpj;
            }
            TxtNumero.Text = cliente.Numero;
            TxtRua.Text = cliente.Rua;
            TxtBairro.Text = cliente.Bairro;
            TxtEstado.Text = cliente.Estado;

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BTNGravar_Click_1(object sender, EventArgs e)
        {
            this.cliente = ObterCliente();
            Result resultado = onGravarRegistro(cliente);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }

        private void RBTNPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            TxtCpf.Enabled = true;
            TxtCnpj.Enabled = false;
        }

        private void RBTNPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            TxtCpf.Enabled = false;
            TxtCnpj.Enabled = true;
        }
    }
}
