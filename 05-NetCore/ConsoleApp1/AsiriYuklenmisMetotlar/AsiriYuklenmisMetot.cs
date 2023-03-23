using System;

namespace AsiriYuklenmisMetotlar
{
    class AsiriYuklenmisMetot
    {
        //biz bazen aynı isimde birden fazla metot tanımlayabiliriz tanımladığımz her metot ise farklı tipte farklı sayıda parametre alabilir bu gibi durumlarda metot overloading yöntemini kullanırız
        class Islem
        {
            //dışarıdan parametre alan bir metot oluşturalım
            //prop oluşturmak yerine x ve y parametrelerini dışarıdan alıcaz
            //this dediğimizde işlem sınıfın içindeki proplara geçiş yapıyoruz ancak burada this dememize gerek kalmaz artık
             
            public int Toplama(int a, int b)
            {
                return a+b;
            }
            //aynı metotun overloading yaparak 3 parametre alan bir versiyonunu tanımlayabiliirz
            public int Toplama(int a, int b,int c)
            {
                return a + b + c;
            }
            //aynı metotun overloading yaparak 4 parametre alan bir versiyonunu tanımlayabiliirz
            public int Toplama(int a, int b, int c, int d)
            {
                return a + b + c + d;
            }
        }
        class Araba
        {
            public string Marka { get; set; }
            public string Model { get; set; }
            public string Renk { get; set; }
            public bool Otomatik { get; set; }
            public int MaxHiz { get; set; }

            //propları tanıdık ve bu sınıfa hizmet edecek olan bazı metotlarımızı tanımlayalım
            public void Start()
            {
                Console.WriteLine($"{this.Marka} {this.Model} Araba çalıştırıldı");
            }
            public void Stop()
            {
                Console.WriteLine($"{this.Marka} {this.Model} Araba stop edildi.");
            }
            public void Yavasla()
            {
                Console.WriteLine($"{this.Marka} {this.Model} Araba yavaşlıyor.");
            }
            public void Hizlan()
            {
                Console.WriteLine($"{this.Marka} {this.Model} Araba hızlanıyor.");
            }
            //hızlan metodunun başka bir versiyonun tanımlayarak overload yapalım
            public void Hizlan(int km)
            {
                if (km > this.MaxHiz)
                {
                    Console.WriteLine("Maksimum hızı aşamayız");
                }
                else
                {
                    Console.WriteLine($"{this.Marka} {this.Model} {km} km hıza getiriliyor.");
                }
            }
            public void Menu()
            {
                string komut = "";
                do
                {
                    Console.WriteLine("1-Satart 2-Hızlan 3-Yavaşla 4-Stop Çıkış:ç' ye  basınız");
                    Console.Write("Seçiminiz: ");
                    komut = Console.ReadLine();
                    switch (komut)
                    {
                        case "1": this.Start(); break;
                        //overload yaptığımız hizlan metodunu menüde kullanalım
                        case "2": Console.WriteLine("hız bilgisi girmek istiyor musunuz: (e/h)");
                            string secim = Console.ReadLine();
                            if(secim == "e")
                            {
                                Console.Write("Hız: ");
                                int km = int.Parse(Console.ReadLine());
                                this.Hizlan(km);
                            }
                            else
                            {
                                this.Hizlan(); 
                            }
                            break;
                        case "3": this.Yavasla(); break;
                        case "4": this.Stop(); break;
                        default:
                            Console.WriteLine("uygulamadan çıkıldı");
                            break;
                    }
                } while (komut != "ç");
            }
        }
        static void Main(string[] args)
        {
            //overload metotları tek tek kullanalım hangi metotun istediklerini karşılarsak o metot çalışır 2 parametre girersek 2 parametre alan metot çalışır mesela
            Islem islem = new Islem();
            islem.Toplama(2,3);
            islem.Toplama(2,3,3);
            islem.Toplama(2,3,4,5);

            //araba kısmı için nesne
            var mazda = new Araba();
            mazda.Marka = "Mazda";
            mazda.Model = "CX3";
            mazda.Renk = "Kırmızı";
            mazda.Otomatik = true;
            mazda.MaxHiz = 220;

            mazda.Menu();
        }
    }
}
