using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloTaxasServicos
{
    public class ConfiguracaoToolboxTaxasServicos : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Taxas e Serviços";

        public override string TooltipInserir => "Inserir nova Taxas e Serviços";

        public override string TooltipEditar => "Editar uma Taxas e Serviços existente";

        public override string TooltipExcluir => "Excluir uma Taxas e Serviços existente";
    }
}
