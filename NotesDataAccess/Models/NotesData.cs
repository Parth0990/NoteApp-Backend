using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesDataAccess.Models
{
    public class NotesData
    {
        public int id { get; set; }

        public String uid { get; set; }

        public String noteid { get; set; }

        public String title { get; set; }
        public String note { get; set; }
        public String modifyDate { get; set; }

        public String createDate { get; set; }

        public NotesData() { }

        public NotesData(int id, string uid, string noteid, string note, string modifyData, string createData)
        {
            this.id = id;
            this.uid = uid;
            this.noteid = noteid;
            this.note = note;
            this.modifyDate = modifyData;
            this.createDate = createData;
        }
    }
}
