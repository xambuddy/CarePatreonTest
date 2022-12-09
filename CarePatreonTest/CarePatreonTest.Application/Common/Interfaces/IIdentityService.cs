namespace CarePatreonTest.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(string userId, string fullName, string UserName, string email, IList<string> roles)> GetUserDetailsAsync(string userId);

        Task<string> GetUserIdAsync(string userName);

        Task<bool> SigninUserAsync(string userName, string password);
    }
}