using System;
using System.Collections.Generic;

namespace TicketManagmentSystem.Api.Models;

public partial class TicketCategory
{
    public long TicketCategoryid { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public long? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
