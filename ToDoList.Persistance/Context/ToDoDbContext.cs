using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracts;
using ToDoList.Domain.Model.Entities;

namespace ToDoList.Persistance.Context
{
    public class ToDoDbContext : IToDoDbContext
    {
        public IQueryable<Board> Boards
        {
            get
            {
                var list = new List<Domain.Model.Entities.Board>
                {
                    new Board {Id = 1, Name = "Board"},
                };
                return list.AsQueryable();
            }
            set { this.Boards = value; }
        }
        public IQueryable<Domain.Model.Entities.ToDoList> Lists
        {
            get
            {
                var list = new List<Domain.Model.Entities.ToDoList>
                {
                    new Domain.Model.Entities.ToDoList {BoardId = 1, Id = 1, Name = "House Duties",},
                    new Domain.Model.Entities.ToDoList {BoardId = 1, Id = 2, Name = "Job",},
                    new Domain.Model.Entities.ToDoList {BoardId = 1, Id = 3, Name = "Other",}
                };
                return list.AsQueryable();
            }
            set { this.Lists = value; }
        }
        public IQueryable<ToDoTask> Tasks
        {
            get
            {
                var list = new List<Domain.Model.Entities.ToDoTask>
                {
                    new Domain.Model.Entities.ToDoTask {Id = 1, Name = "First task", ListId = 1, TaskProgressionLevelsId = 2, Duration = 5, Estimation = 7},
                    new Domain.Model.Entities.ToDoTask {Id = 2, Name = "Second task", ListId = 1, TaskProgressionLevelsId = 1, Duration = 0, Estimation = 2},
                    new Domain.Model.Entities.ToDoTask {Id = 3, Name = "Third Task", ListId = 1, TaskProgressionLevelsId = 1, Duration = 0, Estimation = 3},
                    new Domain.Model.Entities.ToDoTask {Id = 4, Name = "First task", ListId = 2, TaskProgressionLevelsId = 2, Duration = 3, Estimation = 10},
                    new Domain.Model.Entities.ToDoTask {Id = 5, Name = "Second task", ListId = 2, TaskProgressionLevelsId = 1, Duration = 0, Estimation = 3},
                    new Domain.Model.Entities.ToDoTask {Id = 6, Name = "Third Task", ListId = 2, TaskProgressionLevelsId = 3, Duration = 6, Estimation = 4},
                    new Domain.Model.Entities.ToDoTask {Id = 7, Name = "First task", ListId = 3, TaskProgressionLevelsId = 2, Duration = 15, Estimation = 15},
                    new Domain.Model.Entities.ToDoTask {Id = 8, Name = "Second task", ListId = 3, TaskProgressionLevelsId = 3, Duration = 5, Estimation = 2},
                    new Domain.Model.Entities.ToDoTask {Id = 9, Name = "Third Task", ListId = 3, TaskProgressionLevelsId = 3, Duration = 5, Estimation = 6}
                };
                return list.AsQueryable();
            }
            set { this.Tasks = value; }
        }
    }
}
