namespace LocadoraAutomoveis.Dominio.ModuloCuponsParceiros
{
    public class ValidadorCupom : AbstractValidator<Cupom>, IValidadorCupom
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
