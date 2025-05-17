namespace BookRentalAPI.Models.DTOs
{
    public class RentalRequestDto
    {
        public int BookId { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
