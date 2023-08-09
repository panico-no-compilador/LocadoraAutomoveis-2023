namespace LocadoraAutomoveis.Dominio.ModuloClientes
{
    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente() 
        {
            RuleFor(C => C.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
               .NaoPodeCaracteresEspeciais();
          }

    }
}
