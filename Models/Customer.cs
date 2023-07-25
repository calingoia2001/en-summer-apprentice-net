﻿using System;
using System.Collections.Generic;

namespace TicketManagmentSystem.Api.Models;

public partial class Customer
{
    public long Customerid { get; set; }

    public string? CustomerName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
