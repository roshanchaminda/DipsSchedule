using System;
using System.Threading.Tasks;
using DipsSchedule.ViewModels.Base;

namespace DipsSchedule.Services
{
    /// <summary>
    ///  Manage App navigations 
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Will allow a <c>Task</c> to be initialize asynchronously
        /// </summary>
        /// <returns>A void <c>Task</c></returns>
        Task InitializeAsync();

        /// <summary>
        /// Navigates to a page associated with type ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">The return type of Task to be invoked.</typeparam>
        /// <returns>A void <c>Task</c></returns>
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        /// <summary>
        /// Will allow a <c>Task</c> to be navigate asynchronously to view through the viewmodel
        /// </summary>
        /// <typeparam name="TViewModel">The return type of Task to be invoked.</typeparam>
        /// <param name="parameter">The parameters to be invoked in page initialize</param>
        /// <returns>A void <c>Task</c></returns>
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
    }
}
