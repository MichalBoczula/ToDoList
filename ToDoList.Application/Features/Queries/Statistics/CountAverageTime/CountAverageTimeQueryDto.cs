using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Features.Queries.Statistics.CountAverageTime
{
    public class CountAverageTimeQueryDto
    {
        public string ListName { get; set; }
        public int AvgDuration { get; set; }
        public int AvgEstimation { get; set; }
        public int SumDuration { get; set; }
        public int SumEstimation { get; set; }
    }
}
