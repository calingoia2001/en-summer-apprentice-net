namespace TicketManagmentSystem.Api.Models.Dto
{
    public class VenueDto
    {
        public long VenueID { get; set; }
        public int Capacity { get; set; }
        public string LocationName { get; set; }
        public string LocationType { get; set; }
    }
}
