using shopapp.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.businness.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
        //order kısmı
        List<Order> GetOrders(string userId);
    }
}
