using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDatabaseIslemleri
{
    //entity sınıfı
    //tabloyu tasarlıyoruz Urun tablosu ve proplarda kolon isimleri
   public class Urun
    {
        //ıd kısmı birincil anahtar
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }
        public int StokAdedi { get; set; }
        public bool Satistami { get; set; }
    }
}
