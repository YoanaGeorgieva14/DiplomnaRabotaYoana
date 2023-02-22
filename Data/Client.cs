using Microsoft.AspNetCore.Identity;

namespace SoundEffect.Data
{
    public class Client : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}
