using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Contracts;
using ToDoList.Domain.Model.Dictionary;
using ToDoList.Domain.Model.Entities;
using ToDoList.Persistance.Seed;

namespace ToDoList.Persistance.Context
{
    public class ToDoDbContext : DbContext, IToDoDbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Domain.Model.Entities.ToDoList> Lists { get; set; }
        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<TaskProgressionLevels> TaskProgressionLevels { get; set; }

        public ToDoDbContext([NotNull] DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.CreateBoardsSeed();
            modelBuilder.CreateListsSeed();
            modelBuilder.CreateTasksSeed();
            modelBuilder.CreateTaskProgressionLevelsSeed();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
