﻿using LocadoraAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    internal class ConfiguracaoToolboxAutomovel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Automoveis";

        public override string TooltipInserir => "Inserir novo Automovel";

        public override string TooltipEditar => "Editar um Automovel existente";

        public override string TooltipExcluir => "Excluir um Automovel existente";
    }
}
