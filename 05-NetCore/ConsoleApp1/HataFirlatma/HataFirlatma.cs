using System;
using System.Linq;

namespace HataFirlatma
{
    class Person
    {
         string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(value.Length > 15)
                {
                    throw new Exception("Name için en fazla 15 karakter girmelisiniz");
                }
                _name = value;
            }
        }
    }
    class HataFirlatma
    {
        //Bir tane metot tanımlıcam
        static void check_password(string password)
        {
            if(password.Length < 8 || password.Length > 15)
            {
                throw new Exception("Parola 7-15 karakter arasında olmalıdır");
            }
            //Ant metotu aracılığıyla password içerisinde her gelen karakter kontrol edilir kontrol edilirken IsDigit olması yani karakterler içerisinden sadece bir tanesi rakam olması bana true değerini gönderir herhangi bir tanesi rakam değilse bu durumda da geriye false değerini döndürür tam tersini alıcam ! ile yani herhangi bir rakam yoksa bu durumda bi exception fırlatalım
            if (!password.Any(char.IsDigit))
            {
                throw new Exception("Parola en az bir rakam içermelidir.");
            }
            //passwordda en az bir harf varsa true yoksa false gelir bunun tam tersini alıcaz .Isletter sayesinde
            if (!password.Any(char.IsLetter))
            {
                throw new Exception("Parola en az bir harf içermelidir.");
            }
        }
        static void Main(string[] args)
        {
            //bu zamana kadar hatalar sistem tarafından otomatik olarak fırlatılıyordu biz o hataları catch blokları sayesinde yakalıyorduk fakat bazen bizim hata saydığımız bir şeyi sistem hata olarak saymayabiliyor bu durumda biz hatayı kendimiz manuel olarak elle fırlatmamız gerekiyor

            int sayi = 10;
            //sayı 5 ten büyükse ben bunu hata olarak sayabilirim mesela
            //throw new Exception() aracılığıyla bir hata fırlatabilirim hatanın mesajını ise parantez içerisinde yazarız
            if(sayi > 5)
            {
                throw new Exception("sayı 5 ten büyük olamaz");
            }


            //oluşturduğumuz metotu kullanalım
            string parola = "1234567a";
            try
            {
                check_password(parola);
                Console.WriteLine("Parola geçerli.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //oluşturduğumuz classı kullanalım
            try
            {
                var p = new Person();
                p.Name = "Sadık";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
