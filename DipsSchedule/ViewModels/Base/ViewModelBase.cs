using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DipsSchedule.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string pageTitle = string.Empty;

        private bool isbusy = false;

        public string PageTitle
        {
            get { return pageTitle; }
            set
            {
                pageTitle = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return isbusy; }
            set
            {
                isbusy = value;
                OnPropertyChanged();
            }
        }

        public virtual async Task<bool> InitializeAsync(object navigationData)
        {
            return await Task.FromResult(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
