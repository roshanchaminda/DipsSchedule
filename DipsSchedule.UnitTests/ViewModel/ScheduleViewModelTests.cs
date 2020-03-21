using System;
using System.Threading.Tasks;
using DipsSchedule.Services;
using DipsSchedule.UnitTests.Mocks.Services;
using DipsSchedule.ViewModels;
using DipsSchedule.ViewModels.Base;
using Xunit;

namespace DipsSchedule.UnitTests.ViewModel
{
    public class ScheduleViewModelTests
    {
        private readonly INavigationService navigationService;
        public ScheduleViewModelTests()
        {
            navigationService = ViewModelLocator.Resolve<INavigationService>();
        }

        [Fact]
        public void DaySelectCommandIsNotNullTest()
        {
            var scheduleService = new ScheduleMockService();
            var scheduleViewModel = new ScheduleViewModel(scheduleService, navigationService);

            Assert.NotNull(scheduleViewModel.DaySelectCommand);
        }

        [Fact]
        public void ScheduleSelectCommandIsNotNullTest()
        {
            var scheduleService = new ScheduleMockService();
            var scheduleViewModel = new ScheduleViewModel(scheduleService, navigationService);

            Assert.NotNull(scheduleViewModel.ScheduleSelectCommand);
        }

        [Fact]
        public async void ScheduleViewModelInitializeIsTrueTest()
        {
            var scheduleService = new ScheduleMockService();
            var scheduleViewModel = new ScheduleViewModel(scheduleService, navigationService);

            bool result = await scheduleViewModel.InitializeAsync(null);

            Assert.False(result);
        }

        [Fact]
        public async Task DaySelectCommandExecuteTest()
        {
            var scheduleService = new ScheduleMockService();
            var scheduleViewModel = new ScheduleViewModel(scheduleService, navigationService);

            await scheduleViewModel.InitializeAsync(null);

            scheduleViewModel.DaySelectCommand.Execute(1);

            Assert.NotNull(scheduleViewModel.DaySelectCommand);
        }

        [Fact]
        public void ScheduleSelectCommandExecuteTest()
        {
            var scheduleService = new ScheduleMockService();
            var scheduleViewModel = new ScheduleViewModel(scheduleService, navigationService);

            scheduleViewModel.ScheduleSelectCommand.Execute(1);

            Assert.NotNull(scheduleViewModel.ScheduleSelectCommand);
        }
    }
}
