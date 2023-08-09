using LocadoraAutomoveis.Dominio.Compartilhado;
namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade GrupoAutomoveis)
        where TEntidade : EntidadeBase<TEntidade>;

}
