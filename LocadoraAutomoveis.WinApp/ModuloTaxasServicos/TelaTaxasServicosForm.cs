using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloTaxasServicos
{
    public partial class TelaTaxasServicosForm : Form
    {
        private TaxasServicos taxasServicos;
        public event GravarRegistroDelegate<TaxasServicos> onGravarRegistro;

        public TelaTaxasServicosForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }
        internal void ConfigurarGrupoAutomoveis(TaxasServicos taxasServicos)
        {
            this.taxasServicos = taxasServicos;
            txtNome.Text = taxasServicos.Nome;
            txtPreco.Text = taxasServicos.Preco.ToString();
            if (taxasServicos.PlanoCalculo == PlanoCalculoEnum.CobrancaDiaria)
            {
                rbtnCobrancaDiaria.Checked = true;
                rbtnPrecoFixo.Checked = false;
            }
            else if (taxasServicos.PlanoCalculo == PlanoCalculoEnum.PrecoFixo)
            {
                rbtnCobrancaDiaria.Checked = true;
                rbtnPrecoFixo.Checked = false;
            }
            else
            {
                rbtnCobrancaDiaria.Checked = false;
                rbtnPrecoFixo.Checked = false;
            }
        }
        public TaxasServicos ObterTaxasServicos()
        {
            taxasServicos.Nome = txtNome.Text;
            taxasServicos.Preco = txtPreco.Value;
            if (rbtnCobrancaDiaria.Checked)
            {
                taxasServicos.PlanoCalculo = PlanoCalculoEnum.CobrancaDiaria;
            }
            else
            {
                taxasServicos.PlanoCalculo = PlanoCalculoEnum.PrecoFixo;
            }
            return taxasServicos;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.taxasServicos = ObterTaxasServicos();

            Result resultado = onGravarRegistro(taxasServicos);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void rbtnCobrancaDiaria_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCobrancaDiaria.Checked == true)
            {
                rbtnCobrancaDiaria.Checked = true;
                rbtnPrecoFixo.Checked = false;
            }
            else
            {
                rbtnCobrancaDiaria.Checked = false;
                rbtnPrecoFixo.Checked = true;
            }
        }
    }
}
