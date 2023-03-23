using System;

namespace Class
{
    //class oluşturalım
    class Ogrenci
    {
        //property leri oluşturmak için(değişkenleri yani)  (prob+tab+tab kısa yol)
        public int OgrNo { get; set; }
        public string Ad { get; set; }
        public string Sube { get; set; }

    }
    class Classlar
    {
        static void Main(string[] args)
        {
            //bir dizi tanımlayalım
            int[] ogrNo = { 100, 200, 300 };
            string[] ad = { "Çınar", "Ada", "Yiğit" };
            string[] sube = { "10A", "10B", "11A" };
            //ve bunları yazdırmaya kalkarsak eğer
            Console.WriteLine($"no: {ogrNo[0]} ad: {ad[0]} sube: {sube[0]}");
            Console.WriteLine($"no: {ogrNo[1]} ad: {ad[1]} sube: {sube[1]}");
            Console.WriteLine($"no: {ogrNo[2]} ad: {ad[2]} sube: {sube[2]}");
            //Bilgiler arttığı zaman bu şekilde işlemek zor
            //bu yüzden class kavramına başvurmamız gerekiyor
            //classı oluşturduk artık bu Ogrenci classından bir nesne üretmemiz gerekiyor
            Ogrenci ogr1 = new Ogrenci();
            //ogr1 nesnesini oluşturduk ve artık ogr1. yazdığımızda propertylere ve metotlara ulaşabiliyoruz
            //propertylere bilgi atayabiliyoruz
            ogr1.OgrNo = 100;
            ogr1.Ad = "Çınar";
            ogr1.Sube = "10A";
            //bu bilgileri yazdırmak istersek eğer
            Console.WriteLine($"no: {ogr1.OgrNo} ad: {ogr1.Ad} sube: {ogr1.Sube}");

            //bir öğrenci nesnesi daha tanımlayalım
            //alternatif olarak bu şekilde de propertylere değer atayabiliriz
            Ogrenci ogr2 = new Ogrenci()
            {
                OgrNo = 200,
                Ad = "Ada",
                Sube = "10B"
            };
            Console.WriteLine($"no: {ogr2.OgrNo} ad: {ogr2.Ad} sube: {ogr2.Sube}");

            //bir nesne daha oluşturalım
            Ogrenci ogr3 = new Ogrenci()
            {
                OgrNo = 300,
                Ad = "Yiğit",
                Sube = "11A"
            };
            Console.WriteLine($"no: {ogr3.OgrNo} ad: {ogr3.Ad} sube: {ogr3.Sube}");

            //ayrı ayrı nesneleri konsolda yazdırmaktansa daha kolay bir yol var
            Console.WriteLine("***********************************");
            //Bir dizi tanımlıcaz Ogrenci sınıfı türünde ve 3 elemanlı olacağını söylüyoruz
            Ogrenci[] ogrenciler = new Ogrenci[3];
            ogrenciler[0] = ogr1;
            ogrenciler[1] = ogr2;
            ogrenciler[2] = ogr3;
            for(int i = 0; i < ogrenciler.Length; i++)
            {
                Console.WriteLine($"no: {ogrenciler[i].OgrNo} ad: {ogrenciler[i].Ad} sube: {ogrenciler[i].Sube}");
            }



        }
    }
}
