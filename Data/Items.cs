namespace SoundEffect.Data
{
    public class Items
    {
        public string Id { get; set; }
        public int CatalogNum { get; set; }

        public string Name { get; set; }
        public string Genre { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public string Carrier { get; set; } //cd, vinil
        public Categories Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }  
        public DateTime DateOfAdding { get; set; }
        public int Quantity { get; set; }
        public string AuthorId { get;set; }
        public string PictureUrl { get; set; }
       



    }
}
