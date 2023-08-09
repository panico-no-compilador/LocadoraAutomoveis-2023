using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloConfiguracaoPrecos
{
    public class ConfiguracaoToolboxConfiguracaoPrecos : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Preços de Combustiveis";

        public override string TooltipInserir => "Inserir novo Preços de Combustiveis";

        public override string TooltipEditar => "Editar um Preços de Combustiveis existente";

        public override string TooltipExcluir => "Excluir um Preços de Combustiveis existente";
    }
}
