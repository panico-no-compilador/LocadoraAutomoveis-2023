using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis
{
    public class RepositorioGrupoAutomoveisOrm : RepositorioBaseEmOrm<GrupoAutomovel>, IRepositorioGrupoAutomoveis
    {
        public RepositorioGrupoAutomoveisOrm(LocadoraAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public GrupoAutomovel SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Tipo == nome);
        }
    }
}
