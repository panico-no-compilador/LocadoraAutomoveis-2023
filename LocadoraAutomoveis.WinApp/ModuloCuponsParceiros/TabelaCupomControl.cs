using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.Compartilhado.Extensoes;

namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    public partial class TabelaCupomControl : UserControl
    {
        public TabelaCupomControl()
        {
            InitializeComponent();
            tabelaCupons.ConfigurarGridZebrado();
            tabelaCupons.ConfigurarGridSomenteLeitura();
            tabelaCupons.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {

                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Parceiro.Nome", HeaderText = "Parceiro", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "DataValidade", HeaderText = "Validade", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor", FillWeight=85F }
            };
                return colunas;
        }
       
        public Guid ObtemIdSelecionado()
        {
            return tabelaCupons.SelecionarId();
        }

        public void AtualizarRegistros(List<Cupom> cupons)
        {
            tabelaCupons.Rows.Clear();

            foreach (Cupom cupom in cupons)
            {
                tabelaCupons.Rows.Add(cupom.Id,cupom.Nome,cupom.Parceiro.Nome,cupom.DataValidade,cupom.Valor);
            }
        }
    }
}
