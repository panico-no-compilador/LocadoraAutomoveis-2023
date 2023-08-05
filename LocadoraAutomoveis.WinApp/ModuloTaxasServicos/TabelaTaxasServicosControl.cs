using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloTaxasServicos
{
    public partial class TabelaTaxasServicosControl : UserControl
    {
        public TabelaTaxasServicosControl()
        {
            InitializeComponent();
            tabelaTaxasServicos.ConfigurarGridZebrado();
            tabelaTaxasServicos.ConfigurarGridSomenteLeitura();
            tabelaTaxasServicos.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },
                
                new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preco", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "PlanoCalculo", HeaderText = "Plano de Calculo", FillWeight=85F }
            };

            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return tabelaTaxasServicos.SelecionarId();
        }

        public void AtualizarRegistros(List<TaxasServicos> listaTaxasServicos)
        {
            tabelaTaxasServicos.Rows.Clear();

            foreach (TaxasServicos taxaServico in listaTaxasServicos)
            {
                tabelaTaxasServicos.Rows.Add(taxaServico.Id, taxaServico.Nome, taxaServico.Preco, taxaServico.PlanoCalculo);
            }
        }
    }
}
