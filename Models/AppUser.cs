using Microsoft.AspNetCore.Identity;

namespace Etui.Models
{
        public class AppUser : IdentityUser
        {
                public string Occupation { get; set; }
        }
}
