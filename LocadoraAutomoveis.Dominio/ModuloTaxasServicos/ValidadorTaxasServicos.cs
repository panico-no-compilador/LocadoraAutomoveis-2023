namespace LocadoraAutomoveis.Dominio.ModuloTaxasServicos
{
    public class ValidadorTaxasServicos : AbstractValidator<TaxasServicos>, IValidadorTaxasServicos
    {
        public ValidadorTaxasServicos()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Preco)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PlanoCalculo)
                .IsInEnum()
                .NotEmpty()
                .NotNull();
        }
    }
}
