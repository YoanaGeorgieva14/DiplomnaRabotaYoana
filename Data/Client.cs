using Microsoft.AspNetCore.Identity;

namespace SoundEffect.Data
{
    public class Client : IdentityUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}
