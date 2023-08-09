using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;

namespace LocadoraAutomoveis.Aplicacao.ModuloCuponsParceiros
{
    public class ServicoCupom
    {
        private IRepositorioCupom repositorioCupom;
        private IContextoPersistencia contextoPersistencia;
        private ValidadorCupom validadorCupom;

        public ServicoCupom(
            IRepositorioCupom repositorioCupom,
            IContextoPersistencia contextoPersistencia,
            ValidadorCupom validadorCupom
            )
        {
            this.repositorioCupom = repositorioCupom;
            this.contextoPersistencia = contextoPersistencia;
            this.validadorCupom = validadorCupom;
        }

        public Result Editar(Cupom cupom)
        {
            Log.Debug("Tentando editar cupom...{@c}", cupom);

            List<string> erros = ValidarCupom(cupom);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCupom.Editar(cupom);
                
                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {CupomId} editada com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar cupom.";

                Log.Error(exc, msgErro + "{@d}", cupom);

                return Result.Fail(msgErro);
            }
        }

        public Result Inserir(Cupom cupom)
        {
            Log.Debug("Tentando inserir cupom...{@c}", cupom);

            List<string> erros = ValidarCupom(cupom);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros); //cenário 2
            }

            try
            {
                repositorioCupom.Inserir(cupom);

                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {CupomId} inserida com sucesso", cupom.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir cupom.";

                Log.Error(exc, msgErro + "{@c}", cupom);

                return Result.Fail(msgErro); //cenário 3
            }
        }
        public Result Excluir(Cupom cupom)
        {
            Log.Debug("Tentando excluir cupom...{@c}", cupom);

            try
            {
                bool cupomExiste = repositorioCupom.Existe(cupom);

                if (cupomExiste == false)
                {
                    Log.Warning("Cupom {CupomId} não encontrada para excluir", cupom.Id);

                    return Result.Fail("cupom não encontrada");
                }

                repositorioCupom.Excluir(cupom);

                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {CupomId} excluída com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;
                
                msgErro = "Falha ao tentar excluir cupom";
                   
                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {CupomId}", cupom.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarCupom(Cupom cupom)
        {
            var resultadoValidacao = validadorCupom.Validate(cupom);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(cupom))
                erros.Add($"Este nome '{cupom.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Cupom cupom)
        {
            Cupom cupomEncontrada = repositorioCupom.SelecionarPorNome(cupom.Nome);

            if (cupomEncontrada != null &&
                cupomEncontrada.Id != cupom.Id &&
                cupomEncontrada.Nome == cupom.Nome)
            {
                return true;
            }

            return false;
        }

    }
}
