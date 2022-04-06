using JobsCatalog.UnitTests.Common.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Persistance.Context;
using Xunit;

namespace ToDoList.UnitTests.Common.TestBase
{
    public class CommandTestBase : IDisposable
    {
        public ToDoDbContext Context { get; set; }

        public CommandTestBase()
        {
            Context = DbContexFactory.CreateDbContext().Object;
        }

        public void Dispose()
        {
            DbContexFactory.CleanUp(Context);
        }
    }

    [CollectionDefinition("CommandCollection1")]
    public class CommandCollection : ICollectionFixture<CommandTestBase>
    {
    }

    [CollectionDefinition("CommandCollection2")]
    public class CommandCollection2 : ICollectionFixture<CommandTestBase>
    {
    }
}
