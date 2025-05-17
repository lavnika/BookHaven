namespace BookRentalAPI.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string City { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
