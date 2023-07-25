﻿using TicketManagmentSystem.Api.Models;

namespace TicketManagmentSystem.Api.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(long id);
        int Add(Order @order);
        void Update(Order @order);
        void Delete(long id);
    }
}
