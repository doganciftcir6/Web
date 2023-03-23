using Interfaceler;
using System;

namespace Interfaceler
{
    //ABSTRACT SINIFLAR ASLINDA BİZİM İÇİN BİR TEMEL SINIF OLMUŞ OLUYOR VE TEMEL SINIF İÇERİSİNDE ABSTRACT OLARAK İŞARETLEMİŞ OLDUĞUMUZ METOTLARI SONRADAN OLUŞAN SINIFLAR BU ABSTRACT SINIFI BASE OLARAK TEMEL SINIF OLARAK KABUL EDİP KULLANDIKLARINDA ABSTRACT OLARAK TANIMLANAN METOTLARI İMPLEMENTE ETMELERİ GEREKİYOR YANİ DOLDURMALARI GEREKİYOR YANİ BİZ ÖNCEDEN BİR SOYUTLAMA İŞLEMİ YAPMIŞ OLUYORUZ DOLAYISIYLA BURADA DİYEBİLİRİZ Kİ ABSCRAT SINIFI KULLANAN BİR ÜZERİNDEN NESNE TÜRETİLECEK OLAN BİR SINIFIN ASLINDA ÖNCEDEN BİR SÖZLEŞMEYİ BİR YERİNE GETİRMESİ GEREKEN KOŞULLARI KABUL EDİYOR OLMASI ANLAMINA GELİYOR BU SOYUTLAMAYI BİRAZ DAHA ARTTIRIRSAK İNTERFACE YAPSINU KULLANABİLİRİZ YANİ ELİMİZDE BİR CLASS OLACAK VE BU CLASS DAHA ÖNCEDEN BİZİM BELİRTTİĞİMİZ PROPLARA YA DA METOTLARA MUTLAKA UYACAĞINI SÖYLEYEBİLİR

    //interface tanımlayalım inteface isminin başında genelde I harfi oluyor bunun interface olduğunu belirtmek için I koyuyoruz isminin başına
    //kişi ya da robotların uyması gereken özellikler burda kalsın
    interface IPersonel
    {
        //interface içerisine kanstraktır ekleyemeyiz
        //bu problar otomatik olarak abstract ve publicttir
        string departman { get; set; }
        //geri dönüş değeri olmayan bir metot tanımlayalım
        //metotun gövdesi yok yani abstract bir metot tanımlaması gibi metotta varsayılan olarak abstract olarak tanımlanıyor zaten yazmaya gerek yok
        void bilgi();
    }
    //sadece kişilerin uyması gereken özelliklerde burda kalsın
    interface IKisi
    {
        //bu problar otomatik olarak abstract ve publicttir
        string adSoyad { get; set; }
        string adres { get; set; }
        string departman { get; set; }
        double maas { get; set; }
            
        }
    }
    //classlar tanımlayalım
    //yönetici ya da işci bu sınıflar temelde aslında bir personel dolayısıyla ben personel interfacesi içerisinde olan özellikleri mutlaka yönetici ve işçi sınıfının kullanacığını garanti altına alabilirim : ile bunları Ipersonelden implement edelim
    //IPersonel içerisindeki bütün özellikleri burda implement etmek zorundayız
    class Yonetici : IPersonel, IKisi
{
        //kasntraktır
        public Yonetici(string _adsoyad, string _adres, string _departman)
        {
            this.adSoyad = _adsoyad;
            this.adres = _adres;
            this.departman = _departman;
        }
        public string adSoyad { get; set; }
        public string adres { get; set; }
        public string departman { get; set; }
        public double maas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void bilgi()
        {
            Console.WriteLine($"{this.adSoyad} isimli personel {this.departman} bölümünde yöneticidir.");
        }
    }
    class Isci : IPersonel,IKisi
    {
        //kasntraktır
        public Isci(string _adsoyad, string _adres, string _departman)
        {
            this.adSoyad = _adsoyad;
            this.adres = _adres;
            this.departman = _departman;
        }
        public string adSoyad { get; set; }
        public string adres { get; set; }
        public string departman { get; set; }
        public double maas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void bilgi()
        {
            Console.WriteLine($"{this.adSoyad} isimli personel {this.departman} bölümünde işçidir.");
        }

    }
//işyerinde işçi yönetici haricinde robotlar görev alıyor olsa ben bunu IPersonelden kalıtsam robotun kullanmayacağı özelliklerde gelebilir dolayısıyla birden fazla interface kullanabiliriz
class Robot : IPersonel
{
    //kanstraktırı
    public Robot(string _departman)
    {
        this.departman = _departman;
    }
    public string departman { get; set; }

    public void bilgi()
    {
        Console.WriteLine($"{this.departman} bölümünde bir robot.");
    }
}
class Interface
    {
        static void Main(string[] args)
        {
            //ilgili sınıflardan bir nesne türetelim
            //bunlar temelde IPersonel i implemente eden bir sınıf oldukları için baş tarafa IPersonel yazabilirim
            //IPersonel y = new Yonetici();
            //IPersonel i = new Isci();

            //bu sayede böyle bir kullanım yapabilirim
            var personneller = new IPersonel[3];
            personneller[0] = new Yonetici("ali yılmaz","istanbul","finans");
            personneller[1] = new Isci("ahmet cengiz", "kocaeli", "üretim");
            personneller[2] = new Robot("üretim");
            foreach (var personel in personneller)
            {
                personel.bilgi();
            }

        }
    }
}
