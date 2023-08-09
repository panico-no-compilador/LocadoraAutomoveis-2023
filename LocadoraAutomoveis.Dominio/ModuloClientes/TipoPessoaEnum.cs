using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloClientes
{
    public enum TipoPessoaEnum
    {
        [Description("Pessoa Física")]
        PessoaFisica = 1,

        [Description("Pessoa Jurídica")]
        PessoaJuridica = 2
    }
}
