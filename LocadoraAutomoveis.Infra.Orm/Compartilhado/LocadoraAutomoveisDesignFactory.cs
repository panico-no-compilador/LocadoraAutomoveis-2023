using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.Compartilhado
{
    internal class LocadoraAutomoveisDesignFactory : IDesignTimeDbContextFactory<LocadoraAutomoveisDbContext>
    {
        public LocadoraAutomoveisDbContext CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraAutomoveisDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new LocadoraAutomoveisDbContext(optionsBuilder.Options);
        }
    }
}
