using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace AP_assignment
{
    class dataBaseConnection2
    {
        public SqlCommand command;
        public SqlCommand dataConnection(string sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(); //new connection 
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adobr\Desktop\UsersDB.mdf"; //connection string 

            SqlCommand da = new SqlCommand(sql, conn); //new oledb command

            conn.Close();

            return command = da;//return command and expose it to parameter function

        }
        public DataSet parameters()
        {
            SqlDataAdapter dAdapter = new SqlDataAdapter();//new table adapter         
            dAdapter.SelectCommand = command;

            DataSet data = new DataSet();
            dAdapter.Fill(data);//fill data set with new data 
            return data;//return data to view
        }
    }
}