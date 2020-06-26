using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using vimanet.DataAccess.Entities;
using vimanet.DataAccess.Repositories;
using vimanet.DataAccess.Repositories.Contexts;

namespace vimanet.Controllers
{
    [ApiController]
    [Route("{controller}/{action}/{id?}")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _users;
        public UsersController(IUserRepository users)
        {
            _users = users;
        }

        [HttpGet]
        public UserInfoContext Get(int id)
        {
            var context = _users.GetInfo(id);
            return context;
        }


        [HttpGet]
        public IEnumerable<UserInfoContext> All()
        {
            var context = _users.GetInfoAll();
            return context;
        }



        [HttpPut]
        public IActionResult Update(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();
            try
            {
                if (id == 0)
                    _users.Add(user);
                else
                    _users.Update(user);
                
                _users.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _users.Delete(id);
                _users.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
