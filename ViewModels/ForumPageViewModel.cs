
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
using Stulio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.ViewModels
{
    [QueryProperty(nameof(ForumDetail), "ForumDetail")]
    public partial class ForumPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ForumModel forumDetail;

        private readonly IForumService _forumService;
        public ForumPageViewModel(IForumService forumService)
        {
            _forumService = forumService;
        }

     
        public async Task CallChatGPT()
        {
            string prompt = "Give me only one random SAT problem question and answer in English or Math subject for High school student";


            // Call the API
            ForumModel response = await _forumService.CallChatGptAPI(prompt);

            // Display the response
            Console.WriteLine("Response from AI:");
            Console.WriteLine(response.PromptResponse);

            forumDetail.Prompt = prompt;
            forumDetail.PromptResponse = response.PromptResponse;

            //await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");

        }

    }

    
}