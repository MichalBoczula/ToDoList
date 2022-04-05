using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Queries.Entities.GetTasksList
{
    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, List<TasksListDto>>
    {
        private readonly IToDoDbContext _context;

        public GetTasksListQueryHandler(IToDoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TasksListDto>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {

            if (request.ListId != 0)
            {
                var result = await _context.Lists.Where(x => x.Id == request.ListId)
                    .Select(x => new TasksListDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Tasks = x.ToDoTasks.Select(y => new TasksDto
                        {
                            Id = y.Id,
                            Name = y.Name,
                            ProgressName = _context.TaskProgressionLevels
                                .Where(progression => progression.Id == y.TaskProgressionLevelsId)
                                .Select(x => x.Name).SingleOrDefault(),
                            Duration = y.Duration,
                            Estimation = y.Estimation
                        }).ToList()
                    }).ToListAsync(cancellationToken);
                return result;
            }
            else
            {
                var result = await _context.Lists.Select(x => new TasksListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Tasks = x.ToDoTasks.Select(y => new TasksDto
                    {
                        Id = y.Id,
                        Name = y.Name,
                        ProgressName = _context.TaskProgressionLevels
                                .Where(progression => progression.Id == y.TaskProgressionLevelsId)
                                .Select(x => x.Name).SingleOrDefault(),
                        Duration = y.Duration,
                        Estimation = y.Estimation
                    }).ToList()
                }).ToListAsync(cancellationToken);
                var ProgressName = _context.TaskProgressionLevels.ToList();
                return result;
            }
        }
    }
}
