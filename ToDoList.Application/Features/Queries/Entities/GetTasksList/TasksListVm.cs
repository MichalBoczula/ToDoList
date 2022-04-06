using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Features.Queries.Entities.GetTasksList
{
    public class TasksListVm
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<TasksDto> Tasks{ get; set; }
    }
}
