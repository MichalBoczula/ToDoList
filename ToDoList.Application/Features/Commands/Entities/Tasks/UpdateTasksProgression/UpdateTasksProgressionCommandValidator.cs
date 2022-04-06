using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTasksProgression
{
    public class UpdateTasksProgressionCommandValidator : AbstractValidator<UpdateTasksProgressionCommand>
    {
        private readonly IToDoDbContext _dbcontext;

        public UpdateTasksProgressionCommandValidator(IToDoDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            RuleFor(x => x.TaskId).Custom((taskId, context) =>
            {
                var task = _dbcontext.Tasks.SingleOrDefault(x => x.Id == taskId);
                if (task is null)
                {
                    context.AddFailure($"Task with {taskId} doesn't exist");
                }
            });
            RuleFor(x => x.Model.ProgressionId).Custom((progressionId, context) =>
            {
                var level = _dbcontext.TaskProgressionLevels.SingleOrDefault(x => x.Id == progressionId);
                if (level is null)
                {
                    context.AddFailure($"Progression Level with {progressionId} doesn't exist");
                }
            });
        }
    }
}
