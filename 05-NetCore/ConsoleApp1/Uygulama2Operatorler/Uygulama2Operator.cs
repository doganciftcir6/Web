using System;

namespace Uygulama2Operatorler
{
    class Uygulama2Operator
    {
        static void Main(string[] args)
        {
            //1- Girilen 2 sayıdan hangisi büyüktür?
            int ilkSayi;
            int İkinciSayi;
            Console.Write("Birinci sayıyı giriniz: ");
            ilkSayi = int.Parse(Console.ReadLine());
            Console.Write("İkinci sayıyı giriniz: ");
            İkinciSayi = int.Parse(Console.ReadLine());
            if(ilkSayi > İkinciSayi)
            {
                Console.WriteLine($"Girdiğiniz ilk sayı {ilkSayi} ve Girdiğiniz ikinci sayı {İkinciSayi} büyük olan sayı {ilkSayi}");
            }else if (ilkSayi < İkinciSayi)
            {
                Console.WriteLine($"Girdiğiniz ilk sayı {ilkSayi} ve Girdiğiniz ikinci sayı {İkinciSayi} büyük olan sayı {İkinciSayi}");
            }

            //2- Parola ve Email bilgisini isteyip doğruluğunu kontrol ediniz.
            string email;
            string parola;

            Console.Write("Email bilginizi giriniz: ");
            email = (Console.ReadLine());
            Console.Write("Parola bilginizi giriniz: ");
            parola = (Console.ReadLine());

           var sonuc = (email == "doganciftcir6@hotmail.com") ? parola == "aysel1998" ? "email ve parola doğru" : "email doğru parola yanlış" 
                                                                                              :
                                                               parola == "aysel1998" ? "email yanlış parola doğru" : "email yanlış parola yanlış"; ;

            Console.WriteLine(sonuc);

            //3-Girilen bir sayının pozitif çift sayı olup olmadığını kontrol ediniz.
            int girilenSayi;
            Console.Write("Sayıyı giriniz: ");
            girilenSayi = int.Parse(Console.ReadLine());
            if(girilenSayi % 2 == 0 && girilenSayi != 0)
            {
                Console.WriteLine($"Girdğiniz sayı: {girilenSayi} ve bu sayı pozitif çift sayıdır");
            }
            else
            {
                Console.WriteLine($"Girdiğiniz sayı: {girilenSayi} ve bu sayı pozitif çift sayı değildir");
            }

            //4- Girilen 3 sayıyı büyüklük olarak karşılaştırınız
            int girilenSayi1;
            int girilenSayi2;
            int girilenSayi3;
            Console.Write("Birinci sayıyı giriniz: ");
            girilenSayi1 = int.Parse(Console.ReadLine());
            Console.Write("İkinci sayıyı giriniz: ");
            girilenSayi2 = int.Parse(Console.ReadLine());
            Console.Write("Üçüncü sayıyı giriniz: ");
            girilenSayi3 = int.Parse(Console.ReadLine());
            if(girilenSayi1 > girilenSayi2 && girilenSayi1 > girilenSayi3)
            {
                Console.WriteLine("Girdiğiniz ilk sayı en büyük sayıdır");
            }else if (girilenSayi2 > girilenSayi1 && girilenSayi2 > girilenSayi3)
            {
                Console.WriteLine("Girdiğiniz ikinci sayı en büyük sayıdır");
            } else if (girilenSayi3 > girilenSayi1 && girilenSayi3 > girilenSayi2)
            {
                Console.WriteLine("Girdiğiniz üçüncü sayı en büyük sayıdır");
            }
            else
            {
                Console.WriteLine("Girdiğiniz sayılar eşittir");
            }

            //5- Kullanıcıdan 2 vize (%60) ve final (%40) notunu alıp ortalama hesaplayınız
            int vize;
            int final;
            int ortalama;

            Console.Write("Vize notunuzu giriniz: ");
            vize = int.Parse(Console.ReadLine());
            Console.Write("Final notunuzu giriniz: ");
            final = int.Parse(Console.ReadLine());

            int notVize = (vize * 60) / 100;
            int notFinal = (vize * 40) / 100;
            ortalama = (notVize + notFinal) / 2;
            Console.WriteLine($"Vize notunuzun yüzde 60 ı {notVize}, Final notunuzun yüzde 40ı {final} ve ortalamanız {ortalama}");

            //Eğer ortalama 50 ve üstündeyse geçti değilse kaldı yazdırın
            //a- Ortalama 50 olsa bile final notu en az 50 olmalıdır
            //b- Finalden 70 alındığında ortalamanın önemi olmasın
            if(ortalama >= 50 && final >= 50 || final >= 70)
            {
                Console.WriteLine("Dersi geçtiniz");
            }else if(ortalama < 50 && final < 50 || final < 70)
            {
                Console.WriteLine("Dersten kaldınız");
            }

            //6- Kişinin ad,kilo ve boy bilgilerini alıp kilo indekslerini hesaplayınız
            //Formül : (Kilo/boy uzunluğunun karesi)
            string ad;
            double kilo;
            double boy;
            double boyUzunlugununKaresi;
            double indeks;

            Console.Write("Adınızı giriniz: ");
            ad = (Console.ReadLine());
            Console.Write("Kilonuzu giriniz: ");
            kilo = double.Parse(Console.ReadLine());
            Console.Write("Boyunuzu giriniz: ");
            boy = double.Parse(Console.ReadLine());

            boyUzunlugununKaresi = Math.Pow(boy, 2);
            indeks = kilo / boyUzunlugununKaresi;
            Console.WriteLine($"{ad} İsimli kişinin kilo indeksi {indeks}'dir");

            //Aşağıdaki tabloya göre kişi hangi gruba girmektedir
            //0-18.4  => Zayıf
            //18.5-24.9 => Normal
            //25.0-29.9 => Fazla Kilolu
            //30.0-34.9 => Şişman(Obez)
            if(indeks > 0 && indeks <= 18.4)
            {
                Console.WriteLine("Kişi Zayıftır");
            }else if (indeks >= 18.5 && indeks <= 24.9) 
            {
                Console.WriteLine("Kişi Normal Kiloludur");
            }else if (indeks >= 25.0 && indeks <= 29.9)
            {
                Console.WriteLine("Kişi Fazla Kiloludur");
            }else if (indeks >= 30.0 && indeks <= 34.9)
            {
                Console.WriteLine("Kişi Şişman (Obez)");
            }
            else
            {
                Console.WriteLine("Yanlış değer girdiniz");
            }
        }
    }
}
