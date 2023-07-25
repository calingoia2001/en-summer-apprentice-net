namespace TicketManagmentSystem.Api.Models.Dto
{
    public class EventTypeDto
    {
        public long EventTypeID { get; set; }
        public string EventTypeName { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
