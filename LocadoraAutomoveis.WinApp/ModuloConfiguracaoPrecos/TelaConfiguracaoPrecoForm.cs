using LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloConfiguracaoPrecos
{
    public partial class TelaConfiguracaoPrecoForm : Form
    {
        Combustivel combustivel;
        public event GravarRegistroDelegate<Combustivel> onGravarRegistro;
        public TelaConfiguracaoPrecoForm()
        {
            InitializeComponent();
        }
        public Combustivel ObterPrecoCombustivel()
        {
            combustivel.PrecoGas = txtGasPreco.Value;
            combustivel.PrecoGasolina = txtGasolinaPreco.Value;
            combustivel.PrecoEtanol = txtEtanolPreco.Value;
            combustivel.PrecoDiesel = txtDieselPreco.Value;

            return combustivel;
        }
        public void ConfigurarCombustivel(Combustivel combustivel)
        {
            this.combustivel = combustivel;

            txtGasPreco.Value = this.combustivel.PrecoGas;
            txtEtanolPreco.Value = this.combustivel.PrecoEtanol;
            txtGasolinaPreco.Value = this.combustivel.PrecoGasolina;
            txtDieselPreco.Value = this.combustivel.PrecoDiesel;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.combustivel = ObterPrecoCombustivel();

            Result resultado = onGravarRegistro(combustivel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
