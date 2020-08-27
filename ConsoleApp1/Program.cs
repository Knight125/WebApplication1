using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=logcoptestdbserver.database.windows.net;Initial Catalog=LogcopTestDb;User ID=kAdminDb;Password=Ohio!Ohio!";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            //insertData(cnn);
            //String Output = getData(cnn);
            //MessageBox.Show(Output);
            readCsvAndInsertDb(cnn);

            cnn.Close();

            
        }
        private static void readCsvAndInsertDb(SqlConnection cnn)
        {
            String fileName = "WEO_Data.csv";
            using var reader = new StreamReader(fileName);
            Console.WriteLine("done start");
            while (!reader.EndOfStream)
            {

                var line = reader.ReadLine();
                var values = line.Split(',');
                if (values.Length == 13)
                {
                    String Country = values[0].Replace("'", "");
                    String Subject_Descriptor = values[1].Replace("'", "");
                    String Units = values[2].Replace("'", "");
                    String Scale = values[3].Replace("'", "");
                    try
                    {
                        double y2012; 
                        double.TryParse(values[4], out y2012);
                        double y2013;
                        double.TryParse(values[5], out y2013);
                        double y2014;
                        double.TryParse(values[6], out y2014);
                        double y2015;
                        double.TryParse(values[7], out y2015);
                        double y2016;
                        double.TryParse(values[8], out y2016);
                        double y2017;
                        double.TryParse(values[9], out y2017);
                        double y2018;
                        double.TryParse(values[10], out y2018);
                        double y2019;
                        double.TryParse(values[11], out y2019);
                        int Estimates_Start_After; 
                        int.TryParse(values[12],  out Estimates_Start_After);

                        insertCountryGDPData(cnn, Country, Subject_Descriptor, Units, Scale,
                    y2012, y2013, y2014, y2015, y2016, y2017, y2018, y2019, Estimates_Start_After);
                    }
                    catch(System.FormatException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else
                {
                    Console.WriteLine("line has wrong length: " + line);
                }
            }
        }

        private static void insertCountryGDPData(SqlConnection cnn, String Country, String Subject_Descriptor, String Units, String Scale,
            double y2012, double y2013, double y2014, double y2015, double y2016, double y2017, double y2018, double y2019, int Estimates_Start_After)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "INSERT INTO gdpVsDebt (Country, Subject_Descriptor,Units,Scale,y2012,y2013,y2014,y2015,y2016,y2017,y2018,y2019," +
                "Estimates_Start_After) VALUES('" + Country + "','" + Subject_Descriptor + "','" + Units + "','" +Scale+"',"+ y2012 + "," + y2013 + "," + y2014 + "," + y2015 + "," + y2016 + "," +
                +y2017 + "," + y2018 + "," + y2019 + "," + Estimates_Start_After + ")";
            Console.WriteLine(sql);
            SqlCommand command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
