using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {
        PlanoCobranca SelecionarPorNome(TipoPlanoEnum tipo);
    }
}
