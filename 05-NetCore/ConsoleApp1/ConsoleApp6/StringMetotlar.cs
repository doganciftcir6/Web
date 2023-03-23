using System;

namespace ConsoleApp6
{
    class StringMetotlar
    {
        static void Main(string[] args)
        {
            //değişken oluşturalım
            string msg = "Hello There. My name is Dogan Ciftci.";
            //String aslında bir class ve içerisinde tanımlanmış bize hazır olarak gelen bazı metotlar var

            //Stringin karakter sayısını bize verir .Length
            Console.WriteLine(msg.Length);

            //.ToLower metotuyla string ifadenin hepsini küçük harfe çevirebiliriz
            Console.WriteLine(msg.ToLower());

            //.ToUpper metotuyla string ifadenin hepsini büyük harfe çevirebiliriz
            Console.WriteLine(msg.ToUpper());

            //String ifadenin başında sonunda boşluk varsa bu boşluklardan kurtulmak için .Trim() metodunu kullanabiliriz sağ ve soldaki bütün boşluk karakterlerini bulur ve siler
            Console.WriteLine(msg.Trim());

            //sadece başındak ve sadece sonundaki boşluk karakterlerini sil diye kullanımda var .TrimEnd() ve .TrimStart()
            Console.WriteLine(msg.TrimEnd());
            Console.WriteLine(msg.TrimStart());

            //.Split() metotu aracılığıyla kaçıncı indexteki elemanı almak istediğimizi belirtiriz [] içine ve Hello döner yani string içeirisndeki tüm kelimelerin bir index nuamrası var örneğin Hello 0 There. 1 gibi biz 0 yazdığımız için sadece Hello konsola yazdırıldı BOŞLUKLARI İŞİN İÇİNE KATMAZ
            Console.WriteLine(msg.Split()[0]);

            //bu şekilde bir kullanım yaparsam ise stringin tüm kelimelerinin her bir karakterine 0 dan başlayarak index verilir ve en baştaki karakteri getirir H yani BOŞLUKLAR İŞİN İÇİNE KATILIR
            Console.WriteLine(msg[0]);

            //.StarsWith() metotu bizden bir string bekliyor "H" olsun yani string ifademiz H karakteri ile mi başlıyor diye sormuş oluyoruz H ile başlıyorsa geriye true başlamıyorsa false döner tabi bütün kelimeyide yazabiliriz "Hello" gibi
            Console.WriteLine(msg.StartsWith("H"));

            //.EndsWith() metotu bizden bir string bekliyor "H" olsun yani string ifademiz H karakteri ile mi bitiyor diye sormuş oluyoruz H ile bitiyorsa geriye true bitmiyorsa false döner tabi bütün kelimeyide yazabiliriz "Hello" gibi
            Console.WriteLine(msg.EndsWith("Hello"));

            //istediğimiz bir karakter string içerisinde var mı yok mu diye sorabiliriz .Contains metotu ile eğer karakter string içerisinde varsa true yoksa false değer döner geriye tabi bütün kelimeyide yazabiliriz "Hello" gibi
            Console.WriteLine(msg.Contains("."));

            //ben istediğim bir karakter string içerisinde var mı diye soruyorum ve bulduğu karakterin konumunu istiyorsam konumu derken soldan 0 dan başlayarak kaçıncı indexte olduğunu söylesin istiyorsam .IndexOf() metotunu kullanırız
            Console.WriteLine(msg.IndexOf("name"));

            //string ifade içerisinden herhangi bir kelimeyi almak istiyorsam .Substring() metotunu kullanmalıyım mesela sadece 5 yazarsak 5. indeksten itibaren string içeriğini geriye döndürür veya 5,10 girersek 5. indexten itibaren 10 karakter getirsin diyebiliyoruz
            Console.WriteLine(msg.Substring(5));
            Console.WriteLine(msg.Substring(5,10));
            //mesela önce "name" nin index numarasını almış olalım ve daha sonra bunun sayesinde "name" den itibaren sona kadar tüm stringi al diyebiliyoruz
            int index = msg.IndexOf("name");
            Console.WriteLine(msg.Substring(index));

            //string içerisinde bir karakteri değiştirmek istersek bu durudma .Replace() metotu kullanılır mesela burda boşluk karakterlerini - ile değiştirdik
            Console.WriteLine(msg.Replace(" ", "-"));
            //ya da Replace yazmaya devam edebiliriz bulduğun nokta karakterlerinide sil diyebiliriz eğer "" içerisine herhangi bir şey yazmasak silme işlemi yapar ve @ işaretlerini de sildirdik ve en sonda da .ToLower diyerek tüm string içeriğini küçük harfe çevirebiliriz
            Console.WriteLine(msg.Replace(" ", "-").Replace(".","").Replace("@","").ToLower());

            //string üzerine bir bilgi eklemek istediğimiz zaman yeni bir eleman eklemek istediğimiz zaman mesela string ifademizin başına ... eklemek isteyelim .Insert() metotunu kullanabiliirz ilk gireceğimiz parametre vereceğimiz içeriği nereye ekleyecek 0 dersek başa eklesin deriz ve diğer parametre ne eklesin ... eklesin deriz
            Console.WriteLine(msg.Insert(0,"..."));
            //peki bunu string sonuna eklemek istersek en sondaki index numarasını vermemiz gerekir bunun yerine msg.Length dersek aynı işi yapar
            Console.WriteLine(msg.Insert(msg.Length, "..."));

            //bir eleman silmek istersek .Remove() metotunu kullanırız tek bir parametre verirsek mesela 5 diyelim soldan 5.indexten itibaren sil diyebiliriz 
            Console.WriteLine(msg.Remove(5));
            //yada 2 parametre belirterek soldan 5. indexten itibaren 10 tane sil diyebiliriz
            Console.WriteLine(msg.Remove(5,10));





        }
    }
}
