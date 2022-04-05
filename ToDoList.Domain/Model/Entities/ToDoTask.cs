using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model.Dictionary;

namespace ToDoList.Domain.Model.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskProgressionLevelsId { get; set; }
        public TaskProgressionLevels Progress { get; set; }
        public int Estimation { get; set; }
        public int Duration { get; set; }
        public int ListId { get; set; }
        public ToDoList List { get; set; }
    }
}
