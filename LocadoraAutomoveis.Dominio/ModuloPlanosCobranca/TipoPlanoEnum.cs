using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobranca
{
    public enum TipoPlanoEnum
    {
        [Description("Diario")]
        Diario,
        [Description("Controlador")]
        Controlador,
        [Description("Livre")]
        Livre
    }
}
