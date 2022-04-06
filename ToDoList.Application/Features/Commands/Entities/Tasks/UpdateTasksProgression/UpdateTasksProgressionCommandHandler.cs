using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTasksProgression
{
    public class UpdateTasksProgressionCommandHandler : IRequestHandler<UpdateTasksProgressionCommand, int?>
    {
        private readonly IToDoDbContext _context;

        public UpdateTasksProgressionCommandHandler(IToDoDbContext context)
        {
            _context = context;
        }

        public async Task<int?> Handle(UpdateTasksProgressionCommand request, CancellationToken cancellationToken)
        {
            var task = _context.Tasks.SingleOrDefault(x => x.Id == request.TaskId);
            task.TaskProgressionLevelsId= request.Model.ProgressionId;
            _context.Tasks.Update(task);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? result : null;
        }
    }
}
