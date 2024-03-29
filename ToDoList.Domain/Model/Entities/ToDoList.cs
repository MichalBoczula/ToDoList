﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Model.Entities
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDoTask> ToDoTasks{ get; set; }
        public Board Board { get; set; }
        public int BoardId { get; set; }
    }
}
