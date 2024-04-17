
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

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // API endpoint
            //string apiUrl = "https://api.openai.com/v1/chat/completions";
            string apiUrl = "https://api.openai.com/v1/engines/gpt-3.5-turbo/completions";
            // Prepare the messages
            var messages = new[] {
  new { role = "system", content =  "You are a helpful assistant." },
  new { role = "user", content =  "Hello!" } };


            // Prepare the payload
            var payload = new { messages, model = "gpt-3.5-turbo" };
            var jsonPayload = JsonConvert.SerializeObject(payload);

            // Make the POST request
            var response = await client.PostAsync(apiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));



            // Check if the call was successful
            if (response.IsSuccessStatusCode)
                {
                    // Read and return the response content
                    // Read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // JSON convert to streamwrite to text file. 
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    string generatedContent = jsonResponse.choices[0].message.content;

                    ForumModel result = new ForumModel();
                    // Read and return the response content
                    var gptresponse = await response.Content.ReadAsStringAsync();
                    return new ForumModel { Prompt = prompt, PromptResponse = generatedContent };


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


