using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloClientes;

namespace LocadoraAutomoveis.Aplicacao.ModuloClientes
{
    public class ServicoCliente
    {

        private IRepositorioCliente repositorioCliente;
        private IContextoPersistencia contextoPersistencia;
        private IValidadorCliente validadadorCliente;

        public ServicoCliente(
            IRepositorioCliente repositorioCliente,
            IContextoPersistencia contextoPersistencia,
            IValidadorCliente validadadorCliente
            )
        {
            this.repositorioCliente = repositorioCliente;
            this.contextoPersistencia = contextoPersistencia;
            this.validadadorCliente = validadadorCliente;
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Debug("Tentando excluir cliente...{@c}", cliente);

            try
            {
                bool clienteExiste = repositorioCliente.Existe(cliente);

                if (clienteExiste == false)
                {
                    Log.Warning("Cliente {ClienteId} não encontrado para excluir", cliente.Id);

                    return Result.Fail("Cliente não encontrado");
                }

                repositorioCliente.Excluir(cliente);

                contextoPersistencia.GravarDados();

                Log.Debug("Cliente {ClienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;
             
                    msgErro = "Falha ao tentar excluir cliente";

                Log.Error(ex, msgErro + " {ClienteId}", cliente.Id);

                return Result.Fail(erros);
            }
        }

        public Result Inserir(Cliente cliente)
        {
            Log.Debug("Tentando inserir Cliente...{@c}", cliente);

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros); //cenário 2
            }

            try
            {
                repositorioCliente.Inserir(cliente);

                contextoPersistencia.GravarDados();

                Log.Debug("Cliente {ClienteId} inserida com sucesso", cliente.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir cliente.";

                Log.Error(exc, msgErro + "{@c}", cliente);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Cliente cliente)
        {
            Log.Debug("Tentando editar cliente...{@c}", cliente);

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCliente.Editar(cliente);

                contextoPersistencia.GravarDados();

                Log.Debug("Cliente {ClienteId} editada com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar cliente.";

                Log.Error(exc, msgErro + "{@c}", cliente);

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
