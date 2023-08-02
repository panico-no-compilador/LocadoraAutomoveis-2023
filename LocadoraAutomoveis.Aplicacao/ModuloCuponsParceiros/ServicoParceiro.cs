using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Aplicacao.ModuloCuponsParceiros
{
    public class ServicoParceiro
    {
        private IRepositorioParceiro repositorioParceiro;
        private IValidadorParceiro validadorParceiro;

        public ServicoParceiro(
            IRepositorioParceiro repositorioParceiro,
            IValidadorParceiro validadorParceiro)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.validadorParceiro = validadorParceiro;
        }
        public Result Inserir(Parceiro parceiro)
        {
            Log.Debug("Tentando inserir parceiro...{@d}", parceiro);

            List<string> erros = ValidarParceiro(parceiro);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioParceiro.Inserir(parceiro);

                Log.Debug("parceiro {parceiroId} inserida com sucesso", parceiro.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir parceiro.";

                Log.Error(exc, msgErro + "{@d}", parceiro);

                return Result.Fail(msgErro); //cenário 3
            }
        }
        public Result Editar(Parceiro parceiro)
        {
            Log.Debug("Tentando editar Parceiro...{@d}", parceiro);

            List<string> erros = ValidarParceiro(parceiro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioParceiro.Editar(parceiro);

                Log.Debug("Parceiro {ParceiroId} editada com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Parceiro.";

                Log.Error(exc, msgErro + "{@d}", parceiro);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Parceiro parceiro)
        {
            Log.Debug("Tentando excluir Parceiro...{@d}", parceiro);

            try
            {
                bool ParceiroExiste = repositorioParceiro.Existe(parceiro);

                if (ParceiroExiste == false)
                {
                    Log.Warning("Parceiro {ParceiroId} não encontrada para excluir", parceiro.Id);

                    return Result.Fail("Parceiro não encontrada");
                }

                repositorioParceiro.Excluir(parceiro);

                Log.Debug("Parceiro {ParceiroId} excluída com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBMateria_TBParceiro"))
                    msgErro = "Esta Parceiro está relacionada com uma matéria e não pode ser excluída";
                else
                    msgErro = "Falha ao tentar excluir Parceiro";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {ParceiroId}", parceiro.Id);

                return Result.Fail(erros);
            }
        }
        private List<string> ValidarParceiro(Parceiro parceiro)
        {
            var resultadoValidacao = validadorParceiro.Validate(parceiro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(parceiro))
                erros.Add($"Este nome '{parceiro.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Parceiro parceiro)
        {
            Parceiro parceiroEncontrada = repositorioParceiro.SelecionarPorNome(parceiro.Nome);

            if (parceiroEncontrada != null &&
                parceiroEncontrada.Id != parceiro.Id &&
                parceiroEncontrada.Nome == parceiro.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
