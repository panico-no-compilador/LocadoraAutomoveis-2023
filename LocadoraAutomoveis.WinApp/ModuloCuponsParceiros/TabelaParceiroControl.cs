using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.Compartilhado.Extensoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    public partial class TabelaParceiroControl : UserControl
    {
        public TabelaParceiroControl()
        {
            InitializeComponent();
            tabelaParceiros.ConfigurarGridZebrado();
            tabelaParceiros.ConfigurarGridSomenteLeitura();
            tabelaParceiros.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F }
            };

            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return tabelaParceiros.SelecionarId();
        }

        public void AtualizarRegistros(List<Parceiro> parceiros)
        {
            tabelaParceiros.Rows.Clear();

            foreach (Parceiro parceiro in parceiros)
            {
                tabelaParceiros.Rows.Add(parceiro.Id, parceiro.Nome);
            }
        }
    }
}
