using System;

namespace UygulamaMethods
{
    class Araba
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Renk { get; set; }
        public bool Otomatik { get; set; }

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
                    case "2": this.Hizlan(); break;
                    case "3": this.Yavasla(); break;
                    case "4": this.Stop(); break;
                    default:
                        Console.WriteLine("uygulamadan çıkıldı");
                        break;
                }
            } while (komut != "ç");
        }
    }
    class UygulamaMethod
    {
        static void Main(string[] args)
        {
            //nesne üretelim
            var opel = new Araba();
            opel.Marka = "Opel";
            opel.Model = "Astra";
            opel.Renk = "Beyaz";
            opel.Otomatik = true;

            //bu metotları bu şekilde çağırmak yerine sınıf içerisine bir metot daha ekleyelim
            //opel.Start();
            //opel.Hizlan();
            //opel.Yavasla();
            //opel.Stop();

            //farklı nesne üretelim
            var mazda = new Araba();
            mazda.Marka = "Mazda";
            mazda.Model = "CX3";
            mazda.Renk = "Kırmızı";
            mazda.Otomatik = true;

            //opel.Menu();
            mazda.Menu();
        }
    }
}
