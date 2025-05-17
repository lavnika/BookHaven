namespace BookRentalAPI.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public string LocationCity { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Rental> Rentals { get; set; }
    }
}
