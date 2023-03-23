using System;

namespace Uygulama1Operatorler
{
    class Uygulama1Operator
    {
        static void Main(string[] args)
        {
            //Uygulama
            int x = 2, y = 5, z = 10;

            //a-Kullanıcıdan aldığınız 2 sayının çarpımı ile x,y,z toplamının farkını bulun
            int birinciSayi;
            int ikinciSayi;
            int carpimlari;
            int toplam;
            int sonuc;

            Console.Write("Lütfen birinci sayıyı giriniz: ");
            birinciSayi = int.Parse(Console.ReadLine());
            Console.Write("Lütfen ikinci sayıyı giriniz: ");
            ikinciSayi = int.Parse(Console.ReadLine());
            carpimlari = birinciSayi * ikinciSayi;
            toplam = x + y + z;
            sonuc = carpimlari - toplam;
            

            Console.WriteLine($"Girdiğiniz birinci sayı {birinciSayi} ve Girdiğiniz ikinci sayı {ikinciSayi} bu sayıların çarpımı ile x,y,z toplamının farkı {sonuc}'dır ");

            //b-Kullanıcıdan alınan bir sayının tek çift kontrolünü yapın
            int alinanSayi;

            Console.Write("Lütfen bir sayı giriniz: ");
            alinanSayi = int.Parse(Console.ReadLine());
            if(alinanSayi % 2 == 0)
            {
                Console.WriteLine($"Girdiğiniz sayı: {alinanSayi} ve sayı çifttir.");
            }else if (alinanSayi % 1 == 0)
            {
                Console.WriteLine($"Girdiğiniz sayı: {alinanSayi} ve sayı tektir.");
            }

            //c-(x,y,z) toplamının mod 3 ü kaçtır
            var mod = (x + y + z) % 3;
            Console.WriteLine(mod);

            //d- y'nin x. kuvvetini hesaplayınız
            var kuvveti = Math.Pow(y, x);
            Console.WriteLine(kuvveti);

        }
    }
}
