﻿using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public class Automovel : EntidadeBase<Automovel>
    {
        public string Cor { get; set; }
        public TipoCombustivelEnum Combustivel { get; set; }
        public string Placa { get; set; }
        public int QntdCombustivel{ get; set; }
        public int Quilometragem { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public byte[] Imagem { get; set; }
        public bool Alugado { get; set; }
        public int Ano { get; set; }
        public GrupoAutomovel Categoria { get; set; }

        public override void Atualizar(Automovel registro)
        {
            Cor = registro.Cor;
            Combustivel = registro.Combustivel;
            Placa = registro.Placa;
            QntdCombustivel = registro.QntdCombustivel;
            Quilometragem = registro.Quilometragem;
            Marca = registro.Marca;
            Modelo = registro.Modelo;
            Imagem = registro.Imagem;
            Alugado = registro.Alugado;
            Ano = registro.Ano;
            Categoria = registro.Categoria;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Cor, Combustivel, Placa, QntdCombustivel, Quilometragem, Marca, Modelo);
        }
        public override string ToString()
        {
            return string.Format($"({Marca}) -> {Modelo}");
        }
        public override bool Equals(object obj)
        {
            return obj is Automovel grupAuto &&
                   Id == grupAuto.Id &&
                   Cor == grupAuto.Cor &&
                   Combustivel == grupAuto.Combustivel &&
                   Placa == grupAuto.Placa &&
                   QntdCombustivel == grupAuto.QntdCombustivel &&
                   Quilometragem == grupAuto.Quilometragem &&
                   Marca == grupAuto.Marca &&
                   Modelo == grupAuto.Modelo &&
                   Alugado == grupAuto.Alugado;
        }
    }
}