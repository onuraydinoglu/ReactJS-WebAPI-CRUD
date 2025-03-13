namespace Server.Entities
{
    public sealed class Product : Entity<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}