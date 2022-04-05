using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model.Dictionary;
using ToDoList.Domain.Model.Entities;

namespace ToDoList.Application.Contracts
{
    public interface IToDoDbContext
    {
        DbSet<Board> Boards { get; set; }
        DbSet<Domain.Model.Entities.ToDoList> Lists { get; set; }
        DbSet<ToDoTask> Tasks { get; set; }
        DbSet<TaskProgressionLevels> TaskProgressionLevels { get; set; }
    }
}
