namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public class ValidadorAutomoveis : AbstractValidator<Automovel>, IValidadorAutomoveis
    {
        public ValidadorAutomoveis()
        {
            RuleFor(x => x.Cor)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Combustivel)
                .NotEmpty()
                .NotNull()
                .IsInEnum();

            RuleFor(x => x.Placa)
                .NotEmpty()
                .NotNull()
                .MinimumLength(7)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.QntdCombustivel)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Quilometragem)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Marca)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Modelo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Ano)
                .NotEmpty()
                .NotNull(); 
            
            RuleFor(x => x.Alugado)
                .NotEmpty()
                .NotNull();
        }
    }
}
