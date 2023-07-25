using System;
using System.Collections.Generic;

namespace TicketManagmentSystem.Api.Models;

public partial class Venue
{
    public long Venueid { get; set; }

    public int? Capacity { get; set; }

    public string? LocationName { get; set; }

    public string? LocationType { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
