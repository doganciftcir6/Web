using MySql.Data.MySqlClient;
using System;

namespace VeriTabanindaTumUrunBilgileriAlinması
{
    class VeriTabanindaTumUrunBilgileriAlmak
    {
        static void Main(string[] args)
        {
            GetAllProducts();
        }
        //ilk olarak bir metot oluşturalım bütün ürün bilgilerini getirecek
        static void GetAllProducts()
        {
            //mysql bağlantı açma işlemini de bu metot içerisinde yapalım
            //artık GetMySqlConnection metotu ile geri dönen bir connection var bu metotu çağırıp direkt bir bağlama yapabiliyoruz
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    //connection.Open() ile açma işlemi
                    connection.Open();
                    //bağlantı sağlandıktan sonra sorgumuzu yazalım
                    string sql = "select *from products";
                    //daha sonra bu sql sorgusunu ilgili connection üzerinden mysql'e gönderiyor olmamız gerekiyor bunun için MySqlCommand isminde bir nesneye ihtiyacımız var
                    //ilk parametre olarak sql sorgusu ikinci parametre olarak SqlConnection bekliyor
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    //böylece sorguyu çalıştırmış olduk ve bize gelecek olan bir liste var ExecuteReader ile 
                    MySqlDataReader reader = command.ExecuteReader();
                    //reader objesi üzerinden veritabanı üzerinden aldığımız tüm veritabanı listesini okuyabiliriz okumak için bir döngü kurucaz
                    //döngü kurma sebebi bize gelen bir sürü veri var mesela 70 kayıt varsa bu döngü 70 kere dönecek ve her döndüğünde biz bir satır bilgiye tek tek ulaşabilicez [3] dediğimizde mesela product_name kolunun bilgisi gelecektir bu sıralama soldan 0 dan başlıyor gidiyor 
                    //burada ürünün ismi ver liste fiyatını aldık mesela
                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader[3]} price: {reader[6]}");
                    }//işimiz bittiğinde de
                    reader.Close();
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
        

        //veritabanı bağlantısı metotu
        static MySqlConnection GetMySqlConnection()
        {
            //bu metot artık ilgili bağlantı cümlesiyle bir connection oluşturucak ve bunu geriye döndürücek
            string connectionString = @"server = localhost;port=3306;database=northwind;user=root;password=mysql1234;";
            return new MySqlConnection(connectionString);
        }
    }
}
