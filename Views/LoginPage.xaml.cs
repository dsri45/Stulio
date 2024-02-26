
using Stulio.Models;
using System;
using System.Collections.ObjectModel;

namespace Stulio.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    async void OnButtonClicked(object sender, EventArgs args)
    {
        await label1.RelRotateTo(360, 1000);
       
       // SignUPUser();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

       
    }

    //[RelayCommand]
    //public async Task GetContact(int contactId)
    //{
    //    await var apiobj = new ApiService();
    //    var c = apiobj.GetTodoItemsAsync();
    //    Console.Write(c.ToString());
    //}

    //public void SignUPUser()
    //{

    //    Microsoft.Data.SqlClient.SqlConnection sqlconnection;
    //    sqlconnection = new Microsoft.Data.SqlClient.SqlConnection(StrConn);

    //    Microsoft.Data.SqlClient.SqlCommand comm = new Microsoft.Data.SqlClient.SqlCommand(query, sqlconnection);
    //    comm.ExecuteNonQuery();


    //    // Replace "YourConnectionString" with your actual connection string
    //    string connectionString = "Data Source=YourServer;Initial Catalog=YourDatabase;User ID=YourUsername;Password=YourPassword;";


    //    Microsoft.Data.SqlClient.SqlConnection sqlconnection;
    //    sqlconnection = new Microsoft.Data.SqlClient.SqlConnection(StrConn);

    //    Microsoft.Data.SqlClient.SqlCommand comm = new Microsoft.Data.SqlClient.SqlCommand(query, sqlconnection);
    //    comm.ExecuteNonQuery();

    //    // Create a SqlConnection using the connection string
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        try
    //        {
    //            // Open the connection
    //            connection.Open();

    //            // Create a SqlCommand with the INSERT statement and parameters
    //            string insertQuery = "INSERT INTO [dbo].[Users] ([UserID],[FirstName],[LastName],[Email],[PasswordHash],[CreatedDateTime],[ProfilePictureURL]) VALUES (@Value1, @Value2, @Value3)";
    //            using (SqlCommand command = new SqlCommand(insertQuery, connection))
    //            {
    //                // Replace the parameter names with your actual column names and values
    //                command.Parameters.AddWithValue("@UserID", 106);
    //                command.Parameters.AddWithValue("@FirstName", "TestUser1");
    //                command.Parameters.AddWithValue("@LastName","TestUser2");
    //                command.Parameters.AddWithValue("@Email", "TestEmail@email.com");
    //                command.Parameters.AddWithValue("@PasswordHash", "12313");
    //                command.Parameters.AddWithValue("@CreatedDateTime", DateTime.Now);
    //                command.Parameters.AddWithValue("@ProfilePictureURL", "TestProfilePicture");
    //                // Execute the INSERT command
    //                int rowsAffected = command.ExecuteNonQuery();

    //                // Check if any rows were affected
    //                if (rowsAffected > 0)
    //                {
    //                    Console.WriteLine("Row inserted successfully.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("No rows inserted.");
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Error: " + ex.Message);
    //        }
    //    }

    //}


}

public static class UserService
{
    private const string server = "";
    private const string database = "";
    private const string username = "";
    private const string password = "";

   // private static string connectionString => $"Data Source={server};Database={database};User Id={username};Password={password}";

   //public static async Task<UserDto> GetUserAsync(string username, string password, CancellationToken cancellationToken)
   // {
   //     using (SqlConnection connection = new SqlConnection(connectionString))
   //     {
   //         connection.Open();

   //         string sql = "SELECT * FROM MyTable WHERE Column = @value";
   //         return await connection.QueryFirstOrDefaultAsync<UserDto>(sql).ToList();
   //     }

      
   // }
}