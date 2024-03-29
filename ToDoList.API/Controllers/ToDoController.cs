﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Controllers.Common;
using ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTaskName;
using ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTasksProgression;
using ToDoList.Application.Features.Queries.Entities.GetTasksList;
using ToDoList.Application.Features.Queries.Statistics.CountAverageTime;

namespace ToDoList.API.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class ToDoController : BaseController
    {
        [HttpGet("ToDoBoard")]
        public async Task<ActionResult<List<TasksListVm>>> GetBoard()
        {
            var vm = await Mediator.Send(new GetTasksListQuery());
            return Ok(vm);
        }

        [HttpGet("Stats/{listName}")]
        public async Task<ActionResult<CountAverageTimeQueryVm>> GetStats(string listName)
        {
            var vm = await Mediator.Send(new CountAverageTimeQuery() { ListName = listName});
            return vm is null ? NotFound() : Ok(vm);
        }

        [HttpPut("task/{id}/changeName")]
        public async Task<ActionResult> ChangeName(int id, [FromBody] UpdateTaskNameCommandDto model)
        {
            var vm = await Mediator.Send(new UpdateTaskNameCommand() { Id = id, Model = model});
            return vm is null ? NotFound() : NoContent();
        }

        [HttpPut("task/{id}/changeProgression")]
        public async Task<ActionResult> ChangeProgression(int id, [FromBody] UpdateTasksProgressionCommandDto model)
        {
            var vm = await Mediator.Send(new UpdateTasksProgressionCommand() { TaskId= id, Model = model });
            return vm is null ? NotFound() : NoContent();
        }
    }
}
