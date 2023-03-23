using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDatabaseIslemleri
{
    //entity sınıfımız
    //tabloyu tasarlıyoruz Urun tablosu ve proplarda kolon isimleri
    public class Kategori
    {
        public int Id { get; set; }
        //ıd kısmı birincil anahtar
        //varsayılan olarak otomatik sayı olarak ayarlanır.
        //Kategori tablosunun birincil anahtarı olarak işaretlenir
        public string KategoriAdi { get; set; }
    }
}
