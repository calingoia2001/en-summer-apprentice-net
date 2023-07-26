namespace TicketManagmentSystem.Api.Models.Dto
{
    public class OrderPatchDto
    {
        public long OrderID { get; set; }
        public int NumberOfTickets { get; set; }
        public int TicketCategoryid { get; set; }
    }
}
