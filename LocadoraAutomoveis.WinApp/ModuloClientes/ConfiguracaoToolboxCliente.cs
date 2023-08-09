using LocadoraAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinApp.ModuloClientes
{
    internal class ConfiguracaoToolboxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de clientes";

        public override string TooltipInserir => "Inserir Novo cliente";

        public override string TooltipEditar => "Editar cliente existente";

        public override string TooltipExcluir => "Excluir cliente existente";
    }
}
