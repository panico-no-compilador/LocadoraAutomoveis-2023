namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public interface IRepositorioCupom : IRepositorio<Cupom>
    {
       public Cupom SelecionarPorNome(string nome);

        List<Cupom> SelecionarTodos(bool incluirParceiro = false);
    }
}
