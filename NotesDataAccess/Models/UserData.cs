using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesDataAccess.Models
{
    public class UserData
    {
        public int id { get; set; }

        public String uid { get; set; }

        public String username { get; set; }

        public String password { get; set; }

        public UserData() { }

        public UserData(int id, string uid, string username, string password)
        {
            this.id = id;
            this.uid = uid;
            this.username = username;
            this.password = password;
        }
    }
}
