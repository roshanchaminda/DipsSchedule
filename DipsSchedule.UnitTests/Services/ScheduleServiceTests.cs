using System;
using System.Threading.Tasks;
using DipsSchedule.UnitTests.Mocks.Services;
using Xunit;

namespace DipsSchedule.UnitTests.Services
{
    public class ScheduleServiceTests
    {
        public ScheduleServiceTests()
        {
        }

        [Fact]
        public async Task GetCurrentWeekData_Invoked()
        {
            var sceduleMockService = new ScheduleMockService();
            var currentWeek = await sceduleMockService.GetCurrentWeekData();

            Assert.NotNull(currentWeek);
        }

        [Fact]
        public async Task GetAllSchedules_Invoked()
        {
            var sceduleMockService = new ScheduleMockService();
            var allSchedules = await sceduleMockService.GetAllSchedules();

            Assert.NotNull(allSchedules);
        }

        [Fact]
        public async Task GetScheduleItem_Invoked()
        {
            var sceduleMockService = new ScheduleMockService();
            var schedule = await sceduleMockService.GetScheduleItem(1);

            Assert.NotNull(schedule);
        }

    }
}
