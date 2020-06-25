using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vimanet.DataAccess.Entities;
using vimanet.DataAccess.Repositories;

namespace vimanet.Controllers
{
    [ApiController]
    [Route("{controller}/{action}/{id?}")]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskRepository _tasks;
        
        public UserTaskController(IUserTaskRepository tasks)
        {
            _tasks = tasks;
        }

        [HttpPut]
        public IActionResult Update(int id, UserTask task)
        {
            if (id != task.Id)
                return BadRequest();

            if (id == 0)
            {
                try
                {
                    _tasks.Add(task);
                    _tasks.SaveChanges();
                }
                catch {
                    return BadRequest();
                }
                return NoContent();
            }

            try
            {
                _tasks.Update(task);
                _tasks.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var task = _tasks.GetById(id);
            if (task != null)
            {
                try
                {
                    _tasks.Delete(task);
                    _tasks.SaveChanges();
                }
                catch
                {
                    return BadRequest();
                }
            }

            return NoContent();
        }
    }
}
