
using Microsoft.AspNetCore.Identity;


namespace Metcom.CardPay3.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int IdOrganization { get; set; }
    }
}
