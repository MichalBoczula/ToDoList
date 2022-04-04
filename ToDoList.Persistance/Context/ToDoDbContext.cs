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
        public IQueryable<Board> Boards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IQueryable<Domain.Model.Entities.ToDoList> IToDoDbContext.ToDoLists { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IQueryable<ToDoTask> IToDoDbContext.ToDoTasks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
