using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTaskName
{
    public class UpdateTaskNameCommand : IRequest<int?>
    {
        public int Id { get; set; }
        public UpdateTaskNameCommandDto Model { get; set; }
    }
}
