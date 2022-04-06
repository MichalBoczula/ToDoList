using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTasksProgression
{
    public class UpdateTasksProgressionCommand : IRequest<int?>
    {
        public int TaskId { get; set; }
        public UpdateTasksProgressionCommandDto Model { get; set; }
    }
}
