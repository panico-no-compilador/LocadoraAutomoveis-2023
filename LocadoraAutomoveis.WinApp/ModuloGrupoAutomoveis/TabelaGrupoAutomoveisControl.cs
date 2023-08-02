﻿using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    public partial class TabelaGrupoAutomoveisControl : UserControl
    {
        public TabelaGrupoAutomoveisControl()
        {
            InitializeComponent();
            tabelaGrupoAuto.ConfigurarGridZebrado();
            tabelaGrupoAuto.ConfigurarGridSomenteLeitura();
            tabelaGrupoAuto.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Tipo", HeaderText = "Grupo do Automovel", FillWeight=85F }
            };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return tabelaGrupoAuto.SelecionarId();
        }

        public void AtualizarRegistros(List<GrupoAutomoveis> disciplinas)
        {
            tabelaGrupoAuto.Rows.Clear();

            foreach (GrupoAutomoveis disciplina in disciplinas)
            {
                tabelaGrupoAuto.Rows.Add(disciplina.Id, disciplina.Tipo);
            }
        }
    }
}