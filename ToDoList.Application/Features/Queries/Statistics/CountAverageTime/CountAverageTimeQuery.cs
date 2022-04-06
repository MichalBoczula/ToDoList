using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Features.Queries.Statistics.CountAverageTime
{
    public class CountAverageTimeQuery : IRequest<CountAverageTimeQueryVm>
    {
        public string ListName{ get; set; }
    }
}
