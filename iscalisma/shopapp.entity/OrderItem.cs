using System;
using System.Collections.Generic;
using System.Text;

namespace shopapp.entity
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        //OrderItem tablosu üzerinden order detaylarına gitmek için nav prop kullanmalıyız
        public Order Order { get; set; }
        public int ProductId { get; set; }
        //OrderItem tablosu üzerinden Product detaylarına gitmek için nav prop kullanmalıyız
        public Product Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
