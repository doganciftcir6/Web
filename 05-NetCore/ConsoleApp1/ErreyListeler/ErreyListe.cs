using System;
using System.Collections;

namespace ErreyListeler
{
    class ErreyListe
    {
        static void Main(string[] args)
        {
            //Arraylist tanımlayalım
            //Ancak ben gelip sağda new ArrayList() dediğim kısım yani ArrayList() referansını en başta yazdığım ArrayList içerisine atmak yerine gelip orayı ICollection içerisine atarsam burda ICollection içerisinde hangi metotlar tanımlamalar varsa buraya onlar gelir ancak nesne olarak ArrayList sınıfının nesnesi ürretilir new Arraylist dediğimiz için Arraylist sınıfının kasntraktırı çalışır yani özetler ArrayList nesnesine ICollection metotlarını ve proplarını bağlıyoruz ancak ArrayList metotlarına ve proplarına ulaşamıyoruz mylist. dediğimiz zaman
            //ArrayListin bütün elemanları nesne olarak algılanıyor
            ArrayList mylist = new ArrayList();


            //.Add metotu ile listenin içerisine eleman ekleyebiliyoruz
            //.Add dediğimizde eleman listenin en sonuna eklenir
            //metot bizden obje istiyor ama sonuçta burdaki veri tiplerinin hepsi bir nesneden türetiliyor
            mylist.Add(10);
            mylist.Add("10");
            mylist.Add("abc");
            mylist.Add(10.5);

            //bilgileri bu şekilde de gönderebiliriz kanstraktır üzerinden
            ArrayList myList2 = new ArrayList() { 10, "10", "abc", 10.5 };

            //liste elemanlarına ulaşmak istersek Accesing Items
            //ilk elemana bu şekilde ulaşabiliiriz
            Console.WriteLine(mylist[0]);
            //int bir değişkenin içine elemanı atabiliriz tabi burda tür farketmiyor string felanda olur
            int sayi = (int)mylist[0];

            //liste üzerine bir eleman eklemek istersek Insert kullanırız Insertın Add den farkı istediğimiz bir index numarasına ekleme yapabiliyor olmamız burda 1. indexte 20 değerini atarız
            mylist.Insert(1, 20);

            //liste kopyalama yani myList listesine myList2 Listesini aktarabilirim
            //burada 3. indexten itibaren gel myList2 ' yi ekle diyoruz InsertRange metotu ile eğer AddRange kullanırsan sondan itibaren ekleme yapar
            mylist.InsertRange(3, myList2);

            //liste üzerinden bir eleman silmek istersek .Remove kullanabiliriz 10 elamanını liste üzerinden sildik burda
            mylist.Remove(10);
            //peki eğer ben bunu indexe göre silmek istersem .RemovaAt metotunu kullanırız burda örneğin 2. indexteki elemanı sil demiş oluyoruz
            mylist.RemoveAt(2);
            //listede aynı anda birden fazla elemanı silmek istersek .RemoveRange metotunu kullanabiliiriz 0. indexten başla 2 tane elemanı sil demiş oluyoruz
            mylist.RemoveRange(0,2);

            //herhangi bir eleman liste içerisinde var mı bunun kontrolünü yapmak için .Contains metotunu kullanırız liste içerisinde 10 elemanı var mı yok mu diye sormuş olduk geriye true ya da false değer döndürür varsa true
            Console.WriteLine(mylist.Contains(10));

            //elemanları sıralamak istiyorsak .Sort metotu aracılığıyla küçükten büyüğe elemanları sıralayabiliyoruz veri tiplerinin burda aynı olması gerekiyor eğer hepsi string bilgi ise bu durumda alfabetik olarak bir sıralama yapılır
            ArrayList sayilar = new ArrayList() { 10, 5, 6, 60 };
            sayilar.Sort();


            //elemanlar üzerinde dolaşmak istersek index numarası kullanabildiğimiz için for döngüsüylede olur bu
            foreach (var item in mylist)
            {
                Console.WriteLine(item);
            }

        }
    }
}
