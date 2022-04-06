using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTaskName;
using ToDoList.Persistance.Context;
using ToDoList.UnitTests.Common.TestBase;
using Xunit;

namespace ToDoList.UnitTests.Features.Command.Entities.Tasks.UpdateTaskName
{
    [Collection("CommandCollection1")]
    public class UpdateTaskNameCommandHandlerTests
    {
        private readonly ToDoDbContext _context;

        public UpdateTaskNameCommandHandlerTests(CommandTestBase testBase)
        {
            _context = testBase.Context;
        }

        [Fact]
        public async Task ShouldReturnJuniorStats()
        {
            //arrange
            var handler = new UpdateTaskNameCommandHandler(_context);
            //act
            var result = await handler.Handle(
                new UpdateTaskNameCommand() { Id= 1, Model = new UpdateTaskNameCommandDto() { TaskName = "test"}},
                CancellationToken.None);
            //assert
            result.Should().Be(1);
            var task = _context.Tasks.SingleOrDefault(x => x.Id == 1);
            task.Name.Should().Be("test");
        }
    }
}
