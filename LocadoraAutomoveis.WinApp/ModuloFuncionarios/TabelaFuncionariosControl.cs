using LocadoraAutomoveis.Dominio.ModuloFuncionarios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloFuncionarios
{
    public partial class TabelaFuncionariosControl : UserControl
    {
        public TabelaFuncionariosControl()
        {
            InitializeComponent();
            tabelaFuncionarios.ConfigurarGridSomenteLeitura();
            tabelaFuncionarios.ConfigurarGridZebrado();
            tabelaFuncionarios.Columns.AddRange(ObterColunas()); 
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Admissao", HeaderText = "Admissao", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Salario", HeaderText = "Salario", FillWeight=85F }
            };

            return colunas;
        }
        public void AtualizarRegistros(List<Funcionarios> funcionarios)
        {
            tabelaFuncionarios.Rows.Clear();

            foreach (Funcionarios funcionario in funcionarios)
            {
                tabelaFuncionarios.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Admissao, funcionario.Salario);
            }
        }
        public int ObtemIdSelecionado()
        {
            return tabelaFuncionarios.SelecionarId();
        }
    }
}
