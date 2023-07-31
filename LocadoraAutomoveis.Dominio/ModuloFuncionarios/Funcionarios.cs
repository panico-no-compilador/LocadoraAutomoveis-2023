namespace LocadoraAutomoveis.Dominio.ModuloFuncionarios
{
    public class Funcionarios : EntidadeBase<Funcionarios>
    {
        public string Nome { get; set; }
        public DateTime Admissao { get; set; }
        public  decimal Salario { get; set; }
        public override void Atualizar(Funcionarios registro)
        {
            this.Nome = registro.Nome;

            this.Admissao = registro.Admissao;

            this.Salario = registro.Salario;

        }
        public override bool Equals(object obj)
        {
            return obj is Funcionarios funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Admissao == funcionario.Admissao &&
                   Salario == funcionario.Salario;
        }
        public override string ToString()
        {
            return Nome.ToString();
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Admissao, Salario);
        }
    }
}
