using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Degisken
    {
        
            //kodlarımız buraya gelecek

            //değişken tanımlaması yapalım
            //tam sayı (byte, short, int, long)
            int sayi = 10;
            long sayi5 = 43434;
            short sayi6 = 5;
            byte sayi7 = 10;
            //Console.WriteLine(sayi); //oluşturmak için kısayolu cw aynı sout gibi

            //ondalıklı sayı 
            //bunların hepsi ondalıklı sayı fakat bellekte kapladıkları yer farklı decimalde hassasiyeti çok daha fazla olan değerler tutabiliriz daha küçük yapıdaki bilgileri float içerisinde saklayabiliriz
            float sayi2 = 10.34f; //sonuna f eklememiz gerekiyor çünkü ondalıklı sayılar varsayılan olarak double kabul ediliyor
            double sayi3 = 30.4;
            decimal sayi4 = 100.56m; //sonuma m eklememiz lazım decimal olduğunu belirtmek için

            //karakter
            string name = "sadık turan"; //stringin her bir elemanı chardan oluşur string bir char dizisidir
            char ch = 'a'; //tek bir karakter tanımı için

            //boolean
            bool isRetired = true;
            bool isActive = false;

            //null değerde atayabiliriz bu sayede değişkenlere nullabel özelliği kazandırabiliriz
            //değişkenin tipinin yanına ? ile nullable olarak işaretlememiz lazım null değer atabilmek için 
            //string için bunu yapmamıza gerek yok çünkü string zaten null bir değer
            int? nullDeger = null;
            string nullString = null;

        }
    }

