using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Contracts;
using ToDoList = ToDoList.Domain.Model.Entities.ToDoList;

namespace ToDoList.Application.Features.Queries.Entities.Lists.GetAll
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<ListDto>>
    {
        private readonly IToDoDbContext _context;

        public GetListQueryHandler(IToDoDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var list = _context.Lists.ToList();
            list.Add( new Domain.Model.Entities.ToDoList()
            {
               BoardId = 1, Id = 4, Name = "Sth"
            });
            _context.Lists = list.AsQueryable();
            var result = _context.Lists.Select(x => new ListDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return result;
        }
    }
}
