using System;

namespace Switchs
{
    class Switch
    {
        static void Main(string[] args)
        {
            int ay = 5;

            //5 e karşılık gelen ay bilgisine göre mevsim bilgisini yazdırmak istiyorum
            //ifElse merdiveni dediğimiz yapıyı alternatif olarak switchcase yapısıyla kurabiliyoruz

            switch (ay)
            {
                //burada caseler ay == 12 mi gibi aynı if mantığını taşıyor ve ben burda 12 yi sorduktan sonra gelir 1 i sormamam gerekiyor dolayısıyla gelip 12 eğer eşitse ay bilgisine bu durumda buraya gelip bir break ekleyerek bir sonraki caseye geçiyor olmamızı engelliyor olmamız gerekiyor yani ay bilgisi 12 ise case 12 çalışacak ve break ile alttaki caseler işlevsiz hale gelecek true değer gelirse yani ama false değer gelirse 12 değilse bir alttaki case1 e geçecektir default ise else bloğuna karşılık geliyor
                //3 4 5 için ilkbahar yazdırılacak şeklinde de kullanım var
                case 12: Console.WriteLine("Kış mevisimi"); break;
                case 1: Console.WriteLine("Kış mevisimi"); break;
                case 2: Console.WriteLine("Kış mevisimi");  break;
                case 3: 
                case 4:
                case 5: Console.WriteLine("ilkbahar mevisimi");  break;
                case 6: Console.WriteLine("yaz mevisimi");  break;
                case 7: Console.WriteLine("yaz mevisimi");  break;
                case 8: Console.WriteLine("yaz mevisimi");  break;
                case 9: Console.WriteLine("sonbahar mevisimi");  break;
                case 10: Console.WriteLine("sonbahar mevisimi");  break;
                case 11: Console.WriteLine("sonbahar mevisimi");  break;
                default: Console.WriteLine("yanlış bilgi"); break;

                    
            }
           
        }
    }
}
