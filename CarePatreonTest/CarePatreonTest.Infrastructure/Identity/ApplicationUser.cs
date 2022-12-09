using Microsoft.AspNetCore.Identity;

namespace CarePatreonTest.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
