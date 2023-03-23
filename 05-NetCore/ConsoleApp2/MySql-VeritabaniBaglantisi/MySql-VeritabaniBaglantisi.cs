using MySql.Data.MySqlClient;
using System;

namespace MySql_VeritabaniBaglantisi
{
    class Program
    {
        static void Main(string[] args)
        {
            //oluşturduğumuz metotu main içerisinde çağıralım
            GetMySqlConnection();
        }
        //bağlantı sağlamak için bir metot oluşturalım
        static void GetMySqlConnection()
        {
            //database e bağlantı yolunu metot içerisine veriyor olmalıyız
            string connectionString = @"server = localhost;port=3306;database=northwind;user=root;password=mysql1234;";
            //şimdi connectionString kullanarak bir bağlantı oluşturucaz
            //bu aşamada driver, provider 'a ihtiyacımız var (soluation'a sağ tıkladıktan sonra manage nuget packages for soluation a tıklıyoruz orda browserdan MySql.Data aratıyoruz ) onu yükleyip kurduktan sonra
            using (var connection = new MySqlConnection(connectionString))
            {
                //bağlantıyı try catch içinde yapıcam ki hata varsa bizi uyarsın
                try
                {
                    connection.Open();
                    Console.WriteLine("Bağlantı sağlandı.");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
