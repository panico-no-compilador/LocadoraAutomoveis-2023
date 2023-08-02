using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public class ValidadorParceiro : AbstractValidator<Parceiro>, IValidadorParceiro
    {
        public ValidadorParceiro()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .NaoPodeCaracteresEspeciais();
        }
    }
}
