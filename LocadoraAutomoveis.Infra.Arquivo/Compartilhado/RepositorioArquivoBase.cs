using LocadoraAutomoveis.Dominio.Compartilhado;
using Microsoft.Win32;

namespace LocadoraAutomoveis.Infra.Arquivo.Compartilhado
{
    public abstract class RepositorioArquivoBase<IEntidadeBase>
        where IEntidadeBase : EntidadeBase<IEntidadeBase>
    {
        protected ContextoDados contextoDados;
        protected Guid contador;

        public RepositorioArquivoBase(ContextoDados contexto)
        {
            contextoDados = contexto;
            AtualizarContador();
        }
        private void AtualizarContador()
        {
            if (ObterRegistros().Count > 0)
                contador = ObterRegistros().Max(x => x.Id);
        }
        public virtual IEntidadeBase SelecionarPorId(Guid id)
        {
            IEntidadeBase entidade = ObterRegistros().FirstOrDefault(x => x.Id == id);

            return entidade;
        }
        public virtual void Inserir(IEntidadeBase novaEntidade)
        {
            ObterRegistros().Add(novaEntidade);
            contextoDados.GravarEmArquivoJson();

        }
        public virtual void Editar(Guid id, IEntidadeBase entidadeAtualizada)
        {
            IEntidadeBase entidadeSelecionada = SelecionarPorId(id);
            entidadeSelecionada.Atualizar(entidadeAtualizada);
            contextoDados.GravarEmArquivoJson();
        }
        public virtual void Excluir(IEntidadeBase entidadeSelecionada)
        {
            ObterRegistros().Remove(entidadeSelecionada);
            contextoDados.GravarEmArquivoJson();
        }

        protected abstract List<IEntidadeBase> ObterRegistros();
        public virtual List<IEntidadeBase> SelecionarTodos()
        {
            return ObterRegistros();
        }
    }
}
