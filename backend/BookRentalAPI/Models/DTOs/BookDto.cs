namespace BookRentalAPI.Models.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string LocationCity { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsAvailable { get; set; }
    }
}
