using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTaskName
{
    public class UpdateTaskNameCommandValidator : AbstractValidator<UpdateTaskNameCommand>
    {
        private readonly IToDoDbContext _dbcontext;

        public UpdateTaskNameCommandValidator(IToDoDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            RuleFor(x => x.Id).Custom((taskId, context) =>
            {
                var task = _dbcontext.Tasks.SingleOrDefault(x => x.Id == taskId);
                if (task is null)
                {
                    context.AddFailure($"Task with {taskId} doesn't exist");
                }
            });
            RuleFor(x => x.Model.TaskName).NotEmpty();
        }
    }
}
