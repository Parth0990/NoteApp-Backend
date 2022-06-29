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
    public class UserController : ApiController
    {

        UserDBClass ud = new UserDBClass();


        //To login in user
        [HttpPost]
        public HttpResponseMessage Login([FromBody]UserData data)
        {
            if(ud.CheckUsername(data.username)>0)
            {
                //check pass
                if (ud.CheckPassword(data.username, data.password))
                {
                    //success LOG IN
                   // return "Success";
                    return Request.CreateResponse(HttpStatusCode.OK, ud.GetData(data.username));
                }
                else
                {
                    //error wrong pass
                  //  return "Wrong Pass";
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Wrong credentials");
                }
            }
            else
            {
                //error not found user
               // return "Invalid User";
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Username");
            }
        }

    }
}
