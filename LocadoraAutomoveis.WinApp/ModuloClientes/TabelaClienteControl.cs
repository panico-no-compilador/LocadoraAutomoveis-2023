

using LocadoraAutomoveis.Dominio.ModuloClientes;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.Compartilhado.Extensoes;

namespace LocadoraAutomoveis.WinApp.ModuloClientes
{
    public partial class tabelaCliente : UserControl
    {
        public tabelaCliente()
        {
            InitializeComponent();
            tabelaClientecontrol.ConfigurarGridZebrado();
            tabelaClientecontrol.ConfigurarGridSomenteLeitura();
            tabelaClientecontrol.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
            {
                var colunas = new DataGridViewColumn[]
                {

                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "CpfOUCnpj", HeaderText = "Cnpj/Cpf", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cidade", HeaderText = "Cidade", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Bairro", HeaderText = "Bairro", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Rua", HeaderText = "Numero", FillWeight=85F },

                };
                return colunas;
            }
        public Guid ObtemIdSelecionado()
        {
            return tabelaClientecontrol.SelecionarId();
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            tabelaClientecontrol.Rows.Clear();

            foreach (Cliente cliente in clientes)
            {
                tabelaClientecontrol.Rows.Add(cliente.Id, cliente.Nome,cliente.Email,cliente.Telefone,cliente.CpfOUCnpj,cliente.Estado,cliente.Cidade,cliente.Bairro,cliente.Rua);
            }
        }

    }
}
