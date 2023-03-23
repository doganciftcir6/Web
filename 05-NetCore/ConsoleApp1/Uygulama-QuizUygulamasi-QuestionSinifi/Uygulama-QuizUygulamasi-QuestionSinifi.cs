using System;

namespace Uygulama_QuizUygulamasi_QuestionSinifi
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
        public Question(string text,string[] choices, string answer)
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
            Console.WriteLine(q1.checkAnswer("c#"));
            Console.WriteLine(q2.checkAnswer("Java"));
            Console.WriteLine(q3.checkAnswer("C++"));

            //elimizde olan soruları bir liste içerisine alalım
            var questions = new Question[] {q1,q2,q3};
            //her bir elemena foreach ile ulaşalım
            int index = 1;
            foreach (var item in questions)
            {
                Console.WriteLine($"{index}: {item.Text}");
                index++;
                foreach (var c in item.Choices)
                {
                    Console.WriteLine($"-{c}");
                }
                Console.WriteLine("cevap: ");
                var cevap = Console.ReadLine();
                Console.WriteLine(item.checkAnswer(cevap));

            }
        }
    }
}
