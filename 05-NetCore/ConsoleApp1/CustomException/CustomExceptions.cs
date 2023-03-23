using System;

namespace CustomException
{
    //neden bir exception sınıfı oluşturma ihtiyacı duyarız
    //rutün işlemlerimiz için bir Exception oluşturabiliriz
    //yada uygulama kendine özel oluşturulmuş olduğu Exceptionları da kullanabiliyor örneğin IndexOutOfRangeException => dizi sınırı aşma durumunda
    //örneğin bir Login işlemi yapmak istiyoruz ve login işlemi sırasında dışarıdan bir username,parola alıyoruz Login => username, password alıyor olmamız gerekiyor ve bu username ve passwordu örneğin daha önceden yazmış olduğumuz bir sınıf kütüphanesi içerisindeki bir metota parametre olarak göndericez ve gönderdiğimiz username acaba gerçekten de bir username mi bunun olması için belli kriterlere uyuyor mu eğer username bizim istediğimiz kriterlerde değilse bu durumda ilgili kendi oluşutruduğumuz exception sınıflarını fırlatıyor olammız gerekiyor ve bu Login metotunu kullanan bütün projelerde ise bu durum mutlaka ele alınıyor olması gerekiyor dolayısıyla Login metodunu kullandığımız istediğimiz proje tipinde uygulamalarımızı bir yerden yönetip güvenli kod yazmış oluyoruz

    //bir custom exception oluşturalım
    class LoginException: Exception
    {
        //kanstraktır eklicez Exception özellikleri için
        public LoginException(string message) : base(message)
        {

        }

    }
    class CustomExceptions
    {
        static void Main(string[] args)
        {
            try
            {
                //Login metotodumuzu çağıralım
                Login("sadik turan", "123456");
                Console.WriteLine("Login başarılı olmuştur.");
            }
            catch (LoginException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //static bir metot oluşturalım burda
        static void Login(string username, string password)
        {
            if(username.Contains(" "))
            {
                //kanstraktır tanımladığımız için () içi artık bizden bir message bekliyor
                throw new LoginException("Username boşluk içeremez.");
            }
            if(password.Length < 8)
            {
                throw new Exception("Parola min. 8 karakter olmalıdır.");
            }
        }
    }
}
