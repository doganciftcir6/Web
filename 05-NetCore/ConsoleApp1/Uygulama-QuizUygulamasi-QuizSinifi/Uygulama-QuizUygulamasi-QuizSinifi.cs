using System;

namespace Uygulama_QuizUygulamasi_QuizSinifi
{
    //her bir soru Question sınıfından üretilecek olan bir nesne olacak
    class Question
    {
        //sorumuzun kendisi burada 
        public string Text { get; set; }
        //sorunun şık bilgileri burada bir sorunun birden fazla şıkkı olabilir dizi yapalım
        public string[] Choices { get; set; }
        //doğru cevabı burda saklıyoruz
        public string Answer { get; set; }

        //Question nesnesi oluşturulduğu anda biz proplarımıza değerleri direkt atayalım dolayısıyla konstraktır
        public Question(string text, string[] choices, string answer)
        {
            //dışarıdan gönderdiğimiz text bilgisini sınıfın text bilgisine atayalım vs
            this.Text = text;
            this.Choices = choices;
            this.Answer = answer;
        }
        //cevap için bir metot oluşturalım cevabı kontrol eden bir metot olacak
        public bool checkAnswer(string answer)
        {
            return this.Answer.ToLower() == answer.ToLower();
        }
    }
    //her bir soruyu kontrol edecek olan yönetecek olan bir Quiz sınıfı oluşturucaz zaten bu uygulamamızın kendisi olacak
    class Quiz
    {
        //Quiz sınıfından bir nesne ürettiğimiz zaman bu nesne dışarıdan gelsin Questionları alsın istiyorum
        private Question[] Questions { get; set; }
        //buradaki [] içerisindeki index numaralarını kendim oluşturmucam bunu Quiz sınıfı yönetsin
        public int QuestionIndex { get; set; }

        //Soruları olmayan bir Quiz bizim için pek anlam ifade etmiyor dolayısıyla kanstraktır ile Quiz nesnesi oluşturulduğu anda parametreyi dışarıdan alalım
        public Quiz(Question[] questions)
        {
            this.Questions = questions;
            this.QuestionIndex = 0;
        }
        //metot ekleyelim ki class dışarısında direkt Quiz üzerinden questionlara ulaşmayalım bize istediğimiz questionu  veren bir metot olabilir
        public Question GetQuestion()
        {
            return this.Questions[this.QuestionIndex];
        }
        //soruları gösterecek olan bir metot
        public void DisplayQuestion()
        {
            //soruları gösterelim
            var question = this.GetQuestion();
            Console.WriteLine($"soru {this.QuestionIndex+1}: {question.Text}");
            //şıkları göstermek için
            foreach (var c in question.Choices)
            {
                Console.WriteLine($"-{c}");
            }
            //kullanıcıdan cevapları alallım sonrasında
            Console.WriteLine("Cevap: ");
            var cevap = Console.ReadLine();
            //bir metot tanımlıcam
            this.Guess(cevap);
        }
        //döngü kurmak yerine yeni bir metotla metot içerisinde bir önceki metotu çağırarak ve ayrıca çağırmadan önce questionindexi bir arttırarak tüm soruların sıra sıra gelmesini sağlayabiliyoruz
        public void Guess(string answer)
        {
            var question = this.GetQuestion();
            Console.WriteLine(question.checkAnswer(answer)); //skor
            this.QuestionIndex++;
            if(this.Questions.Length == this.QuestionIndex)
            {
                //skor 
                return;
            }
            else
            {
                this.DisplayQuestion();
            }
            this.DisplayQuestion();
            //uygulama nerde biteceğini bilmiyor şuan 3. sorudan sonra hata almaya başlarız if diye kontrol yapıcaz o yüzden
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Question classı üzerinden soru oluşturalım
            var q1 = new Question("En iyi programlama dili hangisidir?", new string[] { "Python", "C#", "Java", "C++" }, "C#");
            var q2 = new Question("En popüler programlama dili hangisidir?", new string[] { "C#", "Python", "Java", "C++" }, "C#");
            var q3 = new Question("En çok kazandıran programlama dili hangisidir?", new string[] { "C#", "Java", "Python", "C++" }, "C#");
            //her bir sorunun kendisini yazdırabiliriz ancak bunu sınıflar içerisindeki metotlara yaptıralım
            //  Console.WriteLine(q1.Text);

            //sadece ilkinde true değeri gelecek diğerleri false getirir
            //Console.WriteLine(q1.checkAnswer("c#"));
            //Console.WriteLine(q2.checkAnswer("Java"));
            //Console.WriteLine(q3.checkAnswer("C++"));

            //elimizde olan soruları bir liste içerisine alalım
            var questions = new Question[] { q1, q2, q3 };
            //her bir elemena foreach ile ulaşalım
            //int index = 1;
            //foreach (var item in questions)
            //{
            //    Console.WriteLine($"{index}: {item.Text}");
            //    index++;
            //    foreach (var c in item.Choices)
            //    {
            //        Console.WriteLine($"-{c}");
            //    }
            //    Console.WriteLine("cevap: ");
            //    var cevap = Console.ReadLine();
            //    Console.WriteLine(item.checkAnswer(cevap));
            //}

            //Quiz sınıfından nesne oluşturucaz
            //daha önce oluşturduğumuz questions listesini parametre olarak verelim
            var quiz = new Quiz(questions);
            //ne zaman Quiz içeirisndeki bir soruya ihtiyacım olursa
            //buradaki [] içerisindeki index numaralarını kendim oluşturmucam bunu Quiz sınıfı yönetsin
            //QuestionIndex i her bir arttırdığımızda bir sonraki soruya geçiş yapmış oluruz dolayısıyla Quiz sınıfı içerisine ekleyeceğimiz bir metot olabilir bu metot bize question bilgilerini getirir
            //Console.WriteLine(quiz.GetQuestion().Text);
            //quiz.QuestionIndex++;
            //Console.WriteLine(quiz.GetQuestion().Text);
            //quiz.QuestionIndex++;
            //Console.WriteLine(quiz.GetQuestion().Text);
            //quiz.QuestionIndex++;

            //BU ŞEKİLDE TEK TEK İNDEX NUMARALARINI ARTTIRMICAZ bunu arttırma işlemini quiz sınıfı yapacak gidip DisplayQuestion diye metot oluşturalım ve burda kullanalım
            quiz.DisplayQuestion();


        }
    }
}
