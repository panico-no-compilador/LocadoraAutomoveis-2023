using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;

namespace LocadoraAutomoveis.Dominio.ModuloClientes
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public string Nome {get; set;}

        public string Email { get; set;}

        public string Telefone { get; set;}

        public string Estado { get; set;}

        public string Cidade { get; set;}

        public string Bairro { get; set;}

        public string Rua { get; set;}

        public string Numero { get; set;}

       public  List<Cupom> CuponsUsados { get; set;}

        public string CpfOUCnpj {get; set;}

        public TipoPessoaEnum TipoPessoa { get; set;}

        public Cliente(Guid id, string nome, string email, string telefone, string estado, string cidade, string bairro, string rua, string numero, List<Cupom> cuponsUsados, string cpfOuCnpj,TipoPessoaEnum tipoPessoa)
        {
            this.Id = id;
        }

        public Cliente()
        {
            this.CuponsUsados = new List<Cupom>();
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}", Nome, TipoPessoa.GetDescription());
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Email, Telefone, Estado, Cidade,CpfOUCnpj);
        }

        public override void Atualizar(Cliente cliente)
        {
            Nome = cliente.Nome;
            Email = cliente.Email;
            Telefone = cliente.Telefone;
            Estado = cliente.Estado;
            Cidade = cliente.Cidade;
            Bairro = cliente.Bairro;
            Rua = cliente.Rua;
            Numero = cliente.Numero;
            CuponsUsados = cliente.CuponsUsados;
            CpfOUCnpj = cliente.CpfOUCnpj;
            TipoPessoa = cliente.TipoPessoa;
        }

    }
}
