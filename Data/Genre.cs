namespace SoundEffect.Data
{
    public class Genre
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public DateTime RegisteredOn { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
