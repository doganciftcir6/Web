using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDatabaseIslemleri
{
    public class UrunContext : DbContext
    {
        //context ile connectionstring'i ilişkilendirmeliyiz
        //kanstraktır
        public UrunContext():base("urunConnection")
        {

        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
    }
}
