using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Model.Entities;

namespace ToDoList.Persistance.Seed
{
    public static class BoardSeed
    {
        public static void CreateBoardsSeed(this ModelBuilder modelBuilder)
        {
            var board = new Board { Id = 1, Name = "Board" };
            modelBuilder.Entity<Board>()
              .HasData(board);
        }
    }
}
