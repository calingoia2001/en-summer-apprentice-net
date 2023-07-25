using System;
using System.Collections.Generic;

namespace TicketManagmentSystem.Api.Models;

public partial class Order
{
    public long Orderid { get; set; }

    public int? NumberOfTickets { get; set; }

    public DateTime? OrderedAt { get; set; }

    public int? TotalPrice { get; set; }

    public long? Customerid { get; set; }

    public long? TicketCategoryid { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual TicketCategory? TicketCategory { get; set; }
}
