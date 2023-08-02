namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public interface IRepositorioGrupoAutomoveis : IRepositorio<GrupoAutomoveis>
    {
        GrupoAutomoveis SelecionarPorNome(string nome);
    }
}
