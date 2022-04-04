using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Controllers.Common;

namespace ToDoList.API.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class ToDoController : BaseController
    {
        //public async Task<ActionResult<ExperienceLevelVm>> GetExperienceLevels()
        //{
        //    var vm = await Mediator.Send(new ExperienceLevelQuery());
        //    return Ok(vm);
        //}
    }
}
