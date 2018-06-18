using DFO_WebAPI.Models;
using DFO_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DFO_WebAPI.Controllers
{
    public class UserController : ApiController
    {
        UserRepository _repo { get; set; }
        public UserController()
        {
            _repo = new UserRepository();
        }
        public List<UserModel> Get()
        {
            return _repo.GetAllUsers();
        }

        public UserModel Get(int id)
        {
            return _repo.GetUserById(id);
        }

        public HttpResponseMessage Post(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateUser(user);
                var response = Request.CreateResponse<UserModel>(System.Net.HttpStatusCode.Created, user);
                return response;
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
