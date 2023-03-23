using System;
using System.Globalization;

namespace DataTime
{
    class DataTimes
    {
        static void Main(string[] args)
        {
            //DateTime objesi ile tarih ve zaman bilgilerimizi yapabiliyoruz
            //DateTime objesi tanımlayalım

            //ay bilgisni türkçeleştirmek istersek bir dizi
            string[] aylar = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Eylül", "Ekim", "Kasım", "Aralık" };

            //.Now özelliği şuanda uygulamamızın çalıştığı bilgisayarın zaman bilgilerini bana getirir  
            DateTime simdi = DateTime.Now;
            Console.WriteLine(simdi);
            //sadece istediğimiz parçayıda alabiliriz
            //sadece yıl bilgisini alabiliriz mesela
            Console.WriteLine(simdi.Year);
            //sadece ay bilgisi
            Console.WriteLine(simdi.Month);
            //sadece gün bilgisi
            Console.WriteLine(simdi.Day);
            //sadece haftanın gün ismi salı çarşamba vs
            Console.WriteLine(simdi.DayOfWeek);
            //ay bilgisini türkçeleştirmek için
            Console.WriteLine(aylar[simdi.Month-1]);
            //saat bilgisini almak
            Console.WriteLine(simdi.Hour);
            //dakika
            Console.WriteLine(simdi.Minute);
            //saniye
            Console.WriteLine(simdi.Second);


            //kendi belirlediğimiz tarih bilgilerine göre DateTime objesi oluşturabiliirz
            DateTime dt = new DateTime(2018,2,22,14,30,21);
            //bu bilgilere ekleme çıkartma yapmak

            //mevcut gün bilgisine 2 gün ekleme yapar
            DateTime dt1 = dt.AddDays(2);

            //mvecut yıl bilgisi üzerine 1 yıl eklemesi yapmak
            DateTime dt2 = dt.AddYears(1);

            //mevcut saat bilgisine 5 saat çıkartma yapar - ile negatif değer yani çıkartma yapıyor eksiltiyor
            DateTime dt3 = dt.AddHours(-5);

            //iki tarih arasındaki farkı almak
            //geriye bir TimeSpan objesi geliyor bu obje iki tarih arasındaki farkı bize veriyor
            var fark = simdi - dt;
            //toplam gün yani kaç gün var diyebiliriz .TotalDays ile
            Console.WriteLine(fark.TotalDays);
            //.TotalHours dersek iki tarih arasındaki toplam saat bilgisini alabiliriz
            Console.WriteLine(fark.TotalHours);

            //simdi değişkenini çağırdığımızda tarih saat şeklinde bir format geliyor bu formatı değiştirebiliriz
            //böyle yaparsak saat bilgisi gelmez
            Console.WriteLine(simdi.ToString("d"));
            //6 Şubat 2020 Perşembe şeklinde gelir
            Console.WriteLine(simdi.ToString("D"));
            //6 Şubat 2020 Perşembe 00:04:28 şeklinde gelir
            Console.WriteLine(simdi.ToString("F"));
            //6 Şubat şeklinde gelir
            Console.WriteLine(simdi.ToString("M"));
            //00:04 şeklinde gelir
            Console.WriteLine(simdi.ToString("t"));
            //00:04:28 şeklinde gelir
            Console.WriteLine(simdi.ToString("T"));
            //Şubat 2020 şeklinde gelir
            Console.WriteLine(simdi.ToString("y"));

            //formatlama işlemini daha esnek bir şekilde kullanabiliriz
            Console.WriteLine(simdi.ToString("hh:mm:ss"));
            Console.WriteLine(simdi.ToString("ddd MMM %d, yyyy"));

            //ingilizce formatına göre tarih bilgisini yazdırabiliriz bu tarz farklı ülkelerin formatlarını kullanabiliriz CultureInfo ile
            CultureInfo culture = new CultureInfo("en");
            Console.WriteLine(simdi.ToString("F",culture));

        }
    }
}
