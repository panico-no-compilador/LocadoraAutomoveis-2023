using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloFuncionarios
{
    public class ValidadorFuncionarios : AbstractValidator<Funcionarios>, IValidadorFuncionario
    {
        public ValidadorFuncionarios()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais(); 
        }
    }
}
