using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobranca
{
    internal class ConfiguracaoToolboxPlanoCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Planos de Cobranças";

        public override string TooltipInserir => "Inserir novo Planos de Cobranças";

        public override string TooltipEditar => "Editar um Planos de Cobranças existente";

        public override string TooltipExcluir => "Excluir um Planos de Cobranças existente";
    }
}
