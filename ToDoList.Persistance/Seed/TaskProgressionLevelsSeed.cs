using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model.Dictionary;

namespace ToDoList.Persistance.Seed
{
    public static class TaskProgressionLevelsSeed
    {
        public static void CreateTaskProgressionLevelsSeed(this ModelBuilder modelBuilder)
        {
            var progress1 = new TaskProgressionLevels { Id = 1, Name = "ToDo" };
            var progress2 = new TaskProgressionLevels { Id = 2, Name = "InProgress" };
            var progress3 = new TaskProgressionLevels { Id = 3, Name = "Done" };
            
            modelBuilder.Entity<TaskProgressionLevels>()
              .HasData(progress1);
            modelBuilder.Entity<TaskProgressionLevels>()
              .HasData(progress2);
            modelBuilder.Entity<TaskProgressionLevels>()
              .HasData(progress3);
        }
    }
}
