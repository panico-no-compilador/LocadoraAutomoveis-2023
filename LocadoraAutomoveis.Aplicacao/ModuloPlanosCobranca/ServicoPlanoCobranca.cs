using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;

namespace LocadoraAutomoveis.Aplicacao.ModuloPlanosCobranca
{
    public class ServicoPlanoCobranca
    {
        IRepositorioPlanoCobranca repositorioPlanoCobranca;
        IValidadorPlanoCobranca validadorPlanoCobranca;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, IValidadorPlanoCobranca validadorPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.validadorPlanoCobranca = validadorPlanoCobranca;
        }
        private List<string> ValidarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = validadorPlanoCobranca.Validate(planoCobranca);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (PlanoDuplicado(planoCobranca))
                erros.Add($"O grupo '{planoCobranca.CategoriaGrupAuto}' já está usando o plano '{planoCobranca.TipoPlano}'");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool PlanoDuplicado(PlanoCobranca planoCobranca)
        {
            PlanoCobranca planoCobrancaEncontrado =
                repositorioPlanoCobranca.SelecionarPorNome(planoCobranca.TipoPlano);

            if (planoCobrancaEncontrado != null &&
                planoCobrancaEncontrado.Id != planoCobranca.Id &&
                planoCobrancaEncontrado.CategoriaGrupAuto == planoCobranca.CategoriaGrupAuto &&
                planoCobrancaEncontrado.TipoPlano == planoCobranca.TipoPlano)
            {
                return true;
            }

            return false;
        }
    }
}
