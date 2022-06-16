using System;
using System.Data;

namespace Application.Interfaces
{
    public interface IConnectionManager
    {
        IDbConnection CreateConnection(string keyName);
    }
}
