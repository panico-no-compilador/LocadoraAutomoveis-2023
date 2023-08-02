using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    public partial class TelaGrupoAutomoveisForm : Form
    {
        private GrupoAutomoveis grupoAutomoveis;
        public event GravarRegistroDelegate<GrupoAutomoveis> onGravarRegistro;

        public TelaGrupoAutomoveisForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        internal void ConfigurarGrupoAutomoveis(GrupoAutomoveis grupoAutomoveis)
        {
            this.grupoAutomoveis = grupoAutomoveis;
            txtTipo.Text = grupoAutomoveis.Tipo;
        }
        public GrupoAutomoveis ObterGrupoAutomoveis()
        {
            grupoAutomoveis.Tipo = txtTipo.Text;
            return grupoAutomoveis;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.grupoAutomoveis = ObterGrupoAutomoveis();

            Result resultado = onGravarRegistro(grupoAutomoveis);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
