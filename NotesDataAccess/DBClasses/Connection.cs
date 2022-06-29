using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace NotesDataAccess.DBClasses
{
    public class Connection
    {
        public static String connection = "Data Source=HRMPC406\\SQLEXPRESS;Initial Catalog=NewsApp;Integrated Security=True";
        public static SqlConnection cnn =null;
        public static void Connect()
        {
            try
            {
                cnn = new SqlConnection(connection);
                cnn.Open();
            }
            catch(Exception e) { Console.WriteLine(e); }
        }
        public static void Disconnect()
        {
            if(cnn!=null)
            {
                cnn.Close();
            }
        }
    }
}
