namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public interface IRepositorioGrupoAutomoveis : IRepositorio<GrupoAutomovel>
    {
        GrupoAutomovel SelecionarPorNome(string nome);
    }
}
