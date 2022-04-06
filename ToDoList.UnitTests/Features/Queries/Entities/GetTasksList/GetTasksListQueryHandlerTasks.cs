using FluentAssertions;
using JobsCatalog.UnitTests.Common.TestBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Features.Queries.Entities.GetTasksList;
using ToDoList.Persistance.Context;
using Xunit;

namespace ToDoList.UnitTests.Features.Queries.GetTasksList
{
    [Collection("QueryCollection")]
    public class GetTasksListQueryHandlerTasks
    {
        private readonly ToDoDbContext _context;

        public GetTasksListQueryHandlerTasks(QueryTestBase testBase)
        {
            _context = testBase.Context;
        }

        [Fact]
        public async Task ShouldReturnList()
        {
            var handler = new GetTasksListQueryHandler(_context);
            var result = await handler.Handle(new GetTasksListQuery(), CancellationToken.None);
            result.Should().BeOfType<List<TasksListVm>>();
            result.Should().HaveCount(3);
            result.ForEach(x =>
            {
                x.Id.Should().BeGreaterThan(0);
                x.Name.Should().NotBeNullOrWhiteSpace();
                x.Tasks.Should().HaveCount(3);
                x.Tasks.ForEach(task =>
                {
                    task.Id.Should().BeGreaterThan(0);
                    task.Name.Should().NotBeNullOrWhiteSpace();
                    task.ProgressName.Should().NotBeNullOrWhiteSpace();
                    task.Duration.Should().BeGreaterThanOrEqualTo(0);
                    task.Estimation.Should().BeGreaterThan(0);
                });
            });
        }
    }
}
