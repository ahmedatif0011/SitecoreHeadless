using SitecoreHeadless.Infrastructure.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Infrastructure.Persistence.UnitOfWork
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;

        public ApplicationDbContext _dbContext;
        private SqlConnection _con;
        public DbFactory(ApplicationDbContext dbContextFactory, SqlConnection con)
        {
            _dbContext = dbContextFactory;
            _con = con;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                try
                {
                    _dbContext.Database.CloseConnection();
                }
                catch (Exception)
                {

                }
                try
                {
                    _dbContext.ClearConnectionPool();
                }
                catch (Exception)
                {

                }
                _dbContext.Dispose();
            }

            if (_con.State == System.Data.ConnectionState.Open)
                _con.Close();
            _con.Dispose();
            GC.Collect();
            GC.WaitForFullGCApproach();
        }
    }
}
