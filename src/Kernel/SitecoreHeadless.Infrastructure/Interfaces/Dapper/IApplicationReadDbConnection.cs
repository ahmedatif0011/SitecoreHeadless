using System.Data;

namespace SitecoreHeadless.Infrastructure.Interfaces.Dapper
{
    public interface IApplicationReadDbConnection
    {
        Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null);
        Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null);
    }
}
