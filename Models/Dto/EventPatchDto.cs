namespace TicketManagmentSystem.Api.Models.Dto
{
    public class EventPatchDto
    {
        public long EventID { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; }
    }
}
