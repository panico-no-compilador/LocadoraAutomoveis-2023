using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    public partial class TabelaPlanoCobranca : UserControl
    {
        public TabelaPlanoCobranca()
        {
            InitializeComponent();
            tabelaPlanoCobranca.ConfigurarGridSomenteLeitura();
            tabelaPlanoCobranca.ConfigurarGridZebrado();
            tabelaPlanoCobranca.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "TipoPlano", HeaderText = "Placa", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PrecoDiaria", HeaderText = "Marca", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PrecoKm", HeaderText = "Modelo", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "KmDisponiveis", HeaderText = "Cor", FillWeight=85F }
            };

            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return tabelaPlanoCobranca.SelecionarId();
        }

        public void AtualizarRegistros(List<PlanoCobranca> planosCobrancas)
        {
            tabelaPlanoCobranca.Rows.Clear();

            foreach (PlanoCobranca planoCobranca in planosCobrancas)
            {
                tabelaPlanoCobranca.Rows.Add(planoCobranca.Id, planoCobranca.TipoPlano, planoCobranca.PrecoDiaria, planoCobranca.PrecoKm, planoCobranca.KmDisponiveis);
            }
        }
    }
}
