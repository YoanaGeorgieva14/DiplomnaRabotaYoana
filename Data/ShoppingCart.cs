namespace SoundEffect.Data
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public string ClientId { get; set; }
        public Client Clients { get; set; }

        public int ItemId { get; set; }
        public Item Items { get; set; }

        public int Quantity { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
