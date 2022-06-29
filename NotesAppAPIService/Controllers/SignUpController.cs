using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NotesDataAccess.DBClasses;
using NotesDataAccess.Models;

namespace NotesAppAPIService.Controllers
{
    public class SignUpController : ApiController
    {
        UserDBClass ud = new UserDBClass();

        //To register user
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody] UserData data)
        {
            if (ud.CheckUsername(data.username) == 0)
            {
                if (ud.AddUser(data) > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ud.GetData(data.username));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "User Already Exist");
            }
        }
    }
}
