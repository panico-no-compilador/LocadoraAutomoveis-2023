using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    public partial class TabelaAutomoveisControl : UserControl
    {
        public TabelaAutomoveisControl()
        {
            InitializeComponent();
            tabelaAutomovel.ConfigurarGridSomenteLeitura();
            tabelaAutomovel.ConfigurarGridZebrado();
            tabelaAutomovel.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Placa", HeaderText = "Placa", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Marca", HeaderText = "Marca", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Modelo", HeaderText = "Modelo", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cor", HeaderText = "Cor", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Combustivel", HeaderText = "Combustivel", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Categoria.Tipo", HeaderText = "Categoria", FillWeight=85F },
            };

            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return tabelaAutomovel.SelecionarId();
        }

        public void AtualizarRegistros(List<Automovel> automoveis)
        {
            tabelaAutomovel.Rows.Clear();

            foreach (Automovel automovel in automoveis)
            {
                tabelaAutomovel.Rows.Add(automovel.Id, automovel.Placa, automovel.Marca, automovel.Modelo, automovel.Cor, automovel.Combustivel, automovel.Categoria?.Tipo);
            }
        }
    }
}
