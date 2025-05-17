namespace BookRentalAPI.Models.DTOs
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
