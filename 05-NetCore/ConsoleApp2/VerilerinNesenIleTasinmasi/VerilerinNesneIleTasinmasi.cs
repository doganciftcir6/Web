using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VerilerinNesenIleTasinmasi
{
    //verilerimizi taşımak için bir tane class oluşturucam
    //artık verilerimizi product sınıfı üzerinden taşıyoruz bu sayede
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class VerilerinNesneIleTasinmasi
    {
        static void Main(string[] args)
        {
            //artık uygulama üzerinde products listesiyle çalışabilirim
            var products = GetAllProducts();
            foreach (var pr in products)
            {
                if(pr.Price > 10)
                Console.WriteLine($"name: {pr.Name} price: {pr.Price}");
            }
        }
        static List<Product> GetAllProducts()
        {
            List<Product> products = null;
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();
                    string sql = "select *from products";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    //bir tane liste oluşturucam
                    products = new List<Product>();
                    while (reader.Read())
                    {
                        //products listesinin üzerine add metotu ile yeni bir tane product eklicem
                        products.Add(
                        new Product 
                        {
                            ProductId= int.Parse(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = double.Parse(reader["list_price"]?.ToString())
                        }
                        );
                        Console.WriteLine($"{reader[3]} price: {reader[6]}");
                    }
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
            return products;
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
