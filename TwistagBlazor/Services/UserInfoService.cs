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
    }
}
