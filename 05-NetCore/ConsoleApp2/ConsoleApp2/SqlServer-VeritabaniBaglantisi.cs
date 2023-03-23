using System;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //metotu main metotu içerisinde kullanalım
            GetSqlConnection();
        }
        //Bağlantı için statik bir metot oluşacak
        static void GetSqlConnection()
        {
            //database e bağlantı yolunu metot içerisine veriyor olmalıyız
            string connectionString = @"Data Source = DESKTOP-4UF23CE;Initial Catalog = Northwind;Integrated Security=SSPI;";
            //şimdi connectionString kullanarak bir bağlantı oluşturucaz
            //bu aşamada driver, provider 'a ihtiyacımız var (soluation'a sağ tıkladıktan sonra manage nuget packages for soluation a tıklıyoruz orda browserdan System.Data.SqlClient aratıyoruz ) onu yükleyip kurduktan sonra
            using (var connection = new SqlConnection(connectionString))
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
