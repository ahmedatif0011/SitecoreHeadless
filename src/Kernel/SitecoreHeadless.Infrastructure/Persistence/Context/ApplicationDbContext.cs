using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using SitecoreHeadless.Infrastructure.Interfaces.Context;
using Microsoft.Data.SqlClient;

namespace SitecoreHeadless.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationSqlDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public IDbConnection Connection => throw new NotImplementedException();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IApplicationSqlDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  

        }
        public void ClearConnectionPool()
        {
            var connectionString = Database.GetConnectionString();
            SqlConnection con = new SqlConnection(connectionString);
            // Clear the connection pool
            SqlConnection.ClearPool(con);

        }
        #region Tables

        #endregion


    }
}
