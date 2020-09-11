using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithAPITemplate.Services
{
    public class Class
    {
        public List<GDPData> ReadAll()
        {
            String connectionString = @"Data Source=logcoptestdbserver.database.windows.net;Initial Catalog=LogcopTestDb;User ID=kAdminDb;Password=Ohio!Ohio!";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<GDPData>("Select * from gdpVsDebt").ToList();
            }
        }
    }
}
