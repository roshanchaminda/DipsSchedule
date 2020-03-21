using System;
using System.Threading.Tasks;
using DipsSchedule.Services;
using DipsSchedule.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DipsSchedule
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
