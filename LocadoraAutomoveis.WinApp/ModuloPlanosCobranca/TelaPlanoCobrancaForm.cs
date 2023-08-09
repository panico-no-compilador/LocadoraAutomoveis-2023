using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.Compartilhado;
using System.Collections;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    public partial class TelaPlanoCobrancaForm : Form
    {
        PlanoCobranca planoCobranca;
        public TelaPlanoCobrancaForm(List<GrupoAutomovel>
            grupoAutomoveis)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarGrupoAutomoveis(grupoAutomoveis);
            CarregarCmbTipoPlano();
        }
        public PlanoCobranca ObterAutomovel()
        {

            planoCobranca.CategoriaGrupAuto = cmbCategoriaGrupAuto.SelectedItem as GrupoAutomovel;
            planoCobranca.TipoPlano = (TipoPlanoEnum)cmbTipoPlanos.SelectedValue;
            planoCobranca.PrecoDiaria = (int)txtPrecoDiaria.Value;
            planoCobranca.PrecoKm = (int)txtPrecoKm.Value;
            planoCobranca.KmDisponiveis = Convert.ToInt32(txtKmDisponiveis.Text);

            return planoCobranca;
        }
        public void ConfigurarAutomovel(PlanoCobranca planoCobranca)
        {
            this.planoCobranca = planoCobranca;

            cmbCategoriaGrupAuto.SelectedItem = planoCobranca.CategoriaGrupAuto.ToString();
            cmbTipoPlanos.SelectedItem = planoCobranca.TipoPlano.ToString();
            txtPrecoDiaria.Text = planoCobranca.PrecoDiaria.ToString();
            txtPrecoKm.Text = planoCobranca.PrecoKm.ToString();
            txtKmDisponiveis.Text = planoCobranca.KmDisponiveis.ToString();
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
            TipoPlanoEnum tipoPlano = (TipoPlanoEnum)cmbTipoPlanos.SelectedItem;
            if (tipoPlano.ToString() == TipoPlanoEnum.Livre.ToString())
            {
                txtKmDisponiveis.Enabled = true;
                txtPrecoDiaria.Enabled = false;
                txtPrecoKm.Enabled = true;
            }
            else if (tipoPlano.ToString() == TipoPlanoEnum.Diario.ToString())
            {
                txtKmDisponiveis.Enabled = true;
                txtPrecoDiaria.Enabled = false;
                txtPrecoKm.Enabled = false;
            }
            else if (tipoPlano.ToString() == TipoPlanoEnum.Controlador.ToString())
            {
                txtKmDisponiveis.Enabled = false;
                txtPrecoDiaria.Enabled = false;
                txtPrecoKm.Enabled = false;
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
    }
}
