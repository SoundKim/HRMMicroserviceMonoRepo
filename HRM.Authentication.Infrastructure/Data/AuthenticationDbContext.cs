using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Authentication.Infrastructure.Entity;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HRM.Authentication.ApplicationCore.Data
{
    public class AuthenticationDbContext : DbContext
    {

        IDbConnection dbConnection;

        public AuthenticationDbContext()
        {
            dbConnection = new SqlConnection("Data Source=localhost,1433;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Admin@1234;TrustServerCertificate=True");
        }

        public IDbConnection GetConnection()
        {
            return dbConnection;
        }

    }
}
