using System;

namespace Methods
{
    class Metotlar
    {
        class Person
        {
            public string Name { get; set; }
            public int Year { get; set; }

            //nesneleri tek tek ekrana yazdırmak yerine bunu yapacak olan bir metot tanımlayabiliriz geriye string döndüren bir metot
            //buradaki this kelimesinin anlamı Person dan türetilecek olan p1,p2,p3 ü kastediyor yani p1 in name alanı p2 nin name alanı p3 ün name alanı şeklinde bu tanımlamayı yapmış oluyoruz
            public string Intro()
            {
                //buradaki string ifadeyi geri döndürmem gerekiyor return ile 
                return $"name: {this.Name} age: {this.CalculateAge()}";
            }
            //yaş hesaplayıp geriye int döndüren bir metot yapalım
            public int CalculateAge()
            {
                return DateTime.Now.Year - this.Year;
            }

        }
        static void Main(string[] args)
        {
            // class ile bir şema oluşturuyoruz ve bu şemadan örnekler oluşturuyorduk örneklerede nesne diyoruz
            //Ogrenci => ogr1, ogr2

            Person p1 = new Person { Name = "Ada", Year = 2012 };
            Person p2 = new Person { Name = "Yiğit", Year = 2010 };
            Person p3 = new Person { Name = "Sena", Year = 1999 };


         //metotu kullanalım return dediğimiz için bunu bir değişnin içinde sakladık ekrana bastırabilmek için
         var str1 = p1.Intro();
         var str2 = p2.Intro();
         var str3 = p3.Intro();
         Console.WriteLine(str1);
         Console.WriteLine(str2);
         Console.WriteLine(str3);
        }
    }
}
