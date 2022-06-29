using NotesDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace NotesDataAccess.DBClasses
{
    public class NotesDBClass
    {
        NotesData nd = new NotesData();
        SqlCommand cmd = null;
        SqlDataReader dataReader = null;
        string query;
        public List<NotesData> fetchAllNotes(string uid)
        {
            Connection.Connect();
            query = $"select * from notesData where uid='{uid}' order by id";
            cmd = new SqlCommand(query, Connection.cnn);
            List<NotesData> arr = new List<NotesData>();
            dataReader = cmd.ExecuteReader();
            NotesData temp = null;
            while (dataReader.Read())
            {
                temp = new NotesData();
                temp.id = Convert.ToInt32(dataReader.GetValue(0));
                temp.uid = dataReader.GetValue(1).ToString().Trim();
                temp.noteid = dataReader.GetValue(2).ToString().Trim();
                temp.title = dataReader.GetValue(3).ToString().Trim();
                temp.note = dataReader.GetValue(4).ToString().Trim();
                temp.modifyDate = dataReader.GetValue(5).ToString().Trim();
                temp.createDate = dataReader.GetValue(6).ToString().Trim();
                arr.Add(temp);
            }
            Connection.Disconnect();
            return arr;
        }

        public int AddNote(NotesData note)
        {
            int i = 0;
            Connection.Connect();
            query = $"insert into notesData(uid,noteid,title,note) values('{note.uid}','{note.noteid}','{note.title}','{note.note}')";
            cmd = new SqlCommand(query, Connection.cnn);
            i = cmd.ExecuteNonQuery();
            Connection.Disconnect();
            return i;
        }

        public int DeleteNote(String noteid)
        {
            int i = 0;
            Connection.Connect();
            query = $"delete from notesData where noteid='{noteid}'";
            cmd = new SqlCommand(query, Connection.cnn);
            i = cmd.ExecuteNonQuery();
            Connection.Disconnect();
            return i;
        }

        public int checkNoteById(String noteid)
        {
            int i = 0;
            Connection.Connect();
            query = $"select * from notesData where noteid='{noteid}'";
            cmd = new SqlCommand(query, Connection.cnn);
            dataReader = cmd.ExecuteReader();
            if(dataReader.Read())
            {
                i++;
            }
            Connection.Disconnect();
            return i;
        }

        public int updateNoteById(String noteid, NotesData newNote)
        {
            int i = 0;
            Connection.Connect();
            query = $"update notesData set title='{newNote.title}',note='{newNote.note}',modifyDate = default where noteid='{noteid}'";
            cmd = new SqlCommand(query, Connection.cnn);
            i = cmd.ExecuteNonQuery();
           // update notesData set note = 'xyz', modifyDate = default where noteid = 'n52108741';
            Connection.Disconnect();
            return i;
        }
    }
}
