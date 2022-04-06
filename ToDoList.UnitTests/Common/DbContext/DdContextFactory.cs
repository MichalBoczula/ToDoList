using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Persistance.Context;

namespace JobsCatalog.UnitTests.Common.DbContext
{
    public static class DbContexFactory
    {
        public static Mock<ToDoDbContext> CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var mock = new Mock<ToDoDbContext>(options) { CallBase = true };
            mock.Object.Database.EnsureCreated();
            mock.Object.SaveChanges();
            return mock;
        }

        public static void CleanUp(ToDoDbContext contextTransaction)
        {
            contextTransaction.Database.EnsureDeleted();
            contextTransaction.Dispose();
        }
    }
}
