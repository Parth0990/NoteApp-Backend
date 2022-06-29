using NotesDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesDataAccess.DBClasses;
using System.Data.SqlClient;
namespace NotesDataAccess.DBClasses
{
    public class UserDBClass
    {
        SqlCommand cmd = null;
        SqlDataReader dataReader = null;
        string query;
        UserData ud = new UserData();
        public int CheckUsername(string username)
        {
            Connection.Connect();
            int i = 0;
            query = $"select * from userData where username='{username}'";
            cmd = new SqlCommand(query, Connection.cnn);
            dataReader = cmd.ExecuteReader();
            if(dataReader.Read())
            {
                i++;
            }
            Connection.Disconnect();
            return i;
        }

        public bool CheckPassword(string username,string password)
        {
            Connection.Connect();
            String dbPass = null;
            bool status = false;
            query = $"select password from userData where username='{username}'";
            cmd = new SqlCommand(query, Connection.cnn);
            dataReader = cmd.ExecuteReader();
            while(dataReader.Read())
            {
                dbPass = dataReader.GetValue(0).ToString().Trim();
            }
            if(password==dbPass)
            {
                status=true;
            }
            Connection.Disconnect();
            return status;
        }

        public UserData GetData(string username)
        {
            Connection.Connect();
            UserData data = null;
            query = $"select * from userData where username='{username}'";
            cmd = new SqlCommand(query, Connection.cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                data = new UserData(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString().Trim(), dataReader.GetValue(2).ToString().Trim(), dataReader.GetValue(3).ToString().Trim());
            }
            Connection.Disconnect();
            return data;

        }

        public int AddUser(UserData user)
        {
            Connection.Connect();
            int i = 0;
            //insert into userData values('000112','Parth','1234')
            query = $"insert into userData values('{user.uid}','{user.username}','{user.password}')";
            cmd = new SqlCommand(query, Connection.cnn);
            i = cmd.ExecuteNonQuery();
            Connection.Disconnect();
            return i;
        }

    }
}
