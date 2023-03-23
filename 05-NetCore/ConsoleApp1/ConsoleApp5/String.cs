using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bilgeri satırdan okuyabiliriz yani kullanıcıdan bilgi alarak
            Console.Write("İsminizi Giriniz: ");
            string name = Console.ReadLine();
            Console.Write("Soyisminizi Giriniz: ");
            string surname = Console.ReadLine();
            Console.Write("Yaşınızı Giriniz: ");
            int age = int.Parse(Console.ReadLine());

            //bu bilgileri kullanarak string bir ifade oluşturalım
            // string str = "My name is" + name + " "+ surname + "and I'm" + age +" years old.";
            // Console.WriteLine(str);

            //diğer bir yöntem
            //string.Format() metotu bir string ifade bekliyor ve değişkenlere bu string ifade içerisinde dağıtabiliyoruz yani burada parametre içinde virgülden sonra tanımadlığımız değişkelerin birincisi {0} a denk geliyor ikincisi {1} e denk geliyor üçüncüsü {2} ye denk geliyor böyle böyle gidiyor eğer burada mesela 2 tane {0} {0} şeklinde bir yazım yaparsak name 2 kere yazdırılır dogan dogan şeklinde
            //   string str = string.Format("My name is {0} {1} and I'm {2} years old",name,surname,age);
            //   Console.WriteLine(str);

            //diğer bir yöntem
            //buna template string deniyor
            string str = $"My name is {name} {surname} and I'm {age} years old.";
            Console.WriteLine(str);



        }
    }
}
