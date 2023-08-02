using LocadoraAutomoveis.Dominio.Compartilhado;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.Compartilhado
{
    public class RepositorioBaseEmOrm<T> : IRepositorio<T>
        where T : EntidadeBase<T>
    {
        protected readonly LocadoraAutomoveisDbContext dbContext;
        protected DbSet<T> registros;
        public RepositorioBaseEmOrm(LocadoraAutomoveisDbContext dbContext)
        {
            this.dbContext = dbContext;
            registros = dbContext.Set<T>();
        }
        public void Editar(T registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(T registro)
        {
            registros.Remove(registro);

            dbContext.SaveChanges();
        }

        public bool Existe(T registro)
        {
            return registros.Contains(registro);
        }

        public void Inserir(T novoRegistro)
        {
            registros.Add(novoRegistro);

            dbContext.SaveChanges();
        }

        public T SelecionarPorId(Guid id)
        {
            return registros.Find(id);
        }

        public List<T> SelecionarTodos()
        {
            return registros.ToList();

        }
    }
}
