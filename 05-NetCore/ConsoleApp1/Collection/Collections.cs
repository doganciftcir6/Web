using System;

namespace Collection
{
    class Collections
    {
        static void Main(string[] args)
        {
            //eleman gruplamak için  diziler ya da collectionları kullanabiliriz 
            //dizilerde mutlaka dizinin kaç elemanlı olacağını söylememiz gerekiyor yani new [] diyerek bellekte yer ayırtmamız gerekiyor ki bu diziye değer atayabilelim ve ilerleyen zamanlarda mesela 5 elemanlı bir dizi tanımladık o diziyi 6 elemana çıkartamayaız böyle dejavantahjları var

            //Array => fixed size
            int[] sayilar = new int[10];
            sayilar[0] = 10;


            //Collections
            //kullanabileceğimiz 2 tip collection var
            //** non-generic
            //  **Arraylist, SortedList

            //** generic List<int>
            //  **int,string,Product
        }
    }
}
