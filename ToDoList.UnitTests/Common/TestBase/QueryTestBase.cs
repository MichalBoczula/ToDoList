using JobsCatalog.UnitTests.Common.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Persistance.Context;
using Xunit;

namespace JobsCatalog.UnitTests.Common.TestBases
{
    public class QueryTestBase : IDisposable
    {
        public ToDoDbContext Context { get; set; }

        public QueryTestBase()
        {
            Context = DbContexFactory.CreateDbContext().Object;
        }

        public void Dispose()
        {
            DbContexFactory.CleanUp(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestBase>
    {
    }
}
