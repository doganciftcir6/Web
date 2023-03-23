using System;

namespace MetotParametreleri
{
    class Islem
    {
        //dışarıdan parametre alan bir metot oluşturalım
        //prop oluşturmak yerine x ve y parametrelerini dışarıdan alıcaz
        //this dediğimizde işlem sınıfın içindeki proplara geçiş yapıyoruz ancak burada this dememize gerek kalmaz artık
        public int Toplama(int x, int y, int z=0)
            //bu şekilde z=0 dersek z varsayılan olarak 0 atanır ve z ye bir değer göndermek zorunda olmayız değer göndermezsek z sıfıra eşitlenir
            //fakat bunun sırası var her zaman z gibi varsayılan değer atarsak bunu en sonda yapmalıyız ama varsayılanı olmayan parametreleri başta tanımlamalıyız zorunlu olan parametreler başta zorunlu olmayan parametreler sonda tanımlanır
            //ben ne kadar parametre olacağını kestiremediğim zamanlarda yani burda kaç adet sayı toplamak istediğimi bilmediğim durumlarda Params kewordunu kullanabilirim
        {
            Console.WriteLine("x" + x);
            Console.WriteLine("y" + y);
            Console.WriteLine("z" + z);

            return x + y + z;
        }
        public int Toplama2(params int[] numbers)
        //ben ne kadar parametre olacağını kestiremediğim zamanlarda yani burda kaç adet sayı toplamak istediğimi bilmediğim durumlarda Params kewordunu kullanabilirim
        {
            int toplam = 0;
            foreach (var item in numbers)
            {
                toplam += item;
            }
            return toplam;
        }
    }
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
    class MetotParametreler
    {
        static void Main(string[] args)
        {
            //nesne üretip metotu kullanalım
            var islem = new Islem();
            // Console.WriteLine(islem.Toplama(10, 20, 30)); 

            //parametrelere isim vermek mümkün named parametre diyoruz
            // Console.WriteLine(islem.Toplama(z: 30,y: 20,x: 10));

            //buna default parametre deniyor z ye default olarak 0 verdiğimiz için z ye bir değer göndermek zounrda değiliz
            Console.WriteLine(islem.Toplama(10,20));

            //param ile istenilen kadar parametre girebiliyoruz
            Console.WriteLine(islem.Toplama2(2,3,4,5,6,7));
            Console.WriteLine(islem.Toplama2(2,3,4,3));
            Console.WriteLine(islem.Toplama2(2,3,4));

        }
    }
}
