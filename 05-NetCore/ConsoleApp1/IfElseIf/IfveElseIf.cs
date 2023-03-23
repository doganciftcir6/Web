using System;

namespace IfElseIf
{
    class IfveElseIf
    {
        static void Main(string[] args)
        {
            //ekstra koşullar eklemek için ElseIf kullanırız

            Console.Write("x giriniz: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("y giriniz: ");
            int y = int.Parse(Console.ReadLine());

            if (x > y)
            {
                Console.WriteLine("x y den büyüktür");
            }else if (x == y)
            {
                Console.WriteLine("x y ile eşittir");
            }
            else
            {
                Console.WriteLine("y x den büyüktür");
            }

            Console.Write("sayı: ");
            int sayi = int.Parse(Console.ReadLine());
            if(sayi > 0)
            {
                Console.WriteLine("sayı pozitiftir");
            }else if (sayi == 0)
            {
                Console.WriteLine("sayı sıfırdır");
            }
            else{
                Console.WriteLine("sayı negatiftir");
            }
        }
    }
}
