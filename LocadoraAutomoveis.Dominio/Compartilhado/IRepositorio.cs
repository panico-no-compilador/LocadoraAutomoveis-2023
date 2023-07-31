﻿namespace LocadoraAutomoveis.Dominio.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);
        void Editar(T registro);
        void Excluir(T registro);
        bool Existe(T registro);

        List<T> SelecionarTodos();
        T SelecionarPorId(int id);

    }
}
