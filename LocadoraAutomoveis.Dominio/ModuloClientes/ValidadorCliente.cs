using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloClientes
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente() 
        {
            RuleFor(C => C.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
               .NaoPodeCaracteresEspeciais();
          }

    }
}
