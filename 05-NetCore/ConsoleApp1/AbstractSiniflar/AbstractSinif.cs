using System;

namespace AbstractSiniflar
{
    class AbstractSinif
    {
        //ABSTRACT SINIFLAR ASLINDA BİZİM İÇİN BİR TEMEL SINIF OLMUŞ OLUYOR VE TEMEL SINIF İÇERİSİNDE ABSTRACT OLARAK İŞARETLEMİŞ OLDUĞUMUZ METOTLARI SONRADAN OLUŞAN SINIFLAR BU ABSTRACT SINIFI BASE OLARAK TEMEL SINIF OLARAK KABUL EDİP KULLANDIKLARINDA ABSTRACT OLARAK TANIMLANAN METOTLARI İMPLEMENTE ETMELERİ GEREKİYOR YANİ DOLDURMALARI GEREKİYOR YANİ BİZ ÖNCEDEN BİR SOYUTLAMA İŞLEMİ YAPMIŞ OLUYORUZ DOLAYISIYLA BURADA DİYEBİLİRİZ Kİ ABSCRAT SINIFI KULLANAN BİR ÜZERİNDEN NESNE TÜRETİLECEK OLAN BİR SINIFIN ASLINDA ÖNCEDEN BİR SÖZLEŞMEYİ BİR YERİNE GETİRMESİ GEREKEN KOŞULLARI KABUL EDİYOR OLMASI ANLAMINA GELİYOR BU SOYUTLAMAYI BİRAZ DAHA ARTTIRIRSAK İNTERFACE YAPSINU KULLANABİLİRİZ
        //ABSTRACTSINIFLAR YANİ SOYUT SINIFLAR İLE BİR SOYUTLAMA İŞLEMİ YAPABİLİYORUZ
        //BAZEN BEN BİR SOYUT SINIF TANIMLAYARAK TEMEL SINIFTAKİ TANIMLAMIŞ OLDUĞUMUZ METOT İÇERİKLERİNİ HER ZAMAN DOLDURMAK İSTEMEYEBİLİRİZ
        //ABSTRRACT METOTLAR İLLA ABSTRACT SINIF İÇERİSİNDE YER ALMAK ZORUNDADIR
        //ABSTRACT SINIFTAN BİR NESNE ÜRETEMEYİZ
        //BAZEN METOTLARIN NE İŞ YAPACAĞINI KESTİREMİYORUZ DOLAYISIYLA ABSRTACT TANIMLAMASI YAPARAK DAHA SONRADAN KALITIM YOLUYLA ÜRETTİĞİMİZ CLASSLAR İÇİNDEO ABSTRACT METOTUN CLASSIN KENDİ İŞİNE YARACAK ŞEKİLDE METOTUN İÇİNİ DOLDURMASINI SAĞLAYABİLİYORUZ YANİ METOT ANA SINIFTA BOŞ İÇERİK KALIYOR AMA DİĞER SINIFLAR KENDİ İŞLERİNE GÖRE O METOTU KENDİLERİ KULLANIYORLAR 
        //METOTU ABSTRACT ŞEKİLDE TANIMLAYIP DİĞER CLASSLAR ÜZERİNDE MUTLAKA İMPLEMENTE EDİLMESİNİ YANİ DOLDURULMASINI SAĞLAYABİLİYORUZ

        //classımzı abstract olarak tanımlayalım
        abstract class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            //kanstraktır
            public Person(string name, string surname)
            {
                this.Name = name;
                this.Surname = surname;
                Console.WriteLine("Person nesnesi oluşturuldu");
            }
            //metot ekleyelim
            //ancak bunu sadece bir tanımlama olarak işaretleyelim ve tanımlama olarak işaretlediğmiz metota ise bir abstract keywordu eklemeliyiz 
            //bu abstract metotu mutlaka Person sınıfını kullanan yani kalıtım yapmış sınıflar kendi içlerinde metotu override etmek zorundalar
            public abstract void Intro();
            //bunun haricinde de tabiki metot tanımlamarınıda yapıp içlerini doldurabiliriz
            public void Greeting()
            {
                Console.WriteLine("I am a Person");
            }
        }
        class Student : Person
        {
            //studentın ekstra özellikleri olabilir
            public string StudentNumber { get; set; }

            //kanstraktır
            public Student(string name, string surname, string studentnumber) : base(name, surname)
            {
                this.StudentNumber = studentnumber;
                Console.WriteLine("Student nesnesi oluşturuldu");
            }

            public override void Intro()
            {
                Console.WriteLine($"name: {this.Name} Surname: {this.Surname} StudentNumber: {this.StudentNumber}");
            }
        }
        class Teacher : Person
        {
            //kendine özgü ekstra özellikleri olsun
            public string Branch { get; set; }
            //kanstraktır
            //Burda yapmamız gereken base keywordu ile dışarıdan gelecek olan name ve surnamei temel sınıfın konstraktırına göndermek
            public Teacher(string name, string surnume, string branch) : base(name, surnume)
            {
                this.Branch = branch;
            }
            //ekstradan bir metot
            public void Teach()
            {
                Console.WriteLine("I am teaching...");
            }
            //ayrıca Intro metotunu override edelim kendine özgü özellikleride ekrana yazdıralım bu sayede
            public override void Intro()
            {
                Console.WriteLine($"name: {this.Name} Surname: {this.Surname} Branch: {this.Branch}");
            }

        }
        abstract class Shape
        {
            public int Width { get; set; }
            public int Hight { get; set; }
            //kasnstraktır 
            //fakat Shape ten bir nesne üretemicez absract sınıf olduğu için dolayısıyla diğer sınıflardan çağırıyor olmamız gerekiyor
            public Shape(int w, int h)
            {
                this.Width = w;
                this.Hight = h;
            }
            //metot
            //eğer temel sınıftaki metotu kullanmak istemiyorsak temel sınıfa gidip metotu abstract yaparız bunu yaptığımızda sınıfıta abstract haline getirmemiz lazım
            //BU SINIFTA BU METOTUN KULLANIM AMACI OLMADIĞI İÇİN OLUŞTURDUK AMA İÇİNİ BOŞ BIRAKTIK
            //ve artık temel sınıfı kullanan sınıflar içerisinde de mutlaka draw metodunu override etmemiz gerekir
            public abstract void Draw();

            //abstract sınıf içerisine normal bir metotta ekleyebiliriz
            public int CalculateArea()
            {
                return this.Width * this.Hight;
            }
            
        }
        class Squere: Shape
        {
            //kanstraktır
            public Squere(int w, int h): base(w,h)
            {
            }
            //metot
            public override void Draw()
            {
                //eğer ben türetmiş olduğum sınıflar içerisinde temel sınıftaki metotları ezmek istiyorsam ve aynı zamanda da temel sınıfta yapmış olduğum işlemleride yine çalıştırmak istiyorsam base keywordini kullanabilirim
                // base.Draw();
                //******eğer temel sınıftaki metotu kullanmak istemiyorsak temel sınıfa gidip metotu abstract yaparız ana sınıfta boş olan bu metot bu sınıfta işime yarayacağı için artık bu metotu burda doldurabilirim
                Console.WriteLine("Draw a Squere");
            }
        }
        class Rectangle : Shape
        {
            //kanstraktır
            public Rectangle(int w, int h) : base(w, h)
            {
            }

            //metot
            public override void Draw()
            {
                //eğer ben türetmiş olduğum sınıflar içerisinde temel sınıftaki metotları ezmek istiyorsam ve aynı zamanda da temel sınıfta yapmış olduğum işlemleride yine çalıştırmak istiyorsam base keywordini kullanabilirim
                //  base.Draw();
                //******eğer temel sınıftaki metotu kullanmak istemiyorsak temel sınıfa gidip metotu abstract yaparız ana sınıfta boş olan bu metot bu sınıfta işime yarayacağı için artık bu metotu burda doldurabilirim
                Console.WriteLine("Draw a Rectangle");
            }
        }
        static void Main(string[] args)
        {
            //Abstract Class: Soyut Sınıf
            
            var s = new Student("Çınar", "Turan", "120");
            var t = new Teacher("Sadık", "Turan", "Bilişim");

            t.Intro();
            s.Intro();
            s.Greeting();

            //Böyle bir kullanımda mevcut
            var shapes = new Shape[3];
            shapes[0] = new Rectangle(10,15);
            shapes[1] = new Squere(15,15);
            shapes[2] = new Rectangle(15,20);
            foreach (var shape in shapes)
            {
                shape.Draw();
                Console.WriteLine(shape.CalculateArea());
            }
            
        }
    }
}
