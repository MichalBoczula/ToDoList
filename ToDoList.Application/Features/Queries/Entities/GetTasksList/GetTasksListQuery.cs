using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Features.Queries.Entities.GetTasksList
{
    public class GetTasksListQuery : IRequest<List<TasksListVm>>
    {
    }
}
