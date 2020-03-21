using System;
using System.Threading.Tasks;
using DipsSchedule.Services;
using DipsSchedule.ViewModels.Base;

namespace DipsSchedule.ViewModels
{
    public class ScheduleDetailViewModel : ViewModelBase
    {
        private const string PageTitleName = "Apointment";

        private readonly IScheduleService _scheduleService;

        private ScheduleItemViewModel scheduleItemViewModel;

        public ScheduleDetailViewModel(IScheduleService scheduleService)
        {
            this.PageTitle = PageTitleName;

            _scheduleService = scheduleService;

            ScheduleItemViewModel = new ScheduleItemViewModel();
        }

        public int ScheduleId { get; set; }

        public ScheduleItemViewModel ScheduleItemViewModel
        {
            get { return scheduleItemViewModel; }
            set
            {
                scheduleItemViewModel = value;
                OnPropertyChanged();
            }
        }

        public override async Task<bool> InitializeAsync(object navigationData)
        {
            IsBusy = true;

            ScheduleId = Convert.ToInt32(navigationData);

            await LoadScheduleData();

            IsBusy = false;

            return await base.InitializeAsync(navigationData);
        }

        private async Task LoadScheduleData()
        {
            ScheduleItemViewModel = await _scheduleService.GetScheduleItem(ScheduleId);
        }
    }
}
