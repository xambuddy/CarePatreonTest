using CarePatreonTest.Application.Common.Interfaces;
using CarePatreonTest.Application.Exceptions;
using CarePatreonTest.Infrastructure.Identity;
using System.Data;

namespace CarePatreonTest.Infrastructure.Services
{
    public class MockIdentityService : IIdentityService
    {
        private readonly List<ApplicationUser> applicationUsers;

        public MockIdentityService()
        {
            this.applicationUsers = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Id = "user001",
                    UserName = "dhavedayao",
                    PasswordHash = "1234567890",
                    FullName = "Dhave Dayao",
                    Email = "dhavedayao@gmail.com"
                }
            };
        }

        public Task<(string userId, string fullName, string UserName, string email, IList<string> roles)> GetUserDetailsAsync(string userId)
        {
            var user = this.applicationUsers.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            IList<string> roles = new List<string> { "standard" };

            return Task.FromResult((user.Id, user.FullName, user.UserName, user.Email, roles));
        }

        public Task<string> GetUserIdAsync(string userName)
        {
            var user = this.applicationUsers.FirstOrDefault(x => x.UserName == userName);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return Task.FromResult(user.Id);
        }

        public Task<bool> SigninUserAsync(string userName, string password)
        {
            var users = this.applicationUsers.Where(x => x.UserName == userName && x.PasswordHash == password);

            return Task.FromResult(users?.Any() == true);
        }
    }
}
