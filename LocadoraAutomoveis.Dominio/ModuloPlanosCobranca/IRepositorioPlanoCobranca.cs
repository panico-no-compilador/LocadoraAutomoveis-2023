namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {
        PlanoCobranca SelecionarPorNome(TipoPlanoEnum tipo);
        List<PlanoCobranca> SelecionarTodos(bool incluirCategoriaGrupAuto = false);
    }
}
