
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
using Stulio.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.ViewModels
{
 
    public partial class ForumPageViewModel : ObservableObject
    {

        [ObservableProperty]
        private ForumModel gptReponse;
        private readonly IForumService _forumService;
        public ForumPageViewModel(IForumService forumService)
        {
            _forumService = forumService;
        }

        [RelayCommand]
        public async Task CallChatGPT()
        {
            string prompt = "Give me one random high school, college application, or future endeavors tip. ";

            // Call the API
            GptReponse = await _forumService.CallChatGptAPI(prompt);


        }

    }

    
}