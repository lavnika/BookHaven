namespace BookRentalAPI.Models.DTOs
{
    public class RentalResponseDto
    {
        public int RentalId { get; set; }
        public string BookTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string Status { get; set; }
        public decimal DeliveryFee { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
