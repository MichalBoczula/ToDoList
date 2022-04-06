using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Contracts;

namespace ToDoList.Application.Features.Queries.Statistics.CountAverageTime
{
    public class CountAverageTimeQueryHandler : IRequestHandler<CountAverageTimeQuery, CountAverageTimeQueryVm>
    {
        private readonly IToDoDbContext _context;

        public CountAverageTimeQueryHandler(IToDoDbContext context)
        {
            _context = context;
        }

        public async Task<CountAverageTimeQueryVm> Handle(CountAverageTimeQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Lists
                .Join(_context.Tasks,
                    l => l.Id,
                    t => t.ListId,
                    (l, t) => new { l.Name, t });

            if (request.ListName.ToLower().Trim() != "all")
            {
                query = query.Where(x => x.Name.ToLower() == request.ListName.ToLower().Trim());
            }

            var result = await query.GroupBy(x => x.Name)
                .Select(x => new CountAverageTimeQueryDto
                {
                    ListName = x.Key,
                    AvgDuration = (int)x.Average(x => x.t.Duration),
                    AvgEstimation = (int)x.Average(x => x.t.Estimation),
                    SumDuration = (int)x.Sum(x => x.t.Duration),
                    SumEstimation = (int)x.Sum(x => x.t.Estimation),
                }).ToListAsync(cancellationToken);

            return result.Count < 1 ? null :  new CountAverageTimeQueryVm() { Model = result };
        }
    }
}
