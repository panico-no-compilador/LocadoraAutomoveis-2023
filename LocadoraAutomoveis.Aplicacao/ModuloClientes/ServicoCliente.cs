using LocadoraAutomoveis.Dominio.ModuloClientes;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Aplicacao.ModuloClientes
{
    public class ServicoCliente
    {

        private IRepositorioCliente repositorioCliente;
        private ValidadorCliente validadadorCliente;

        public ServicoCliente(
            IRepositorioCliente repositorioCliente,
            ValidadorCliente validadorCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.validadadorCliente = validadorCliente;
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Debug("Tentando excluir cliente...{@d}", cliente);

            try
            {
                bool clienteExiste = repositorioCliente.Existe(cliente);

                if (clienteExiste == false)
                {
                    Log.Warning("cliente {clienteId} não encontrado para excluir", cliente.Id);

                    return Result.Fail("cliente não encontrada");
                }

                repositorioCliente.Excluir(cliente);

                Log.Debug("cliente {clienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

              
             
                    msgErro = "Falha ao tentar excluir cliente";

               

                Log.Error(ex, msgErro + " {clienteId}", cliente.Id);

                return Result.Fail(erros);
            }
        }

        public Result Inserir(Cliente cliente)
        {
            Log.Debug("Tentando inserir cliente...{@d}", cliente);

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioCliente.Inserir(cliente);

                Log.Debug("cliente {clienteId} inserida com sucesso", cliente.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir cliente.";

                Log.Error(exc, msgErro + "{@d}", cliente);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Cliente cliente)
        {
            Log.Debug("Tentando editar cliente...{@d}", cliente);

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCliente.Editar(cliente);

                Log.Debug("cliente {clienteId} editada com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar cliente.";

                Log.Error(exc, msgErro + "{@d}", cliente);

                return Result.Fail(msgErro);
            }
        }

        private List<string> ValidarCliente(Cliente cliente)
        {
            var resultadoValidacao = validadadorCliente.Validate(cliente);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(cliente))
                erros.Add($"Este nome '{cliente.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Cliente cliente)
        {
            Cliente clienteEncontrada = repositorioCliente.SelecionarPorNome(cliente.Nome);

            if (clienteEncontrada != null &&
                clienteEncontrada.Id != cliente.Id &&
                clienteEncontrada.Nome == cliente.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
