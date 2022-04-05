using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Controllers.Common;
using ToDoList.Application.Features.Queries.Entities.Lists.GetAll;

namespace ToDoList.API.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class ToDoController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<ListDto>>> GetExperienceLevels()
        {
            var vm = await Mediator.Send(new GetListQuery());
            return Ok(vm);
        }
    }
}
