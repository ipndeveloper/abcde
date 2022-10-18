using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CGM.CashExchange.Core.Domain.Entities;

namespace CGM.Infrastructure.Persistence.SqlServer.Contexts
{
    public class CashExchangeContext : DbContext
    {
        public CashExchangeContext(DbContextOptions<CashExchangeContext> options)
        : base(options)
        {


        }
        public DbConnection GetCurrentConnection()
        {

            return base.Database.GetDbConnection();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Operacion> Ficha { get; set; }
    }
}
