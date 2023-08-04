namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class ValidadorGrupoAutomoveis : AbstractValidator<GrupoAutomovel>, IValidadorGrupoAutomoveis
    {
        public ValidadorGrupoAutomoveis()
        {
            RuleFor(x => x.Tipo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();
        }
    }
}
