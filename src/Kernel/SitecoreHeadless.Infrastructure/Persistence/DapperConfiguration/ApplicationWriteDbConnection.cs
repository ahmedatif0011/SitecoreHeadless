﻿using SitecoreHeadless.Infrastructure.Interfaces.Context;
using SitecoreHeadless.Infrastructure.Interfaces.Dapper;
using Dapper;
using System.Data;

namespace SitecoreHeadless.Infrastructure.Persistence.DapperConfiguration
{
    public class ApplicationWriteDbConnection : IApplicationWriteDbConnection
    {
        private readonly IApplicationSqlDbContext context;
        public ApplicationWriteDbConnection(IApplicationSqlDbContext context)
        {
            this.context = context;
        }
        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null)
        {
            return await context.Connection.ExecuteAsync(sql, param, transaction);
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null)
        {
            return (await context.Connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null)
        {
            return await context.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null)
        {
            return await context.Connection.QuerySingleAsync<T>(sql, param, transaction);
        }
    }
}
