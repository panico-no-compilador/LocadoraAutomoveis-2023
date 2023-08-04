using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;
using System.Collections;

namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    public partial class TelaAutomoveisForm : Form
    {
        private Automovel automovel;
        public Automovel teste;
        public event GravarRegistroDelegate<Automovel> onGravarRegistro;
        public TelaAutomoveisForm(List<GrupoAutomovel> grupoAutomoveis)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarGrupoAutomoveis(grupoAutomoveis);
            CarregarSeries();
        }
        public Automovel ObterAutomovel()
        {
            automovel.Imagem = pictureBox1.Image.ToByte();

            automovel.Placa = txtPlaca.Text;
            automovel.Ano = Convert.ToInt32(txtAno.Text);
            automovel.Categoria = (GrupoAutomovel)cmbGrupAutomoveis.SelectedItem;
            automovel.Modelo = txtModelo.Text;
            automovel.Marca = txtMarca.Text;
            automovel.Cor = txtCor.Text;
            automovel.Combustivel = (TipoCombustivelEnum)cmbTipoCombustivel.SelectedValue;
            automovel.QntdCombustivel = Convert.ToInt32(txtCapacidadeCombustivel.Text);

            return automovel;
        }
        public void ConfigurarAutomovel(Automovel automovel)
        {
            this.automovel = automovel;

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
        private void CarregarSeries()
        {
            TipoCombustivelEnum[] tipoCombustivel = Enum.GetValues<TipoCombustivelEnum>();

            ArrayList items = new ArrayList();

            foreach (Enum serie in tipoCombustivel)
            {
                var item = KeyValuePair.Create(serie, serie.GetDescription());
                items.Add(item);
            }

            cmbTipoCombustivel.DataSource = items;
            cmbTipoCombustivel.DisplayMember = "Value";
            cmbTipoCombustivel.ValueMember = "Key";
        }
        private void btnBuscarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string diretorio = openFileDialog1.FileName;
                //string diretorio = folderBrowserDialog1.SelectedPath;

                pictureBox1.Image = Image.FromFile(diretorio);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.automovel = ObterAutomovel();

            Result resultado = onGravarRegistro(automovel);
            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
