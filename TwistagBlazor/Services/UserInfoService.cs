using TwistagBlazor.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace TwistagBlazor.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly HttpClient httpClient;

        public UserInfoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddUserInfo(UserInformation userInfo)
        {

            var apiResponse = await httpClient.PostAsJsonAsync<UserInformation>("api/UserInfoes", userInfo);

            if(apiResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

            return true;  

      
        }

        public async Task<List<UserInformation>> GetAllUserInfo()
        {

            var result = await httpClient.GetAsync("api/UserInfoes");
            var response = await result.Content.ReadFromJsonAsync<List<UserInformation>>();         

            return response;


        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await httpClient.DeleteAsync($"api/UserInfoes/{id}");

            return result.IsSuccessStatusCode;
          

        }

    }
}
