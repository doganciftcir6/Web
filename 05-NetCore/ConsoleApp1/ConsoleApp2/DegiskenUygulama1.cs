using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class DegiskenUygulama1
    {
      
            //null değerde atayabiliriz bu sayede değişkenlere nullabel özelliği kazandırabiliriz
            //değişkenin tipinin yanına ? ile nullable olarak işaretlememiz lazım null değer atabilmek için 
            //string için bunu yapmamıza gerek yok çünkü string zaten null bir değer
            int? nullDeger = null;
            string nullString = null;


            //kilo bilgisi tutacak bir değişken(byte,short,int,long)
            byte kilo1 = 5;
            short kilo2 = 10;
            int kilo3 = 40;
            long kilo4 = 115;
            //plaka bilgisi tutacak bir değişken
            string plaka = "34 ABC 3434";
            //Araç km bilgisini tutan bir değişken
            float kmBilgisi = 104.343f;
            //müşteri id'sini tutacak bir değişken
            int musteriId = 10;
            //bir ürünün satışta olup olmadığı bilgisini tutacak bir değişken
            bool satistaMi = false;
            //maaş bilgisini tutacak bir değiken
            decimal maas = 4000.10000m;
            //Öğrenci adını ve soyadını tutacak bir değişken
            string adSoyad = "Doğan Çiftçi";
            //Şube kodunu tutacak bir değişken (örneğin : A)
            char subeKodu = 'A';


        }
    }

