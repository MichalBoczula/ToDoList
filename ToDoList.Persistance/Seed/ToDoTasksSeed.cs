using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model.Entities;

namespace ToDoList.Persistance.Seed
{
    public static class ToDoTasksSeed
    {
        public static void CreateTasksSeed(this ModelBuilder modelBuilder)
        {
            var task1 = new Domain.Model.Entities.ToDoTask { Id = 1, Name = "First task", ListId = 1, TaskProgressionLevelsId = 2, Duration = 5, Estimation = 7 };
            var task2 = new Domain.Model.Entities.ToDoTask { Id = 2, Name = "Second task", ListId = 1, TaskProgressionLevelsId = 1, Duration = 0, Estimation = 2 };
            var task3 = new Domain.Model.Entities.ToDoTask { Id = 3, Name = "Third Task", ListId = 1, TaskProgressionLevelsId = 1, Duration = 0, Estimation = 3 };
            var task4 = new Domain.Model.Entities.ToDoTask { Id = 4, Name = "Fourth task", ListId = 2, TaskProgressionLevelsId = 2, Duration = 3, Estimation = 10 };
            var task5 = new Domain.Model.Entities.ToDoTask { Id = 5, Name = "Fifth task", ListId = 2, TaskProgressionLevelsId = 1, Duration = 0, Estimation = 3 };
            var task6 = new Domain.Model.Entities.ToDoTask { Id = 6, Name = "Sixth Task", ListId = 2, TaskProgressionLevelsId = 3, Duration = 6, Estimation = 4 };
            var task7 = new Domain.Model.Entities.ToDoTask { Id = 7, Name = "Seventh task", ListId = 3, TaskProgressionLevelsId = 2, Duration = 15, Estimation = 15 };
            var task8 = new Domain.Model.Entities.ToDoTask { Id = 8, Name = "Eighth task", ListId = 3, TaskProgressionLevelsId = 3, Duration = 5, Estimation = 2 };
            var task9 = new Domain.Model.Entities.ToDoTask { Id = 9, Name = "Nineth Task", ListId = 3, TaskProgressionLevelsId = 3, Duration = 5, Estimation = 6 };

            modelBuilder.Entity<ToDoTask>()
              .HasData(task1);
            modelBuilder.Entity<ToDoTask>()
              .HasData(task2);
            modelBuilder.Entity<ToDoTask>()
              .HasData(task3);
            modelBuilder.Entity<ToDoTask>()
              .HasData(task4);
            modelBuilder.Entity<ToDoTask>()
              .HasData(task5);
            modelBuilder.Entity<ToDoTask>()
              .HasData(task6);
            modelBuilder.Entity<ToDoTask>()
              .HasData(task7);
            modelBuilder.Entity<ToDoTask>()
                .HasData(task8);
            modelBuilder.Entity<ToDoTask>()
                .HasData(task9);
        }
    }
}
