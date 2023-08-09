using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.Compartilhado;
using LocadoraAutomoveis.WinApp.Compartilhado.Extensoes;
using System.Collections;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    public partial class TelaPlanoCobrancaForm : Form
    {
        PlanoCobranca planoCobranca;
        public event GravarRegistroDelegate<PlanoCobranca> onGravarRegistro;
        public TelaPlanoCobrancaForm(List<GrupoAutomovel>
            grupoAutomoveis)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarGrupoAutomoveis(grupoAutomoveis);
            CarregarCmbTipoPlano();
        }
        public PlanoCobranca ObterPlanoCobranca()
        {

            planoCobranca.CategoriaGrupAuto = cmbCategoriaGrupAuto.SelectedItem as GrupoAutomovel;
            planoCobranca.TipoPlano = (TipoPlanoEnum)cmbTipoPlanos.SelectedValue;
            planoCobranca.PrecoDiaria = (int)txtPrecoDiaria.Value;
            planoCobranca.PrecoKm = (int)txtPrecoKm.Value;
            planoCobranca.KmDisponiveis = Convert.ToInt32(txtKmDisponiveis.Text);

            return planoCobranca;
        }
        public void ConfigurarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            this.planoCobranca = planoCobranca;

            cmbCategoriaGrupAuto.SelectedItem = planoCobranca.CategoriaGrupAuto;
            cmbTipoPlanos.SelectedItem = planoCobranca.TipoPlano;
            txtPrecoDiaria.Value = planoCobranca.PrecoDiaria;
            txtPrecoKm.Value = planoCobranca.PrecoKm;
            txtKmDisponiveis.Text = planoCobranca.KmDisponiveis.ToString();

            HabilidarInputs();
        }
        private void CarregarGrupoAutomoveis(List<GrupoAutomovel> grupoAutomoveis)
        {
            cmbCategoriaGrupAuto.Items.Clear();

            foreach (GrupoAutomovel categoria in grupoAutomoveis)
            {
                cmbCategoriaGrupAuto.Items.Add(categoria);
            }
        }

        private void cmbTipoPlanos_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilidarInputs();
        }

        private void HabilidarInputs()
        {
            if (cmbTipoPlanos.SelectedItem is KeyValuePair<System.Enum, string> selectedPair)
            {
                TipoPlanoEnum tipoPlano;

                if (selectedPair.Key is TipoPlanoEnum)
                {
                    tipoPlano = (TipoPlanoEnum)selectedPair.Key;
                }
                else
                {
                    // Trate o cenário em que a chave não é do tipo TipoPlanoEnum
                    // Isso pode ocorrer se o dicionário contiver outros enums como chave
                    return;
                }

                switch (tipoPlano)
                {
                    case TipoPlanoEnum.Livre:
                        txtKmDisponiveis.Enabled = false;
                        txtPrecoDiaria.Enabled = true;
                        txtPrecoKm.Enabled = false;
                        break;
                    case TipoPlanoEnum.Diario:
                        txtKmDisponiveis.Enabled = false;
                        txtPrecoDiaria.Enabled = true;
                        txtPrecoKm.Enabled = true;
                        break;
                    case TipoPlanoEnum.Controlador:
                        txtKmDisponiveis.Enabled = true;
                        txtPrecoDiaria.Enabled = true;
                        txtPrecoKm.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void CarregarCmbTipoPlano()
        {
            TipoPlanoEnum[] tipoCombustivel = Enum.GetValues<TipoPlanoEnum>();

            ArrayList items = new ArrayList();

            foreach (Enum serie in tipoCombustivel)
            {
                var item = KeyValuePair.Create(serie, serie.GetDescription());
                items.Add(item);
            }

            cmbTipoPlanos.DataSource = items;
            cmbTipoPlanos.DisplayMember = "Value";
            cmbTipoPlanos.ValueMember = "Key";
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.planoCobranca = ObterPlanoCobranca();

            Result resultado = onGravarRegistro(planoCobranca);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
