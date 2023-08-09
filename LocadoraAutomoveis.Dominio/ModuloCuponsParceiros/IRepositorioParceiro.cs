namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public interface IRepositorioParceiro : IRepositorio<Parceiro>
    {
        Parceiro SelecionarPorNome(string nome);
    }
}
