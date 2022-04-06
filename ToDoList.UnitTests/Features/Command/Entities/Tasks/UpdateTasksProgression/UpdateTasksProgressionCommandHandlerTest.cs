using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Features.Commands.Entities.Tasks.UpdateTasksProgression;
using ToDoList.Persistance.Context;
using ToDoList.UnitTests.Common.TestBase;
using Xunit;

namespace ToDoList.UnitTests.Features.Command.Entities.Tasks.UpdateTasksProgression
{
   [Collection("CommandCollection2")]
    public class UpdateTasksProgressionCommandHandlerTest
    {
        private readonly ToDoDbContext _context;

        public UpdateTasksProgressionCommandHandlerTest(CommandTestBase testBase)
        {
            _context = testBase.Context;
        }

        [Fact]
        public async Task ShouldReturnJuniorStats()
        {
            //arrange
            var handler = new UpdateTasksProgressionCommandHandler(_context);
            //act
            var result = await handler.Handle(
                new UpdateTasksProgressionCommand() 
                { TaskId = 1, Model = new UpdateTasksProgressionCommandDto() { ProgressionId = 1} },
                CancellationToken.None);
            //assert
            result.Should().Be(1);
            var task = _context.Tasks.SingleOrDefault(x => x.Id == 1);
            task.TaskProgressionLevelsId.Should().Be(1);
        }
    }
}