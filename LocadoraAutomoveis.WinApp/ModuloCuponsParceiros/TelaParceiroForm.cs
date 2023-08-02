using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    public partial class TelaParceiroForm : Form
    {
        private Parceiro parceiro;

        public event GravarRegistroDelegate<Parceiro> onGravarRegistro;
        public TelaParceiroForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }
        public Parceiro ObterParceiro()
        {
            parceiro.Nome = txtNome.Text;
            return parceiro;
        }

        public void ConfigurarParceiro(Parceiro parceiro)
        {
            this.parceiro = parceiro;

            //txtId.Text = parceiro.Id.ToString();
            txtNome.Text = parceiro.Nome;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.parceiro = ObterParceiro();

            Result resultado = onGravarRegistro(parceiro);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            this.parceiro = ObterParceiro();

            Result resultado = onGravarRegistro(parceiro);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }
    }
}
