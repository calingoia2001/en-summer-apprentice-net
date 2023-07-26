namespace TicketManagmentSystem.Api.Models.Dto
{
    public class OrderDto
    {
        public long OrderID { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime? OrderedAt { get; set; }
        public int TotalPrice { get; set; }

        public long TicketCategoryid { get; set; }
    }
}
