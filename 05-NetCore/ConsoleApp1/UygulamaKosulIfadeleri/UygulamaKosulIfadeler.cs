using System;

namespace UygulamaKosulIfadeleri
{
    class UygulamaKosulIfadeler
    {
        static void Main(string[] args)
        {
            //1- Kullanıcıdan isim,yaş ve eğitim bilgilerini isteyip ehliyet alabilme durumunu kontrol ediniz. Ehliyet alma koşulu en az 18 ve eğitim durumu lise ya da üniversite olmalıdır

            string isim;
            int yas;
            string egitim;

            Console.WriteLine("Lütfen isminizi giriniz: ");
            isim = Console.ReadLine();
            Console.WriteLine("Lütfen yaşınızı giriniz: ");
            yas = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen eğitim durumunuzu giriniz: ");
            egitim = Console.ReadLine();

            if (yas >= 18)
            {
                if (egitim == "lise" || egitim == "üniversite")
                {
                    Console.WriteLine($"{isim} kişisi Ehliyeti kazandınız tebrikler");
                }
                else
                {
                    Console.WriteLine($"{isim} kişisi Maalesef eğitim durumunuz ehliyet almayı karşılamıyor");
                }
            }
            else
            {
                Console.WriteLine($"{isim} kişisi yaşınız ehliyet almak için uygun değil");
            }


            //2- Girilen 3 sayıdan en büyüğünü bulunuz
            int birinciSayi;
            int ikinciSayi;
            int ücüncüSayi;

            Console.WriteLine("Lütfen birinci sayıyı giriniz: ");
            birinciSayi = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen ikinci sayıyı giriniz: ");
            ikinciSayi = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen üçüncü sayıyı giriniz: ");
            ücüncüSayi = int.Parse(Console.ReadLine());

            if(birinciSayi > ikinciSayi && birinciSayi > ücüncüSayi)
            {
                Console.WriteLine("Birinci sayı en büyük sayıdır");
            }else if (ikinciSayi > birinciSayi && ikinciSayi > ücüncüSayi)
            {
                Console.WriteLine("İkinci sayı en büyük sayıdır");
            }else if (ücüncüSayi > birinciSayi && ücüncüSayi > ikinciSayi)
            {
                Console.WriteLine("Üçüncü sayı en büyük sayıdır");
            }
            else
            {
                Console.WriteLine("Girmiş olduğunuz sayılar birbirine eşittir");
            }


            //3- Bir öğrencinin 2 yazılı bir sözlü notunu alıp hesaplanan ortalamya göre not aralığına karşşılık gelen not bilgisini yazdırınız.
            //0-24 => 0
            //25-44 => 1
            //45-54 => 2
            //55-69 => 3
            //70-84 => 4
            //85-100 => 5

            float ilkYaziliNot;
            float ikinciYaziliNot;
            float sozluNot;
            float ortalama;

            Console.WriteLine("Lütfen ilk yazılı notunuzu giriniz: ");
            ilkYaziliNot = float.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen ikinci yazılı notunuzu giriniz: ");
            ikinciYaziliNot = float.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen sözlü notunuzu giriniz: ");
            sozluNot = float.Parse(Console.ReadLine());

            ortalama = (ilkYaziliNot + ikinciYaziliNot + sozluNot) / 3;

            if(ortalama > 0 && ortalama <= 24)
            {
                Console.WriteLine("Notunuz 0");
            }else if (ortalama >= 25 && ortalama <= 44)
            {
                Console.WriteLine("Notunuz 1");
            }else if (ortalama >= 45 && ortalama <=54)
            {
                Console.WriteLine("Notunuz 2");
            }
            else if (ortalama >= 55 && ortalama <= 69)
            {
                Console.WriteLine("Notunuz 3");
            }else if (ortalama >= 70 && ortalama <= 84)
            {
                Console.WriteLine("Notunuz 4");
            }else if (ortalama >= 85 && ortalama <= 100)
            {
                Console.WriteLine("Notunuz 5");
            }

            //4- Trafiğe çıkış tarihi alınan bir aracın servis zamanını aşağıdaki bilgilere göre hesaplayınız
            //1.Bakım => 1.yıl
            //1.Bakım => 2.yıl
            //1.Bakım => 3.yıl
            //**Süre hesabını alınan gün,ay,yıl bilgisine göre gün bazlı hesaplayınız
            Console.WriteLine("yıl: ");
            int yil = int.Parse(Console.ReadLine());
            Console.WriteLine("ay: ");
            int ay = int.Parse(Console.ReadLine());
            Console.WriteLine("gün: ");
            int gun = int.Parse(Console.ReadLine());

            int toplamGun = (DateTime.Now - new DateTime(yil, ay, gun)).Days;
            if (toplamGun <= 365)
            {
                Console.WriteLine("1.servis");
            }else if (toplamGun>365 && toplamGun <= 365*2)
            {
                Console.WriteLine("2. servis");
            }else if (toplamGun > 365*2 && toplamGun <= 365*3)
            {
                Console.WriteLine("3.servis");
            }
            else
            {
                Console.WriteLine("yanlış bilgi");
            }

        }
    }
}
