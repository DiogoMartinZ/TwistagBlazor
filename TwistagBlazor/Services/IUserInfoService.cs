using TwistagBlazor.Models;


namespace TwistagBlazor.Services
{
    public interface IUserInfoService
    {
        Task<bool> AddUserInfo(UserInformation userInfo);
    }
}
