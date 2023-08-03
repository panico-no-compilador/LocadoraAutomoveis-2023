using LocadoraAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    internal class ConfiguracaoToolboxCupom : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Cupons";

        public override string TooltipInserir => "Inserir Novo Cupom";

        public override string TooltipEditar => "Editar Cupom existente";

        public override string TooltipExcluir => "Excluir Cupom existente";
    }
}
