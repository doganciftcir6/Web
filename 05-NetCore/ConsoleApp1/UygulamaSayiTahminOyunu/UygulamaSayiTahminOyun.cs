using System;

namespace UygulamaSayiTahminOyunu
{
    class UygulamaSayiTahminOyun
    {
        static void Main(string[] args)
        {
            //1-100 arasında rastgele tutulan bir sayıyı buldurmaya çalışın
            //puanlama yapınız
            //kullanıcı devam etmek istiyorsa devam etsin

            do
            {
                //rastgele sayı üretelim 1-100 arasında
                int tutulan = (new Random()).Next(1, 100);
                //kullanıcıya hak verelim
                int hak = 5;
                int sayi;
                int tur = 0;
                double soruPuani = 100 / hak;

                //hak 0 dan büyük olduğu sürece kullanıcıya soru sormaya devam edicez
                while (hak > 0)
                {
                    tur++;
                    Console.WriteLine($"{tur}.Sayı: ");
                    sayi = int.Parse(Console.ReadLine());
                    hak--;

                    if (sayi == tutulan)
                    {
                        double puan = 100 - (soruPuani * (tur - 1));
                        //Break kullanamzsak while döngüsü devam edecek
                        Console.WriteLine($"Tebrikler {tur} defada kazandınız.");
                        Console.WriteLine($"Toplam puan: {puan}");
                        break;
                    }
                    else
                    {
                        if (hak == 0)
                        {
                            break;
                        }
                        if (tutulan > sayi)
                        {
                            Console.WriteLine("yukarı");
                        }
                        else
                        {
                            Console.WriteLine("aşağı");
                        }
                    }

                }
                Console.WriteLine($"Oyun bitti. Tutulan sayı {tutulan} ");
                Console.WriteLine("Devam etmek istiyor musunuz ? (e/h): ");
                string result = Console.ReadLine();
                if(result=="h" || result == "hayır")
                {
                    break;
                }

            } while (true);

        }
    }
}
