using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace WindowsFormsApp1ConnDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=logcoptestdbserver.database.windows.net;Initial Catalog=LogcopTestDb;User ID=kAdminDb;Password=Ohio!Ohio!";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            insertData(cnn);
            String Output = getData(cnn);
            MessageBox.Show(Output);

          
            cnn.Close();

        }
        private String getData(SqlConnection cnn)
        {
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "Select * from Customers";

            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            Console.WriteLine("hello!");
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" +
                    dataReader.GetValue(1);
            }
            readCsvAndInsertDb(cnn);

            dataReader.Close();
            command.Dispose();
            return Output;
        }

        private void insertData(SqlConnection cnn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)"+
            "VALUES('Coco', 'Tonya Tomatoya', 'Smith', 'Stavanger', '4006', 'Norway'); ";
            SqlCommand command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
        }
        private void readCsvAndInsertDb(SqlConnection cnn)
        {
            String fileName = "WEO_Data.csv";
            using var reader = new StreamReader(fileName);
            Console.WriteLine("done start");
            while (!reader.EndOfStream)
            {
                
                var line = reader.ReadLine();
                Console.WriteLine("line: " + line);
                var values = line.Split(',');
                if (values.Length == 13)
                {
                    String Country = values[0];
                    String Subject_Descriptor = values[1];
                    String Units = values[2];
                    String Scale = values[3];
                    long y2012 = long.Parse(values[4]);
                    long y2013 = long.Parse(values[5]);
                    long y2014 = long.Parse(values[6]);
                    long y2015 = long.Parse(values[7]);
                    long y2016 = long.Parse(values[8]);
                    long y2017 = long.Parse(values[9]);
                    long y2018 = long.Parse(values[10]);
                    long y2019 = long.Parse(values[11]);
                    int Estimates_Start_After = int.Parse(values[12]);
                    insertCountryGDPData(cnn, Country, Subject_Descriptor, Units, Scale,
                    y2012, y2013, y2014, y2015, y2016, y2017, y2018, y2019, Estimates_Start_After);
                }
            }
        }

        private void insertCountryGDPData(SqlConnection cnn,String Country, String Subject_Descriptor, String Units, String Scale, 
            long y2012, long y2013, long y2014, long y2015, long y2016, long y2017, long y2018, long y2019, int Estimates_Start_After)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "INSERT INTO gdpVsDebt (Country, Subject_Descriptor,Units,Scale,y2012,y2013,y2014,y2015,y2016,y2017,y2018,y2019,"+
                "Estimates_Start_After) VALUES("+ Country + ","+ Subject_Descriptor + ","+ Units + ","+ y2012+ ","+y2013+","+y2014+","+y2015+","+y2016+","+
                +y2017+","+y2018+","+y2019+","+ Estimates_Start_After + ")";
            SqlCommand command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
