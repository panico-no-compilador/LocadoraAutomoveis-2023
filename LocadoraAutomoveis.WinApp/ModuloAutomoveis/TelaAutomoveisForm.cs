using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    public partial class TelaAutomoveisForm : Form
    {
        private Automovel automovel;
        public event GravarRegistroDelegate<Automovel> onGravarRegistro;
        public TelaAutomoveisForm(List<GrupoAutomovel> grupoAutomoveis)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarGrupoAutomoveis(grupoAutomoveis);
        }
        public Automovel ObterAutomovel(Automovel _automovel)
        {
            this.automovel = _automovel;
            automovel.Imagem = pictureBox1.Image.ToByte();
            automovel.Placa = txtPlaca.Text.ToUpper();
            automovel.Ano = Convert.ToInt32(txtAno.Text);
            automovel.Categoria = cmbGrupAutomoveis.SelectedItem as GrupoAutomovel;
            automovel.Modelo = txtModelo.Text;
            automovel.Marca = txtMarca.Text;
            automovel.Cor = txtCor.Text;
            automovel.Combustivel = (TipoCombustivelEnum)cmbTipoCombustivel.SelectedItem;
            automovel.QntdCombustivel = Convert.ToInt32(txtCapacidadeCombustivel.Text);
            
            return automovel;
        }
        public void ConfigurarAutomovel(Automovel automovel)
        {
            pictureBox1.Image = automovel.Imagem.ToImage();
            txtPlaca.Text = automovel.Placa;
            txtAno.Text = automovel.Ano.ToString();
            cmbGrupAutomoveis.SelectedItem = automovel.Categoria;
            txtModelo.Text = automovel.Modelo;
            txtMarca.Text = automovel.Marca;
            txtCor.Text = automovel.Cor;
            cmbTipoCombustivel.SelectedItem = automovel.Combustivel;
            txtCapacidadeCombustivel.Text = automovel.QntdCombustivel.ToString();
        }
        private void CarregarGrupoAutomoveis(List<GrupoAutomovel> grupoAutomoveis)
        {
            cmbGrupAutomoveis.Items.Clear();

            foreach (GrupoAutomovel categoria in grupoAutomoveis)
            {
                cmbGrupAutomoveis.Items.Add(categoria);
            }
        }

        private void btnBuscarFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
