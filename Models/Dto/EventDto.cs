namespace TicketManagmentSystem.Api.Models.Dto
{
    public class EventDto
    {
        public long EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; }
        public string EventTypeid { get; set; }
        public string Venueid { get; set; }
        public string Venue { get; set; }
    }
}
