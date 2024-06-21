using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
//using Stulio.RestService;

namespace MyApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            GetUserCommand = new AsyncRelayCommand(GetUser);
        }
        /// <summary>
        /// Command to get user details
        /// </summary>
        public IAsyncRelayCommand GetUserCommand { get; }
        /// <summary>
        /// User Object
        /// </summary>
        [ObservableProperty]
        //User user;
        /// <summary>
        /// Message property to show API call result
        /// </summary>
        //[ObservableProperty]
        string message;
        /// <summary>
        /// Is busy property to show loader on screen
        /// </summary>
        [ObservableProperty]
        bool isBusy;

        /// <summary>
        /// Gets the user data from API
        /// </summary>
        private async Task GetUser()
        {
            IsBusy = true;
          //  await RestServiceCall<User>.Get("users/1", UserDataLoaded, UserDataLoadFailed);
            IsBusy = false;
        }

        /// <summary>
        /// User details loaded successfully
        /// </summary>
        /// <param name="userObj">User</param>
      //  private void UserDataLoaded(User userObj)
        //{
        //    if (userObj != null)
        //    {
        //        User = userObj;
        //    }
        //    Message = "User data loaded";
        //}
        /// <summary>
        /// Failed to load user data
        /// </summary>
        /// <param name="exception">Exception</param>
        private void UserDataLoadFailed(Exception exception)
        {
            Message = exception?.Message;
        }
    }
}