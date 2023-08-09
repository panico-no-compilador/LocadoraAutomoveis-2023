using LocadoraAutomoveis.Aplicacao.ModuloAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloClientes;
using LocadoraAutomoveis.Aplicacao.ModuloCuponsParceiros;
using LocadoraAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Aplicacao.ModuloPlanosCobranca;
using LocadoraAutomoveis.Aplicacao.ModuloTaxasServicos;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloClientes;
using LocadoraAutomoveis.Dominio.ModuloCuponsParceiros;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxasServicos;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloClientes;
using LocadoraAutomoveis.Infra.Orm.ModuloCuponsParceiros;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanosCobranca;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxasServicos;
using LocadoraAutomoveis.WinApp.ModuloAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloClientes;
using LocadoraAutomoveis.WinApp.ModuloCuponsParceiros;
using LocadoraAutomoveis.WinApp.ModuloGrupoAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloPlanosCobranca;
using LocadoraAutomoveis.WinApp.ModuloTaxasServicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public class InversaoControle : IInversaoControle
    {
        private ServiceProvider container;
        public InversaoControle()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var servicos = new ServiceCollection();

            servicos.AddDbContext<IContextoPersistencia, LocadoraAutomoveisDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            servicos.AddTransient<ControladorGrupoAutomoveis>();
            servicos.AddTransient<ServicoGrupoAutomoveis>();
            servicos.AddTransient<IValidadorGrupoAutomoveis, ValidadorGrupoAutomoveis>();
            servicos.AddScoped<IRepositorioGrupoAutomoveis, RepositorioGrupoAutomoveisOrm>();

            servicos.AddTransient<ControlardorCliente>();
            servicos.AddTransient<ServicoCliente>();
            servicos.AddTransient<IValidadorCliente, ValidadorCliente>();
            servicos.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();

            servicos.AddTransient<ControladorCupom>();
            servicos.AddTransient<ServicoCupom>();
            servicos.AddTransient<IValidadorCupom, ValidadorCupom>();
            servicos.AddScoped<IRepositorioCupom, RepositorioCupomEmOrm>();

            servicos.AddTransient<ControladorParceiro>();
            servicos.AddTransient<ServicoParceiro>();
            servicos.AddTransient<IValidadorParceiro, ValidadorParceiro>();
            servicos.AddScoped<IRepositorioParceiro, RepositorioParceiroEmOrm>();

            servicos.AddTransient<ControladorPlanoCobranca>();
            servicos.AddTransient<ServicoPlanoCobranca>();
            servicos.AddTransient<IValidadorPlanoCobranca, ValidadorPlanoCobranca>();
            servicos.AddScoped<IRepositorioPlanoCobranca, RepositorioPlanoCobrancaOrm>();

            servicos.AddTransient<ControladorTaxasServicos>();
            servicos.AddTransient<ServicoTaxasServicos>();
            servicos.AddTransient<IValidadorTaxasServicos, ValidadorTaxasServicos>();
            servicos.AddScoped<IRepositorioTaxasServicos, RepositorioTaxasServicosOrm>();

            servicos.AddTransient<ControladorAutomoveis>();
            servicos.AddTransient<ServicoAutomoveis>();
            servicos.AddTransient<IValidadorAutomoveis, ValidadorAutomoveis>();
            servicos.AddScoped<IRepositorioAutomoveis, RepositorioAutomoveisOrm>();

            container = servicos.BuildServiceProvider();
        }
        public T Get<T>()
        {
            return container.GetService<T>();
        }
    }
}
