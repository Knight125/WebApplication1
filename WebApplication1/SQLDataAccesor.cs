using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class SQLDataAccesor
    {
        public SqlConnection sqlConnection;
        public List<GDPData> data;

        public SQLDataAccesor()
        {
            ConnectAndGetData();
        }
        public void ConnectAndGetData()
        {
            Console.WriteLine("Hello World!");
            ConnectToDb();
            data = GetData(sqlConnection);
            sqlConnection.Close();
        }

        private void ConnectToDb()
        {
            string connetionString;
            connetionString = @"Data Source=logcoptestdbserver.database.windows.net;Initial Catalog=LogcopTestDb;User ID=kAdminDb;Password=Ohio!Ohio!";
            sqlConnection = new SqlConnection(connetionString);
            sqlConnection.Open();
        }

        private List<GDPData> GetData(SqlConnection cnn)
        {
            List<GDPData> data = new List<GDPData>();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            sql = "Select * from gdpVsDebt";
            command = new SqlCommand(sql,cnn);
            dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                GDPData dataSql = new GDPData();
                dataSql.Country = (string)dataReader.GetValue(0);
                dataSql.SubjectDescriptor = (string)dataReader.GetValue(1);
                dataSql.Units = (string)dataReader.GetValue(2);
                dataSql.Scale = (string)dataReader.GetValue(3);
                dataSql.Y2012 = (double)dataReader.GetValue(4);
                dataSql.Y2013 = (double)dataReader.GetValue(5);
                dataSql.Y2014 = (double)dataReader.GetValue(6);
                dataSql.Y2015 = (double)dataReader.GetValue(7);
                dataSql.Y2016 = (double)dataReader.GetValue(8);
                dataSql.Y2017 = (double)dataReader.GetValue(9);
                dataSql.Y2018 = (double)dataReader.GetValue(10);
                dataSql.Y2019 = (double)dataReader.GetValue(11);
                dataSql.EstimatesStartAfter = (int)dataReader.GetValue(12);
                data.Add(dataSql);
            }
            return data;
        }
    }
}
