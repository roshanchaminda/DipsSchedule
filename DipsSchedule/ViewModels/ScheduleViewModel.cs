using System;
using System.Collections.ObjectModel;
using DipsSchedule.ViewModels.Base;
using System.Linq;
using Xamarin.Forms;
using DipsSchedule.Enums;
using DipsSchedule.Services;
using DipsSchedule.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using DipsSchedule.Helpers;
using Xamarin.Forms.Internals;
using System.Windows.Input;

namespace DipsSchedule.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        private const string PageTitleName = "Schedule";

        private readonly IScheduleService _scheduleService;

        private readonly INavigationService _navigationService;

        private int currentIndex;

        private ObservableCollection<DateCellViewModel> weekDaysView;

        private ObservableCollection<Helpers.Grouping<ScheduleCategory, ScheduleItemViewModel>> scheduleItems;

        public ScheduleViewModel(IScheduleService scheduleService, INavigationService navigationService)
        {
            _scheduleService = scheduleService;

            _navigationService = navigationService;

            this.PageTitle = PageTitleName;

            SelectedDate = DateTime.Now;

            WeekDaysView = new ObservableCollection<DateCellViewModel>();

            SheduleList = new ObservableCollection<ScheduleItemViewModel>();

            DaySelectCommand = new Command(ExecuteDaySelectCommand, (x) => !IsBusy);

            ScheduleSelectCommand = new Command<int>(async (x) => await ExecuteScheduleSelectCommand(x));

        }

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                currentIndex = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DateCellViewModel> WeekDaysView
        {
            get { return weekDaysView; }
            set
            {
                weekDaysView = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate { get; set; }

        public IList<ScheduleItemViewModel> SheduleList { get; set; }

        public ObservableCollection<Helpers.Grouping<ScheduleCategory, ScheduleItemViewModel>> ScheduleItems
        {
            get { return scheduleItems; }
            set
            {
                scheduleItems = value;
                OnPropertyChanged();
            }
        }

        public Command DaySelectCommand { get; }

        public ICommand ScheduleSelectCommand { get; }

        public override async Task<bool> InitializeAsync(object navigationData)
        {
            IsBusy = true;

            await LoadSchedules();

            IsBusy = false;

            return await base.InitializeAsync(navigationData);
        }

        private void ExecuteDaySelectCommand(object selectedIndex)
        {
            int selectedCellIndex = Convert.ToInt32(selectedIndex);
            WeekDaysView.ToList().ForEach(c => c.IsSelectedCell = false);

            DateCellViewModel dateCellViewModel = WeekDaysView[selectedCellIndex];
            dateCellViewModel.IsSelectedCell = true;

            SelectedDate = dateCellViewModel.DateValue;

            LoadSchedulesForSelectedDate();
        }

        private void LoadSchedulesForSelectedDate()
        {
            var filterList = SheduleList.Where(d => d.ScheduleDate.Date == SelectedDate.Date).OrderBy(item => item.ScheduleDate)
                                                .GroupBy(item => item.Category)
                                                .Select(itemGroup => new Helpers.Grouping<ScheduleCategory, ScheduleItemViewModel>(itemGroup.Key, itemGroup));

            ScheduleItems = new ObservableCollection<Helpers.Grouping<ScheduleCategory, ScheduleItemViewModel>>(filterList);
        }

        private async Task ExecuteScheduleSelectCommand(int selectedIndex)
        {
            try
            {
                IsBusy = true;
                await _navigationService.NavigateToAsync<ScheduleDetailViewModel>(selectedIndex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoadSchedules()
        {
            await LoadWeekView();

            List<ScheduleItemViewModel> listScheduleItems = await _scheduleService.GetAllSchedules();

            listScheduleItems.ForEach(SheduleList.Add);

            LoadSchedulesForSelectedDate();
        }

        private async Task LoadWeekView()
        {
            List<DateCellViewModel> weekDataList = await _scheduleService.GetCurrentWeekData();

            weekDataList.ForEach(WeekDaysView.Add);
        }

        private bool CanExecuteSubmit(int a)
        {
            return !IsBusy;
        }
    }
}
