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

namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    public partial class TelaCupomForm : Form
    {

        private Cupom cupom;

        public event GravarRegistroDelegate<Cupom> onGravarRegistro;


        public TelaCupomForm(List<Parceiro> parceiro)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarParceiros(parceiro);
        }


        public Cupom ObterCupom()
        {
            cupom.Nome = txtNome.Text;
            cupom.Valor = decimal.Parse(TxtValor.Text);
            cupom.DataValidade = CboxDataValidade.Value;
            cupom.Parceiro = (Parceiro)CboxParceiro.SelectedItem;
            return cupom;
        }

        public void ConfigurarCupom(Cupom cupom)
        {

            this.cupom = cupom;
            txtNome.Text = cupom.Nome;
            TxtValor.Text = cupom.Valor.ToString();
            CboxDataValidade.Value = CboxDataValidade.Value;
            CboxParceiro.SelectedItem = cupom.Parceiro;
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            this.cupom = ObterCupom();
            Result resultado = onGravarRegistro(cupom);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;
                TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                DialogResult = DialogResult.None;
            }
        }

        private void CarregarParceiros(List<Parceiro> parceiro)
        {
            CboxParceiro.DisplayMember = "Nome"; // Define a propriedade que será exibida no ComboBox.

            CboxParceiro.Items.Clear();
            CboxParceiro.Items.AddRange(parceiro.ToArray());
        }
    }
}
