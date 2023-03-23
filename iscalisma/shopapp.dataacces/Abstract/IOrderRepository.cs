using System;
using System.Collections.Generic;
using System.Text;
using shopapp.entity;


namespace shopapp.dataacces.Abstract
{
    //sanal bir sınıf oluşturucaz category'ları ilgilendiren
    //generic sınıfımız olduğu için artık o sınıftan bir türetme yapabiliriz
    public interface IOrderRepository : IRepository<Order>
    {
        //artık temel metotları burda tekrar tekrar yazmama gerek kalmadı
        List<Order> GetOrders(string userId);
    }
}
