using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_assignment
{
    class stockLevels
    {
        dataBaseConnection database = new dataBaseConnection();
        public string checkStockLevels()
        {
            string outOfStock = null;

            string sqlStock = "SELECT Name,Stock FROM Coffee WHERE Stock <= Trigger_Quantity";
            var cmd = database.dataConnection(sqlStock);

            var data = database.parameters();
            int dataCount = data.Tables[0].Rows.Count;

            for(var i = 0; i < dataCount; i++)
            {
                outOfStock += "Coffee: " + data.Tables[0].Rows[i].ItemArray[0].ToString() + "Currently in stock: " + data.Tables[0].Rows[i].ItemArray[1].ToString() + "\n";
            }

            return outOfStock;
        }
    }
}
