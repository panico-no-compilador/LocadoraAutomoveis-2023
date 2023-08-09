using FluentValidation;

namespace LocadoraAutomoveis.Dominio.ModuloConfiguracaoPrecos
{
    public class ValidadorConfiguracaoPrecos : AbstractValidator<Combustivel>, IValidadorConfiguracaoPrecos
    {
        public ValidadorConfiguracaoPrecos()
        {
            RuleFor(x => x.PrecoGasolina)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoEtanol)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoDiesel)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoGas)
                .NotEmpty()
                .NotNull();
        }
    }
}
