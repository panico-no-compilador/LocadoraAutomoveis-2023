using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;

namespace LocadoraAutomoveis.Dominio.ModuloTaxasServicos
{
    public interface IRepositorioTaxasServicos : IRepositorio<TaxasServicos>
    {
        TaxasServicos SelecionarPorNome(string nome);
    }
}
