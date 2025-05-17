namespace BookRentalAPI.Models.Entities
{
    public class Rental
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }

        public string DeliveryAddress { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Pending, Delivered, Returned
        public bool PaymentStatus { get; set; } = false;
        public decimal DeliveryFee { get; set; }
    }
}
