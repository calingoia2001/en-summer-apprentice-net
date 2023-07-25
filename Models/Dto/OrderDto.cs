namespace TicketManagmentSystem.Api.Models.Dto
{
    public class OrderDto
    {
        public long OrderID { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime? OrderedAt { get; set; }
    }
}
