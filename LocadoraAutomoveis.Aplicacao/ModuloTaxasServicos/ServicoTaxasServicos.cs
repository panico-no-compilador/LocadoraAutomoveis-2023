using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;

namespace LocadoraAutomoveis.Aplicacao.ModuloTaxasServicos
{
    public class ServicoTaxasServicos
    {
        IRepositorioTaxasServicos repositorioTaxasServicos;
        IValidadorTaxasServicos validadorTaxasServicos;

        public ServicoTaxasServicos(
            IRepositorioTaxasServicos repositorioTaxasServicos,
            IValidadorTaxasServicos validadorTaxasServicos
            )
        {
            this.repositorioTaxasServicos = repositorioTaxasServicos;
            this.validadorTaxasServicos = validadorTaxasServicos;
        }
        public Result Inserir(TaxasServicos taxasServicos)
        {
            Log.Debug("Tentando inserir taxa de serviço...{@d}", taxasServicos);

            List<string> erros = ValidarTaxasServicos(taxasServicos);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioTaxasServicos.Inserir(taxasServicos);

                Log.Debug("Taxa de Serviço {TaxaServiçoId} inserida com sucesso", taxasServicos.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir uma taxa de serviço.";

                Log.Error(exc, msgErro + "{@d}", taxasServicos);

                return Result.Fail(msgErro); //cenário 3
            }
        }
        private List<string> ValidarTaxasServicos(TaxasServicos taxasServicos)
        {
            var resultadoValidacao = validadorTaxasServicos.Validate(taxasServicos);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(taxasServicos))
                erros.Add($"Este taxa de serviço '{taxasServicos.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }
        public Result Excluir(TaxasServicos taxasServicos)
        {
            Log.Debug("Tentando excluir Taxa de Serviço...{@d}", taxasServicos);

            try
            {
                bool GrupoAutomoveisExiste = repositorioTaxasServicos.Existe(taxasServicos);

                if (GrupoAutomoveisExiste == false)
                {
                    Log.Warning("Taxa de Serviço {TaxaServicoId} não encontrada para excluir", taxasServicos.Id);

                    return Result.Fail("GrupoAutomoveis não encontrada");
                }

                repositorioTaxasServicos.Excluir(taxasServicos);

                Log.Debug("Taxa de Serviço {TaxaServicoId} excluída com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBGrupoAutomoveis"))
                    msgErro = "Esta Taxa de Serviço está relacionada com uma e não pode ser excluída";
                else
                    msgErro = "Falha ao tentar excluir Taxa de Serviço";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {TaxaServicoId}", taxasServicos.Id);

                return Result.Fail(erros);
            }
        }
        private bool NomeDuplicado(TaxasServicos taxasServicos)
        {
            TaxasServicos TaxaServicoEncontrado = repositorioTaxasServicos.SelecionarPorNome(taxasServicos.Nome);

            if (TaxaServicoEncontrado != null &&
                TaxaServicoEncontrado.Id != taxasServicos.Id &&
                TaxaServicoEncontrado.Nome == taxasServicos.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
