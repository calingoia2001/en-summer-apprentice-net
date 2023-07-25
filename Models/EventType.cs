using System;
using System.Collections.Generic;

namespace TicketManagmentSystem.Api.Models;

public partial class EventType
{
    public long EventTypeid { get; set; }

    public string? EventTypeName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
