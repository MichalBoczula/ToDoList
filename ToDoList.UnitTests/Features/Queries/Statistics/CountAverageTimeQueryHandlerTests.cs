using FluentAssertions;
using JobsCatalog.UnitTests.Common.TestBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Features.Queries.Statistics.CountAverageTime;
using ToDoList.Persistance.Context;
using Xunit;

namespace ToDoList.UnitTests.Features.Queries.Statistics
{
    [Collection("QueryCollection")]
    public class CountAverageTimeQueryHandlerTests
    {
        private readonly ToDoDbContext _context;

        public CountAverageTimeQueryHandlerTests(QueryTestBase testBase)
        {
            _context = testBase.Context;
        }

        [Fact]
        public async Task ShouldReturnAllStats()
        {
            //arrange
            var handler = new CountAverageTimeQueryHandler(_context);
            //act
            var result = await handler.Handle(
                new CountAverageTimeQuery() { ListName = "aLL" },
                CancellationToken.None);
            //assert
            result.Should().BeOfType<CountAverageTimeQueryVm>();
            result.Model.Count.Should().Be(3);
            result.Model[0].ListName.Should().Be("House Duties");
            result.Model[0].AvgDuration.Should().Be(1);
            result.Model[0].AvgEstimation.Should().Be(4);
            result.Model[0].SumDuration.Should().Be(5);
            result.Model[0].SumEstimation.Should().Be(12);
            result.Model[1].ListName.Should().Be("Job");
            result.Model[1].AvgDuration.Should().Be(3);
            result.Model[1].AvgEstimation.Should().Be(5);
            result.Model[1].SumDuration.Should().Be(9);
            result.Model[1].SumEstimation.Should().Be(17);
            result.Model[2].ListName.Should().Be("Other");
            result.Model[2].AvgDuration.Should().Be(8);
            result.Model[2].AvgEstimation.Should().Be(7);
            result.Model[2].SumDuration.Should().Be(25);
            result.Model[2].SumEstimation.Should().Be(23);
        }

        [Fact]
        public async Task ShouldReturnJuniorStats()
        {
            //arrange
            var handler = new CountAverageTimeQueryHandler(_context);
            //act
            var result = await handler.Handle(
                new CountAverageTimeQuery() { ListName = "House Duties" },
                CancellationToken.None);
            //assert
            result.Should().BeOfType<CountAverageTimeQueryVm>();
            result.Model.Count.Should().Be(1);
            result.Model[0].ListName.Should().Be("House Duties");
            result.Model[0].AvgDuration.Should().Be(1);
            result.Model[0].AvgEstimation.Should().Be(4);
            result.Model[0].SumDuration.Should().Be(5);
            result.Model[0].SumEstimation.Should().Be(12);
        }

        [Fact]
        public async Task ShouldReturnMidStats()
        {
            //arrange
            var handler = new CountAverageTimeQueryHandler(_context);
            //act
            var result = await handler.Handle(
                new CountAverageTimeQuery() { ListName = "Job" },
                CancellationToken.None);
            //assert
            result.Should().BeOfType<CountAverageTimeQueryVm>();
            result.Model.Count.Should().Be(1);
            result.Model[0].ListName.Should().Be("Job");
            result.Model[0].AvgDuration.Should().Be(3);
            result.Model[0].AvgEstimation.Should().Be(5);
            result.Model[0].SumDuration.Should().Be(9);
            result.Model[0].SumEstimation.Should().Be(17);
        }

        [Fact]
        public async Task ShouldReturnSeniorStats()
        {
            //arrange
            var handler = new CountAverageTimeQueryHandler(_context);
            //act
            var result = await handler.Handle(
                new CountAverageTimeQuery() { ListName = "Other" },
                CancellationToken.None);
            //assert
            result.Should().BeOfType<CountAverageTimeQueryVm>();
            result.Model.Count.Should().Be(1);
            result.Model[0].ListName.Should().Be("Other");
            result.Model[0].AvgDuration.Should().Be(8);
            result.Model[0].AvgEstimation.Should().Be(7);
            result.Model[0].SumDuration.Should().Be(25);
            result.Model[0].SumEstimation.Should().Be(23);
        }

        [Fact]
        public async Task ShouldBeEmpty()
        {
            //arrange
            var handler = new CountAverageTimeQueryHandler(_context);
            //act
            var result = await handler.Handle(
                new CountAverageTimeQuery() { ListName = "empty" },
                CancellationToken.None);
            //assert
            result.Should().BeNull();
        }
    }
}
