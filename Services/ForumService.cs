
//using Android.App;
using Newtonsoft.Json;
using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Stulio.Services
{
    public class ForumService : IForumService
    {

        public async Task<ForumModel> CallChatGptAPI(string prompt)
        {

            // Replace 'YOUR_API_KEY' with your actual API key
            string apiKey = "sk-proj-ZQbqbksGZ6MlXkUIFU2WT3BlbkFJe81KLsz2kBdIxONXwtYp";

            // string apiKey = "YOUR_API_KEY";
            string apiUrl = "https://api.openai.com/v1/chat/completions";

            //string prompt = "You: Tell me a joke.\nAI:";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                    new
                    {
                        role = "system",
                        content = "You are a helpful assistant."
                    },
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                }
                };

                var response = await client.PostAsync(apiUrl, new StringContent(JsonConvert.SerializeObject(requestBody), System.Text.Encoding.UTF8, "application/json"));

               
                // Check if the call was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read and return the response content
                    // Read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // JSON convert to streamwrite to text file. 
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    string generatedContent = jsonResponse.choices[0].message.content;

                    // Read and return the response content
                    var gptresponse = await response.Content.ReadAsStringAsync();
                    var Result = new ForumModel { Prompt = prompt, PromptResponse = generatedContent.Replace("Sure!","") };
                    return Result;
                }
                else
                {
                    // Display error message if the call fails
                    Console.WriteLine($"Error calling the API: {response.StatusCode}");
                    return null;
                }

            }
        }
    


    }
}


