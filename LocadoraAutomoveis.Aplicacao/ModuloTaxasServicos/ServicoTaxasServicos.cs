using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;

namespace LocadoraAutomoveis.Aplicacao.ModuloTaxasServicos
{
    public class ServicoTaxasServicos
    {
        IRepositorioTaxasServicos repositorioTaxasServicos;
        IValidadorTaxasServicos validadorTaxasServicos;
        IContextoPersistencia contextoPersistencia;

        public ServicoTaxasServicos(
            IRepositorioTaxasServicos repositorioTaxasServicos,
            IValidadorTaxasServicos validadorTaxasServicos,
            IContextoPersistencia contextoPersistencia
            )
        {
            this.repositorioTaxasServicos = repositorioTaxasServicos;
            this.validadorTaxasServicos = validadorTaxasServicos;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(TaxasServicos taxasServicos)
        {
            Log.Debug("Tentando inserir taxa de serviço...{@t}", taxasServicos);

            List<string> erros = ValidarTaxasServicos(taxasServicos);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros); //cenário 2
            }

            try
            {
                repositorioTaxasServicos.Inserir(taxasServicos);

                contextoPersistencia.GravarDados();

                Log.Debug("Taxa de Serviço {TaxaServiçoId} inserida com sucesso", taxasServicos.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir uma taxa de serviço.";

                Log.Error(exc, msgErro + "{@t}", taxasServicos);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Excluir(TaxasServicos taxasServicos)
        {
            Log.Debug("Tentando excluir Taxa de Serviço...{@t}", taxasServicos);

            try
            {
                bool GrupoAutomoveisExiste = repositorioTaxasServicos.Existe(taxasServicos);

                if (GrupoAutomoveisExiste == false)
                {
                    Log.Warning("Taxa de Serviço {TaxaServicoId} não encontrada para excluir", taxasServicos.Id);

                    return Result.Fail("Taxa de Serviço não encontrada");
                }

                repositorioTaxasServicos.Excluir(taxasServicos);

                contextoPersistencia.GravarDados();

                Log.Debug("Taxa de Serviço {TaxaServicoId} excluída com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro = "Falha ao tentar excluir Taxa de Serviço";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {TaxaServicoId}", taxasServicos.Id);

                return Result.Fail(erros);
            }
        }

        public Result Editar(TaxasServicos taxasServicos)
        {
            Log.Debug("Tentando editar Taxa de Serviço...{@t}", taxasServicos);

            List<string> erros = ValidarTaxasServicos(taxasServicos);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
            try
            {
                repositorioTaxasServicos.Editar(taxasServicos);

                contextoPersistencia.GravarDados();

                Log.Debug("Taxa de Serviço {TaxaServicoId} editada com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Taxa de Serviço.";

                Log.Error(exc, msgErro + "{@t}", taxasServicos);

                return Result.Fail(msgErro);
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
