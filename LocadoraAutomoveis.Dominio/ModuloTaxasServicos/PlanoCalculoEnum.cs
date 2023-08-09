using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloTaxasServicos
{
    public enum PlanoCalculoEnum
    {
        [Description("Selecione")]
        Selecione, 
        [Description("Preço Fixo")]
        PrecoFixo,
        [Description("Cobrança Diária")]
        CobrancaDiaria
    }
}
