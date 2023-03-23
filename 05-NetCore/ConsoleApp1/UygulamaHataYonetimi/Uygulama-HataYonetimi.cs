using System;
using System.Collections.Generic;

namespace UygulamaHataYonetimi
{
    //katmanlı mimari uygulamalarında yani gerçek hayat uygulamalarında
    //Entitiy Katmanına özel olan bir sınıftır
    class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
    //bu Useri nerde kullanırız bu uygulamarında bu sınıfı kullanmak isteriz ancak örneğin xamarin uygulamasında bu usurname ve email proplarına gidecek verilerin istenilen bir formatta olmasını sağlamak gerekiyor ve size uymayan bir karakter belirtilmişse bu durumda uygulama bir exception fırlatması gerekiyor bu durumda custom bir exception oluşturup bu exceptionu fırlatıyor olmamız gerekiyor exceptionu kullanma mantığı güvenli kod yazma açısından büyük önem taşıyor
    //WPF uygulamasında
    //Aspnet core uygulamasında
    //xamarin uygulamasında 
    class Program
    {
        static void Main(string[] args)
        {
            //"1","2","5a","10b","abc","10","50"
            //1- liste içerisindeki sayısal değerleri bulunuz.
            var liste = new List<string>()
            {
                "1","2","5a","10b","abc","10","50"
            };
            //sayısal kontrolü yapmak için döngü kurmamız gerekiyor
            foreach (var item in liste)
            {
                try
                {
                    int a = int.Parse(item);
                    Console.WriteLine(a);
                }
                catch (Exception)
                {
                    //döngü devam etsin istiyorsam //continue ile döngüden çıkmamış olucaz döngü tekrar dönmeye devam edeceks
                    continue;
                }
                
            }

            //2-Kullanıcı 'q' değerini girmedikçe aldığınız her değerin sayısal olup olmadığını kontrol edin aksi halde hata mesajı veriniz
            while (true)
            {
                Console.WriteLine("sayı: ");
                string input = Console.ReadLine();
                if(input == "q")
                {
                    //döngüden çıkalım break ile
                    break;
                }
                //kullanıcının girdiği sayı sayı olmayabilir bize bir exception gelebilir
                try
                {
                    int sayi = int.Parse(input);
                    Console.WriteLine("girdiğiniz sayı: {0}", sayi);
                }
                catch (Exception)
                {

                    Console.WriteLine("geçersiz sayı");
                    //continue ile döngüden çıkmamış olucaz döngü tekrar dönmeye devam edecek yoksa kullanıcı tekrar sayı giremez q harfini girdiği anda da döngüden çıkılır
                    continue;
                }
            }

            //3-Girilen parola içinde türkçe karakter araması yapınız.
            Console.WriteLine("parola: ");
            string parola = Console.ReadLine();
            try
            {
                CheckPassword(parola);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        //metot oluşturalım
        static void CheckPassword(string parola)
        {
            string turkce_karakterler = "ğ,Ğ,ç,Ç,ş,Ş,ü,Ü,ö,Ö,ı,İ";
            foreach (var karakter in parola)
            {
                if(turkce_karakterler.IndexOf(karakter) > -1)
                {
                    throw new Exception("Parola türkçe karakter içeremez");
                }
                Console.WriteLine("Geçerli parola girdiniz");
            }
        }
    }
}
