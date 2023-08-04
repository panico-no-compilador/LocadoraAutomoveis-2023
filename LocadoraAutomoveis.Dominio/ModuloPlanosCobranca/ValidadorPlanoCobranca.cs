using FluentValidation;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.TipoPlano)
                .IsInEnum()
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoDiaria)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrecoKm)
                .NotEmpty()
                .NotNull(); 

            RuleFor(x => x.KmDisponiveis)
                .NotEmpty()
                .NotNull();
        }
    }
}
