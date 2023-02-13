namespace SoundEffect.Data
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public ICollection<Client> Clients { get; set; }
        public Items ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
