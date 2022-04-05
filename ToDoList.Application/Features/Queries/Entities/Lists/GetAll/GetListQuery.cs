using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ToDoList.Application.Features.Queries.Entities.Lists.GetAll
{
    public class GetListQuery : IRequest<List<ListDto>>
    {
    }
}
