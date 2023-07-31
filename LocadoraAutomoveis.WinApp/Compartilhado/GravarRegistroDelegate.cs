using LocadoraAutomoveis.Dominio.Compartilhado;
namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade disciplina)
        where TEntidade : EntidadeBase<TEntidade>;

}
