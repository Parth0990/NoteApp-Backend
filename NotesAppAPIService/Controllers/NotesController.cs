using NotesDataAccess.DBClasses;
using NotesDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NotesAppAPIService.Controllers
{
    public class NotesController : ApiController
    {
        NotesDBClass nd = new NotesDBClass();

        //fetch all notes from uid
        [HttpGet]
        public HttpResponseMessage GetNotes([FromUri] string uid)
        {
            if (nd.fetchAllNotes(uid).Count>0)
            {
                //return nd.fetchAllNotes(uid);
                return Request.CreateResponse(HttpStatusCode.OK, nd.fetchAllNotes(uid));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Notes Found");
            }
        }

        //add note
        [HttpPost]
        public HttpResponseMessage PostNote([FromBody]NotesData note)
        {
           // nd.AddNote(note);
            if(nd.AddNote(note)>0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, note);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Note not inserted");
            }
        }

        //delete note
        [HttpDelete]
        public HttpResponseMessage DeleteNote([FromUri] String noteid)
        {
            // nd.AddNote(note);
            if(nd.checkNoteById(noteid)>0)
            {
                if (nd.DeleteNote(noteid) > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Note deleted");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Note not inserted");
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Note does not exist");
            }
        }

        //update note
        [HttpPut]
        public HttpResponseMessage PutNote([FromUri] String noteid,[FromBody]NotesData newNote)
        {
            if (nd.checkNoteById(noteid) > 0)
            {
                if (nd.updateNoteById(noteid, newNote) > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Note Updated");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Note not inserted");
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Note does not exist");
            }
        }
    }
}
