using System;

namespace IfElse
{
    class IfveElse
    {
        static void Main(string[] args)
        {
            //parantez içi true dönüyorsa if bloğu false dönüyorsa else bloğu çalıştırılır
            //3 2 den büyük olduğu için true değer döner ve if bloğu çalışır eğer false dönerse else bloğu çalışacaktır
            string username = "sadikturan";
            string password = "12345";

            var isLoggedin = ((username == "sadikturan") && (password == "12345"));


            if (3 > 2)
            {
            Console.WriteLine("Hello World!");
            }
            //isLoggedin zaten true olduğu için if bloğu otomatik çalışır
            if (isLoggedin)
            {
                Console.WriteLine("bilgileriniz doğru");
                Console.WriteLine("hello");
            }
            else
            {
                Console.WriteLine("username ya da parola yanlış");
            }

            //if bloğu içerisinde if bloğu açabiliyoruz
            //username eğer doğruysa yani true değer gelirse içerideki if bloğuna girilir username doğru yani ilk if true geldi ve sonra parolada doğru yani ikinci if te doğruysa bu durumda bilgileriniz doğru yazdırılır
            //ikinci if bloğunun else bloğunuda tanımlayabiliriz parola yanlışsa sadece parolanın else bloğu çalışır
            if (username == "sadikturann")
            {
                if(password == "12345")
                {
                Console.WriteLine("bilgileriniz doğru");
                Console.WriteLine("hoşgeldiniz");
                }
                else
                {
                    Console.WriteLine("parola yanlış");
                }
            }
            else
            {
                Console.WriteLine("username ya da parola yanlış");
            }
        }
    }
}

