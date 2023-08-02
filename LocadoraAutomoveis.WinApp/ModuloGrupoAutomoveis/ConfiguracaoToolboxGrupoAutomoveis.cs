using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    public class ConfiguracaoToolboxGrupoAutomoveis : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Grupo de Automóveis";

        public override string TooltipInserir => "Inserir nova Grupo de Automóveis";

        public override string TooltipEditar => "Editar uma Grupo de Automóveis existente";

        public override string TooltipExcluir => "Excluir uma Grupo de Automóveis existente";
    }
}
