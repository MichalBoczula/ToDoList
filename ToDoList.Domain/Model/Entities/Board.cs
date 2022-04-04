using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Model.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public List<ToDoList> ToDoLists { get; set; }
    }
}
