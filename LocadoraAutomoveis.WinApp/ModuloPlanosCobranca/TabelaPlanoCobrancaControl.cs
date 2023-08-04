using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    public partial class TabelaPlanoCobrancaControl : UserControl
    {
        public TabelaPlanoCobrancaControl()
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

                new DataGridViewTextBoxColumn { Name = "CategoriaGrupAuto.Tipo", HeaderText = "Grupo Automovel", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "TipoPlano", HeaderText = "Tipo Plano", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PrecoDiaria", HeaderText = "Preço Diaria", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PrecoKm", HeaderText = "Preço Km", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "KmDisponiveis", HeaderText = "Km Disponiveis", FillWeight=85F }
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
                tabelaPlanoCobranca.Rows.Add(planoCobranca.Id, planoCobranca.CategoriaGrupAuto.Tipo, planoCobranca.TipoPlano, planoCobranca.PrecoDiaria, planoCobranca?.PrecoKm, planoCobranca?.KmDisponiveis);
            }
        }
    }
}
