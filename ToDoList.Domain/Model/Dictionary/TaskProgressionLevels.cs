using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model.Entities;

namespace ToDoList.Domain.Model.Dictionary
{
    public class TaskProgressionLevels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDoTask> Tasks { get; set; }
    }
}
