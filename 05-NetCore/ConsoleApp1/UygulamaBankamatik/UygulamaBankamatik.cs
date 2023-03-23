using System;

namespace UygulamaBankamatik
{
    class UygulamaBankamatik
    {
        static void Main(string[] args)
        {
            //menü: bakiye, para yatırma, para çekme, çıkış
            string secim = "";
            double bakiye = 0;
            double ekHesap = 1000;
            double ekHesapLimiti = 1000;

            do
            {
                Console.WriteLine("1-Bakiye Görüntüle\n2-Para Yatırma\n3-Para Çek\n4-Çıkış\nSeçiminiz: ");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": Console.WriteLine("bakiyeniz {0} TL", bakiye);
                              Console.WriteLine("ek hesap bakiyeniz bakiyeniz {0} TL", ekHesap); break;
                    case "2": Console.Write("yatırmak istediğniiz miktar: ");
                              double yatirilan = double.Parse(Console.ReadLine());
                              if(ekHesap < ekHesapLimiti)
                              {
                                  double ekhesaptanKullanilan = ekHesapLimiti - ekHesap;
                                  if(yatirilan >= ekhesaptanKullanilan)
                                  {
                                     ekHesap = ekHesapLimiti;
                                     bakiye = yatirilan - ekhesaptanKullanilan;
                                  }
                                  else
                                  {
                                     ekHesap += yatirilan;
                                  }
                              }
                              else
                              {
                                  bakiye += yatirilan;
                              }
                              break;
                    case "3": Console.Write("çekmek istediğiniz miktar: ");
                              double cekilecekMiktar = double.Parse(Console.ReadLine());
                              if(cekilecekMiktar > bakiye)
                              {
                                 double toplam = bakiye + ekHesap;
                                 if(toplam >= cekilecekMiktar)
                                 {
                                    Console.WriteLine("ek hesap kullanılsın mı? (e/h): ");
                                    string ekHesapTercihi = Console.ReadLine();
                                    if(ekHesapTercihi == "e")
                                    {
                                    Console.WriteLine("paranızı alabilirsiniz.");
                                    ekHesap -= (cekilecekMiktar - bakiye);
                                    bakiye = 0;
                                    }
                                    else
                                    {
                                    Console.WriteLine("bakiyeniz yetersiz");
                                    }
                                 }                                
                              }
                              else
                              {
                                 Console.WriteLine("Paranızı alabilirsiniz.");
                                 bakiye -= cekilecekMiktar;
                              }
                              break;
                    case "4": Console.WriteLine("çıkış"); break;
                    default: Console.WriteLine("hatalı seçim"); break;
                }
            } while (secim != "4");
            Console.WriteLine("Uygulumadan çıkıldı.");

        }
    }
}
