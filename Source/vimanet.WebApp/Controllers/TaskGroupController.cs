using Microsoft.AspNetCore.Http;
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
    public class TaskGroupController : ControllerBase
    {
        private readonly ITaskGroupRepository _taskGroups;

        public TaskGroupController(ITaskGroupRepository taskGroups)
        { 
            _taskGroups = taskGroups;
        }

        [HttpGet]
        public IEnumerable<TaskGroupOverviewContext> Overview()
        {
            return _taskGroups.GetOverview();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _taskGroups.Delete(id);
                _taskGroups.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpGet]
        public TaskGroupWithTasksContent GetGroupContext(int id)
        {
            return _taskGroups.GetTaskGroupContext(id);
        }

        [HttpPut]
        public IActionResult Update(int id, TaskGroup group)
        {
            if (id != group.Id)
                return BadRequest();

            if (id == 0)
            {
                try
                {
                    _taskGroups.Add(group);
                    _taskGroups.SaveChanges();
                }
                catch
                {
                    return BadRequest();
                }
                return Ok(group.Id);
            }

            try
            {
                _taskGroups.Update(group);
                _taskGroups.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
