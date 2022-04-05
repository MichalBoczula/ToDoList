using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model.Entities;

namespace ToDoList.Application.Contracts
{
    public interface IToDoDbContext
    {
        IQueryable<Board> Boards { get; set; }
        IQueryable<Domain.Model.Entities.ToDoList> Lists { get; set; }
        IQueryable<ToDoTask> Tasks { get; set; }
    }
}
