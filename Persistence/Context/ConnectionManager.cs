using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

using Application.Interfaces;
using Domain.Entities;


namespace Persistence.Context
{
    public class ConnectionManager : IConnectionManager
    {
        public const string Prueba_Key = "DefaultConnection";
        private readonly IConfiguration configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection CreateConnection(string keyName)
        {
            return new SqlConnection(ConfigurationExtensions.GetConnectionString(configuration, $"{keyName}"));
        }
    }
}
