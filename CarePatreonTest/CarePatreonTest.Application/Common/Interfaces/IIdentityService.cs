namespace CarePatreonTest.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> AssignUserToRole(string userName, IList<string> roles);

        Task<bool> CreateRoleAsync(string roleName);

        Task<(bool isSucceed, string userId)> CreateUserAsync(string userName, string password, string email, string fullName, List<string> roles);

        Task<bool> DeleteRoleAsync(string roleId);

        Task<bool> DeleteUserAsync(string userId);

        Task<List<(string id, string fullName, string userName, string email)>> GetAllUsersAsync();

        Task<List<(string id, string userName, string email, IList<string> roles)>> GetAllUsersDetailsAsync();

        Task<(string id, string roleName)> GetRoleByIdAsync(string id);

        Task<List<(string id, string roleName)>> GetRolesAsync();

        Task<(string userId, string fullName, string UserName, string email, IList<string> roles)> GetUserDetailsAsync(string userId);

        Task<(string userId, string fullName, string UserName, string email, IList<string> roles)> GetUserDetailsByUserNameAsync(string userName);

        Task<string> GetUserIdAsync(string userName);

        Task<string> GetUserNameAsync(string userId);

        Task<List<string>> GetUserRolesAsync(string userId);

        // User's Role section
        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> IsUniqueUserName(string userName);

        Task<bool> SigninUserAsync(string userName, string password);

        Task<bool> UpdateRole(string id, string roleName);

        Task<bool> UpdateUserProfile(string id, string fullName, string email, IList<string> roles);

        Task<bool> UpdateUsersRole(string userName, IList<string> usersRole);
    }
}