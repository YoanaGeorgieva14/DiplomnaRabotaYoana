using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundEffect.Data
{
    public class Item
    {
        public int Id { get; set; }
        public int CatalogNum { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }
        public Genre Genres { get; set; }

        public string Carrier { get; set; } //cd, vinil
        public Categories Category { get; set; } //enum
        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }  
        public int Quantity { get; set; }
        public int AuthorId { get;set; }  

        public Author Authors { get; set; }
        public string PictureUrl { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public DateTime DateOfAdding { get; set; }


    }
}
