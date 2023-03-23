using System;

namespace StaticMembers
{
    //STATİK SINIF KAVRAMINDA İSE NESNE ÜRETME OLAYI YOK
    //STATİK SINIFTA NESNE ÜZERİNDEN PROPLARA ULAŞIP ONLARI DOLDURMA GİBİ BİR YÜKÜMLÜLÜĞÜMÜZ YOK
    //SINIFI STATİK TANIMLAYARAK SINIFTAN NESNE ÜRETİLMESİNİ ENGELLEYEBİLİYORUZ
    //STATİC SINIF İÇERİSİNDE İNSTINS ÜYELER OLUŞTURAMAYIZ
    //SINIFTAN BİR NESNE ÜRETEBİLİYORSAK İNSTINS SINIF YANİ ÇOĞALTILABİLİR ÖRNEKLENEBİLİR SINIF DENİYOR


    //static üyeleri olan instıns bir sınıf oluşturalım
    class Student
    {
        public string Name { get; set; }
        public int StundentNumber { get; set; }
        //instıns sınıf içerisine statik bir üye eklemek prop eklemek istiyorum diyelim
        //ve içerilerine get setleri silerek bilgi aktarımı yapabiliriz
        public static string School = "my school";
        public static string Address = "my school address";
        //konstraktır buda instıns bir üye
        public Student(string name, int studentnumber)
        {
            this.Name = name;
            this.StundentNumber = studentnumber;
        }
        //metot öğrenci bilgilerini ekrana yazdıracak olan bir instıns metot
        public void DisplayStudentDetails()
        {
            Console.WriteLine($"name: {this.Name} number: {this.StundentNumber}");
        }
        //Bir metot daha ekleyelim buradaki static üyeleri ekrana yazdırsın bu metot 
        //metot static olacak çünkü sınıf üzerinden bu metota ulaşmak istiyorum nesne değil
        //static proplara ulaşmak için this. diyemiyoruz çünkü this. dediğmizde bu sınıf üzerinde üretilecek olan nesneleri hedeflemiş oluyoruz s1 s2 s3 ü temsil etmiş oluyoruz
        public static void DisplaySchoolDetails()
        {
            Console.WriteLine($"school name: {School} address: {Address}");
        }
    }
    //static sınıf oluşturalım yani hiç bir zaman nesnesi üretilmeyecek olan bir sınıf
    //burda oluşturmuş olduğumuz static sınıfın görevi içerisindeki static öğelerle belli işlerimizi o anda yerine getirmek herhangi bir instıns üretilecek bir durum değil bir producttan bir nesne üretip o nesneye özel bir bilgi doldurmak zorunda değiliz
    static class HelperMethods
    {
        //static bir metot
        public static string KarakterDuzelt(string str)
        {
            return str
                .Replace("ö", "o")
                .Replace("ü", "u")
                .Replace("ç", "c")
                .Replace(" ", "-")
                .Replace("ğ", "g");

        }
    }

    class StaticMember
    {
        static void Main(string[] args)
        {
            //instıns olan Student sınıfını kullanalım
            var s1 = new Student("Çınar", 100);
            var s2 = new Student("Sena", 101);
            var s3 = new Student("Yiğit", 102);

            s1.DisplayStudentDetails();
            s2.DisplayStudentDetails();
            s3.DisplayStudentDetails();

            //nesne üzerinden static tanımladığımız proplara ulaşmak istersek static üyeler gelmiyor bunlar direkt sınıf üzerinden gelir Student.Address gibi 
            //static metota da nesne üzerinden ulaşamayız s1.DisplaySchoolDetails() diyemeyiz mesela direkt olarak sınıf üzerinden ulaşmamız gerekiyor çünkü static olduğu için
            Student.DisplaySchoolDetails();

            //static sınıf için 
            string str = "ölçme ve değerlendirme";
            //metotu direkt static sınıf üzerinden kullanlaım
            var result =  HelperMethods.KarakterDuzelt(str);
            Console.WriteLine(result);
            //BU STATİC SINIF OLAYINA MATH SINIFINI ÖRNEK VEREBİLİRİZ Math. DİYEREK BÜTÜN MATH SINIFINDA OLAN METOTLARI NESNE ÜRETMEDEN DİREKT KULLANABİLİYORUZ EN GÜZEL ÖRNEK BU
           
        }
    }
}
