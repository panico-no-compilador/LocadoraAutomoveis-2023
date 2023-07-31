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
        public void Editar(T registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(T registro)
        {
            throw new NotImplementedException();
        }

        public bool Existe(T registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(T novoRegistro)
        {
            throw new NotImplementedException();
        }

        public T SelecionarPorId(int id)
        {
            return registros.Find(id);
        }

        public List<T> SelecionarTodos()
        {
            return registros.ToList();

        }
    }
}
