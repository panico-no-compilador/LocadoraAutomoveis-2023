using LocadoraAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloCuponsParceiros
{
    public class ConfiguracaoToolboxParceiro : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Parceiro";

        public override string TooltipInserir => "Inserir novo Parceiro";

        public override string TooltipEditar => "Editar um Parceiro existente";

        public override string TooltipExcluir => "Excluir um Parceiro Existente";
    }
}
