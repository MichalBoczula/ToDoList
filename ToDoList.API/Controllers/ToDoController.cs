using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Controllers.Common;
using ToDoList.Application.Features.Queries.Entities.GetTasksList;
using ToDoList.Application.Features.Queries.Statistics.CountAverageTime;

namespace ToDoList.API.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class ToDoController : BaseController
    {
        [HttpGet("ToDoBoard")]
        public async Task<ActionResult<List<TasksListVm>>> GetLists()
        {
            var vm = await Mediator.Send(new GetTasksListQuery());
            return Ok(vm);
        }

        [HttpGet("Stats/{listName}")]
        public async Task<ActionResult<CountAverageTimeQueryVm>> GetExperienceLevels(string listName)
        {
            var vm = await Mediator.Send(new CountAverageTimeQuery() { ListName = listName});
            return vm is null ? NotFound() : Ok(vm);
        }
    }
}
