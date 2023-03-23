using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiyFrameworkORM.Data.EfCore
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public int OrderCount { get; set; }
    }
    //BUNUN YAPTIĞI İŞLEM NORTHWİNDCONTEXT'İ GENİŞLETECEK
    class CustomNorthwindContext : northwindContext
    {
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public CustomNorthwindContext()
        {

        }
        public CustomNorthwindContext(DbContextOptions<northwindContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerOrder>(entity => {
                entity.HasNoKey();
                });
        }
}
}
