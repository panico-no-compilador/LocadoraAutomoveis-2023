using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloAutomoveis
{
    public class ConfiguracaoToolboxAutomoveis : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Automoveis";

        public override string TooltipInserir => "Inserir nova Automoveis";

        public override string TooltipEditar => "Editar uma Automoveis existente";

        public override string TooltipExcluir => "Excluir uma Automoveis existente";
    }
}
