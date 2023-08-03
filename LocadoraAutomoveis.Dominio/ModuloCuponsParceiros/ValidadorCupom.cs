using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public class ValidadorCupom : AbstractValidator<Cupom>
    {
        public ValidadorCupom() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Parceiro)
                .NotNull();

            RuleFor(x => x.DataValidade)
            .NotEmpty();
        }
       
    }
}
