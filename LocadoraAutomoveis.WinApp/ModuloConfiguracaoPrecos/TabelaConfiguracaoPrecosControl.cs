using LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloConfiguracaoPrecos
{
    public partial class TabelaConfiguracaoPrecosControl : UserControl
    {
        public TabelaConfiguracaoPrecosControl()
        {
            InitializeComponent();
            tabelaConfiguracaoPrecos.ConfigurarGridZebrado();
            tabelaConfiguracaoPrecos.ConfigurarGridSomenteLeitura();
            tabelaConfiguracaoPrecos.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preco", FillWeight=85F }
            };

            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return tabelaConfiguracaoPrecos.SelecionarId();
        }

        public void AtualizarRegistros(List<Combustivel> GrupoAutomoveiss)
        {
            tabelaConfiguracaoPrecos.Rows.Clear();

            foreach (Combustivel GrupoAutomoveis in GrupoAutomoveiss)
            {
                tabelaConfiguracaoPrecos.Rows.Add(GrupoAutomoveis.Id, GrupoAutomoveis.Nome, GrupoAutomoveis.Preco);
            }
        }
    }
}
