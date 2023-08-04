using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public enum TipoCombustivelEnum
    {
        [Description("Diesel")]
        Diesel,
        [Description("Eletricidade")]
        Eletricidade,
        [Description("Etanol")]
        Etanol,
        [Description("Gasolina")]
        Gasolina,
        [Description("GNV")]
        GNV
    }
}
