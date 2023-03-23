using System;

namespace HataVeHataYonetimi
{
    class Prodcut
    {
        public string Name { get; set; }
    }
    class HataYonetimi
    {
        static void Main(string[] args)
        {
            //Exception
            //.net uygulamalarında hatalar bir Exception nesenesi ile tanımlanıyor
            //çalışma zamanında programı yazarken öngöremediğimiz hatalara Exception diyoruz çünkü hata bize bir Exception nesnesi içerisinde paketlenip gönderiliyor  
            //TÜM HATALAR TEMELDE EXCEPTİON SINIFINI KULLANIRLAR

            //Exception oluşturulacak durum yaratalım
            //kulannıcı int dışında bir değer girerse program sonlandırılır FormatException alırız
            //Unhandled exception. System.FormatException
            //veya kullanıcı burda birinci sayıya 10 ikinci sayıya 0 girerse bu durumda DivideByZeroException alırız
            //bu durumları biz öngöremeyiz dolayısıyla bu hatalar için uygulamayı sonlandırmak yerine kullanıcıyı uyarmamız gerekiyor
            Console.WriteLine("1. Sayı: ");
            int sayi = int.Parse(Console.ReadLine());
            Console.WriteLine("2. Sayı: ");
            int sayi2 = int.Parse(Console.ReadLine());
            var sonuc = sayi / sayi2;

            //2 numaraları indexe bir değer atamak istersek hata alırız çünkü dizi 2 elemanlı 0 ve 1 indexten oluşuyor bu durumda IndexOutOfRangeExcetion hatası alırız
            int[] sayilar = new int[2];
            sayilar[2] = 10;

            //class oluşturduk ve burda new diyerek bir referans vermiyor olalım bu durumda NullReferanceException hatası alırız olmayan bir nesne üzerinden işlem yapmış oluruz
            Prodcut p = null;
            Console.WriteLine(p.Name);



            //Excetion Handling
            //Exception nesnesi bize geldiğinde yani hatanın tanımlamasını içeren bir obje bize geldiğinde objeyi ele almak istediğimzide ise Exception Handling yani hata yönetimi durumlarını ele alıyor olmamız gerekiyor
            //hataya karşı bir önlem alıyor olmamız gerekiyor bana bir Exception gelirse uygulamam çalışmayı durdurmak yerine bana burda tanımlamış olduğum özellikleri uygula şeklinde

            //kullanıcıdan 2 tane sayı alalım
            //10 / 0 derse kullanıcı bir hata çıkar DivideByZeroException hatası gelir
            //bü yüzden bunu öngörürsek hata gelebilecek olan kısımları try catch bloğu içerisine almamız gerekiyor
            //bu sayede uygulama hata geldiğinde sonlanmak yerine catch bloğu içerisindeki mesaj kullanıcıya gösterilir
            //biz bu durumda catch bloğu içerisine sadece DivideByZeroException yazarak kullanıcının 0 a bölme hatasını yakalamış olduk fakat kullanıcı gidip int değer girmek yerine string bir ifade girerse bu seferde FormatException hatası gelir uygulama yine sonlanır dolayısıyla bu durudma biz bir catch bloğu daha oluşturabiliriz
            //bu hatalar sadece kullanıcıya veriliyor peki bu hata mesajlarını biz bir yerde saklamak isteriz örneğin bir veritabanında bunu kaydedip daha sonra uygulamaya gelen kullanıcıların aldığı hataları biz görüntülemek isteyebiliriz dolayısıyla catch blokları içinde hata tanımlamasından sonra isim verebiliriz
            try
            {
                Console.WriteLine("a: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("b: ");
                int b = int.Parse(Console.ReadLine());
                var result = a / b;
                Console.WriteLine($"{0} / {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException ex) //Excetion Handling DENİYOR BUNA
            {
                Console.WriteLine("b sıfır olamaz");
                //ex. dediğimizde artık belli özelliklere ulaşabiliyoruz yani ex nesnesi hatayla ilgili bilgilere ulaşmamızı sağlıyor bu sayede biz bunu bir yerde saklayabiliriz
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Sayısal bilgi girmelisiniz");
                Console.WriteLine(ex.Message);
            }
            //bunların haricinde daha bir çok hata türü mevcut dolayısıyla catch bloğu içerisinde tüm hataların türetildiği Exception nesnesini tanımlayabiliriz böylece tüm hataları aynı anda yakalamış oluruz genel bir kullanım olmuş olur
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu");
                Console.WriteLine(ex.Message);
            }
            //en altta bir finally bloğu açabiliyoruz bu blok içerisinde try bloğu içerisinden gelen bir hata olsun ya da olmasın eğer hata varsa zaten ilgili catch bloğu içerisindeki kod blokları çalıştırılır yani bizim hatamız olsun ya da olmasın çalıştırılacak olan bir kodumuz varsa bunuda finally bloğu içerisinde tanımlarız
            finally
            {
                Console.WriteLine("finally bloğu çalıştı.");
            }
            

        }
    }
}
