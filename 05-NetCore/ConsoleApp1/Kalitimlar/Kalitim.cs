using System;

namespace Kalitimlar
{
    class Person
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
        //bu metot ana sınıftaki metotu ezerek bu sınıf içindeki metot çalışır ancak bunu yapabilmek için ana sınıftaki metota virtual keywordını ekliyor olmamız lazım
        public virtual void Intro()
        {
            //arık p değil this. dememiz gerekiyor this demekle burda Person dan üretilecek olan nesneyi kastetmiş oluyoruz
            Console.WriteLine($"name: {this.Name} Surname: {this.Surname}");
        }
    }
    //Bir Person sınıfımız var ve bu sınıftan kalıtıalcak olan bir Student sınıfımız olsun bunu yapmak için nasıl extends vardı burda extends yok onun yerine : koyarız
    //bu durumda Personun sahip olduğu bütün özellikler Student sınıfınada geçer
    class Student : Person
    {
        //studentın ekstra özellikleri olabilir
        public string StudentNumber { get; set; }

        //kanstraktır
        //student nesnesi oluşturulursa önce Person nesnesini de oluşturmak isteyecek
        //ben studentı oluştururken person için parametreyi de dışarıdan gönderiyor olmam gerekiyor

        //base keywordu ile dışarıdan almış olduğumuz name ve surnamei temel sınıfın yani Person sınıfının iki parametre alan kanstraktırına bunları gönder diyebiliyoruz çünkü Student sınıfınden bir nesene ürettiğimiz zaman kalıtım olduğu için önce Person sınıfındaki kasntraktır tekrar çalışır sonra Student sınıfındaki kanstraktır çalışır bu sayede tekrar tekrar this.bilmemne = bilmemne diye tanımalama yapmamıza gerek kalmaz burda zaten ortak olan özellikler ana sınıfta Person sınıfının metodunda bu işlem yapılmış
        public Student(string name, string surname,string studentnumber) : base (name,surname)
        {
            //studentnumber propu bu sınıfa özgü olduğu için bunu ana sınıfın kanstraktırına gönderemeyiz this.StudentNumber = studentnumber şeklinde tanımlama yapmak zorundayız ekstra propları
            this.StudentNumber = studentnumber;
            Console.WriteLine("Student nesnesi oluşturuldu");
        }

        // ekstra olarak StudantNumber propumuz özelliğimiz vardı onu Ana sınıf yani Person sınıfındaki Intro metotu ile ekrana yazdıramıyoruz çünkü Person sınıfında bu prop yok ancak ben bu metotu gelip Student sınıfının içinde tekrar tanımlayabilirim
        //Student sınıfından bir nesne üretip Intro metodunu kullandığımız zaman bu metot ana sınıftaki metotu ezer bu sınıf içindeki metot çalışır ancak bunu yapabilmek için ana sınıftaki metota virtual keywordını ekliyor olmamız lazım
        //ve bu sınıftaki metotata da override eklememiz lazım
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
        public Teacher(string name, string surnume, string branch):base(name,surnume)
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
    class Kalitim
    {
        static void Main(string[] args)
        {
            //Inheritance (Kalıtım): Miras Alma
            //Person sınıfımız var diyelim => name, surname, age, eat(),drink(),run()
            //peron sınıfında bir kişide olması gereken temel özellikler var ancak ben gelip bir öğrenci ile alakalı bir işlem yapıyorsam student ta bir insan olduğu için Person sınıfından kalıtım yapıp aynı özelliklerin student sınıfına da geçmesini sağlayabilrim ancak student sınıfının kendine özgü ekstra özellikeleri de olabilir
            //Student(Person) => name, surname, age, eat(),drink(),run(),studentNumber
            //yada Teacher sınıfı üreteceksek gene aynı o da bir insan sonuçta ancak Teacher sınıfının kendine ait ekstra özellikleride olabilir
            //Teacher(Person) => name, surname, age, eat(),drink(),run(),branch

            //bir nesne üretelim
            var p = new Person("Ali","Yılmaz");
            //*****************************Biz artık bir student nesnesi olutşurduğumuzda aslında ilk başta persona gider personın konstraktırı oluşturulur yani Person sınıfının konstraktırı önce çalıştırılır sonra Student sınıfının kontraktırı çalıştırılır yani studunttan önce person nesnesi oluşturulur kalıtım olduğu için
            var s = new Student("Çınar","Turan","120");
            //Console.WriteLine($"name: {p.Name} Surname: {p.Surname}");
            //Console.WriteLine($"name: {s.Name} Surname: {s.Surname} number: {s.StudentNumber}");

            var t = new Teacher("Sadık", "Turan", "Bilişim");

            p.Intro();
            //s.Intro dediğimizde yani Student classından Personda bulunan metota ulaşabiliyoruz kalıtttık çünkü ancak burada StudantNumber özelliğimiz vardı onu ekrana yazdıramıyoruz ancak ben bu metotu gidip Student sınıfının içinde tekrar tanımlayabilirim
            s.Intro();

            //temel sınıftaki metota ulaşırız teacherla alakalı proplar burada gelmez onları istiyorsak gidip metotu tekrar override etmemiz gerekiyor ana sınıftaki metota da virtual eklemeyeliyiz
            t.Intro();
            t.Teach();
        }
    }
}
