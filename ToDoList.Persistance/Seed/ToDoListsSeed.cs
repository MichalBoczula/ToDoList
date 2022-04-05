using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Persistance.Seed
{
    public static class ToDoListsSeed
    {
        public static void CreateListsSeed(this ModelBuilder modelBuilder)
        {
            var list1 = new Domain.Model.Entities.ToDoList { BoardId = 1, Id = 1, Name = "House Duties", };
            var list2 = new Domain.Model.Entities.ToDoList { BoardId = 1, Id = 2, Name = "Job", };
            var list3 = new Domain.Model.Entities.ToDoList { BoardId = 1, Id = 3, Name = "Other", };
            modelBuilder.Entity<Domain.Model.Entities.ToDoList>()
                .HasData(list1);
            modelBuilder.Entity<Domain.Model.Entities.ToDoList>()
                .HasData(list2);
            modelBuilder.Entity<Domain.Model.Entities.ToDoList>()
                .HasData(list3);
        }
    }
}