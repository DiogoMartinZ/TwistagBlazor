Twistag Challange!

In this solution you have two projects: TwistagBlazor, and TwistagApi.
TwistagBlazor has the front end that sends the data from the user to the API ( TwistagAPI)

In order to make it run you need to create a database on Pgadmin (postgres) with the name "Twistag". The username on pgadmin must be "postgres" and the password "postgres". If wou want to change the database you can go to the TwistagAPI project, then go on appsettings.json and change the "DefaultConnection" for your own database.
When the "DefaultConnection" is done you need to run the "dotnet ef database update" to run all the migrations in order to fill the database.

Run the API and check the URL. In my case it is https://localhost:7109, if its diferent you need to change it on the Program.cs on the TwistagBlazor project. This is what makes the Front End communicate with the API.

In the TwistagBlazor you can add user info, see a table with all the users information and delete (individually) any user information.
When adding a new User Information you can't repeat Emails, if you try to register a new User Information with the same email it will give you a error message.

The nuget packages that I used are the NetcodeHub.Packages.Components.Toast for the message pop ups, System.Net.Http.Json to read and send data to the API, and Microsoft.AspNetCore.Components.QuickGrid to display a grid with user information.
