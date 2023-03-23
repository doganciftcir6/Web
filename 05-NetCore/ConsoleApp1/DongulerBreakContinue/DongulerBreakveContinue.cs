using System;

namespace DongulerBreakContinue
{
    class DongulerBreakveContinue
    {
        static void Main(string[] args)
        {
            //Dongüler: break-continue
            //bu durumda sa yı yazar ve d ye geldiğinde break kelimesini gördüğü için döngü durdurulur özetle break kelimesi break komutunu döngü içeirsinde herhangi bir şart yerine getirildiği zaman o durumda eğer döngüden çıkmak istiyorsak break kelimesini kullanabiliriz
            //Break yerine continue kullanırsak eğer burda d gelmez diğer charlar yazdırılır yani continue döngüyü olduğu gibi bitirmiyorda o anda d karakterine geldiği continue ile karşılaşan uygulama o anda döngünün turunu iptal eder yani d için dönmüş olduğu tur iptal edilir ancak döngü dışına çıkılmaz bir sonraki karakterden devam edilir sadece ekrana d yi yazdırmamış oluruz diğer karakterler yazdırılır
            string name = "Sadık Turan";
            for(int i = 0; i < name.Length; i++)
            {
                if(name[i] == 'd')
                {
                    break;
                }
                Console.WriteLine(name[i]);

                //whileda yapalım
                //0 dan başlar ve 2 olduğunda döngü sonlandırılır 0 1 den sonrasını yazmaz break yüzünden
                //eğer breakı continue ile değiştirirsek sonsuz bir döngüye gireriz çünkü x 2 olduğunda döngünün başına gidilir ve döngünün başına geldiğinde x sürekli 2 ve sürekşi 5 ten küçük olduğu için bu durumdan çıkmak için x++ yı iften önceye yazarız bu durumda da sadece 2 yazdırılmaz geri kalan elemanlar yazdırılır
                int x = 0;
                while (x < 5)
                {
                    if (x == 2)
                        break;
                    Console.WriteLine(x);
                    x++;
                }

                //bir örnek daha
                //1-100 arasındaki tek sayıların toplamı
                int z = 1;
                int toplam = 0;
                while (z<100)
                {
                    //ne zaman sayı mod 2 si 0 yani sayı çift continue'la döngüyü o anda kesiyoruz alt satıra gitmesini engelleyip başa döndürüyoruz ve başa döndürüp zyi bir arttırıyor ve tekrar 
                    if (z % 2 == 0)
                        continue;
                    toplam += z;
                    z++;
                }
                Console.WriteLine("toplam" + toplam);




            }
        }
    }
}
