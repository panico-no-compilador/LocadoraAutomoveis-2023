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
