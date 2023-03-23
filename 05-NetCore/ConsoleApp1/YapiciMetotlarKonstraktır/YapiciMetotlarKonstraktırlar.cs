using System;

namespace YapiciMetotlarKonstraktır
{
    class YapiciMetotlarKonstraktırlar
    {
        //biz bazen aynı isimde birden fazla metot tanımlayabiliriz tanımladığımz her metot ise farklı tipte farklı sayıda parametre alabilir bu gibi durumlarda metot overloading yöntemini kullanırız
        class Islem
        {
            //dışarıdan parametre alan bir metot oluşturalım
            //prop oluşturmak yerine x ve y parametrelerini dışarıdan alıcaz
            //this dediğimizde işlem sınıfın içindeki proplara geçiş yapıyoruz ancak burada this dememize gerek kalmaz artık

            public int Toplama(int a, int b)
            {
                return a + b;
            }
            //aynı metotun overloading yaparak 3 parametre alan bir versiyonunu tanımlayabiliirz
            public int Toplama(int a, int b, int c)
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
            //bir konstraktır oluşturalım ki nesne oluşturduktan sonra değer atamak yerine konstraktırlar sayesinde nesne oluşturma sırasında değer atama yapabiliyoruz bunun kısayolu ctor
            //new Araba() dediğimiz adna konstraktır metotu çalıştırılır
            //new Araba() diyip nesne oluştururken buradaki parametlereli girmek zorunda oluruz artık
            public Araba(int maxhiz )
            {
                //this.MaxHiza dışarıdan gönderdiğimiz maxhiz ı atayalım
                this.MaxHiz = maxhiz;
            }
            //Bir konstraktır daha oluşturalım ve parametre girmeyelim bu sayede new Araba() dediğimizde parametre girmek zorunda kalmayız
            public Araba()
            {
                //parametre almayan durumda proplara default değerler atayabiliyoruz
                this.MaxHiz = 180;
                Console.WriteLine("yapıcı metot çalıştırıldı.");
            }
            //Bir konstraktır daha oluşturalım overload yapalım yani diğer propların hepsini burda alalım
            public Araba(string marka, string model, string renk, bool otomatik, int maxhiz)
            {
                this.Marka = marka;
                this.Model = model;
                this.Renk = renk;
                this.Otomatik = otomatik;
                this.MaxHiz = maxhiz;
            }

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
                        case "2":
                            Console.WriteLine("hız bilgisi girmek istiyor musunuz: (e/h)");
                            string secim = Console.ReadLine();
                            if (secim == "e")
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
            islem.Toplama(2, 3);
            islem.Toplama(2, 3, 3);
            islem.Toplama(2, 3, 4, 5);

            //araba kısmı için nesne
            //bu şekilde nesne oluşturduktan sonra değer atamak yerine konstraktırlar sayesinde nesne oluşturma sırasında değer atama yapabiliyoruz
            //bunu dediğimiz anda konstraktır çalışır
            var mazda = new Araba(200);
            Console.WriteLine(mazda.MaxHiz);
            //mazda.Marka = "Mazda";
            //mazda.Model = "CX3";
            //mazda.Renk = "Kırmızı";
            //mazda.Otomatik = true;
            //mazda.MaxHiz = 220;

            var opel = new Araba("Mazda","CX3","Kırmızı",true,220);
            Console.WriteLine(opel.Marka);
            Console.WriteLine(opel.Model);
            Console.WriteLine(opel.Renk);
            Console.WriteLine(opel.Otomatik);
            Console.WriteLine(opel.MaxHiz);

            mazda.Menu();
        }
    }
}
