using System;

namespace Задане_1_прак_2
{
    public class GCDAlgorithms
    {
        
        int a, b;
        public GCDAlgorithms(int _a, int _b){
            this.a = _a;
            this.b = _b;
        }

        public int FindGCDEuclid()
        {
            if (a == 0) return b;
            while (b != 0)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Введите два целочисленных числа");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            GCDAlgorithms euclid = new GCDAlgorithms(a, b);
            Console.WriteLine(euclid.FindGCDEuclid());
        }
    }
}
