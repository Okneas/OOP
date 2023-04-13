using System;
using System.Diagnostics;

namespace Задание_3_прак_2
{
    class GCDAlgorithms
    {
        static public Tuple<int, long> FindGCDStein(int u, int v)
        {
            long time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int k;
            // Step 1.
            // gcd(0, v) = v, because everything divides zero, 
            // and v is the largest number that divides v. 
            // Similarly, gcd(u, 0) = u. gcd(0, 0) is not typically 
            // defined, but it is convenient to set gcd(0, 0) = 0.
            if (v == 0)
            {
                sw.Stop();
                time = sw.ElapsedTicks;
                Tuple<int, long> res2 = new Tuple<int, long>(v, time);
                return res2;
            }
            if (v == 0)
            {
                sw.Stop();
                time = sw.ElapsedTicks;
                Tuple<int, long> res = new Tuple<int, long>(u, time);
                return res;
            }
            // Step 2.
            // if u and v are both even, then gcd(u, v) = 2•gcd(u/2, v/2), 
            // because 2 is a common divisor. 
            for (k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }
            // Step 3.
            // if u is even and v is odd, then gcd(u, v) = gcd(u/2, v), 
            // because 2 is not a common divisor. 
            // Similarly, if u is odd and v is even, 
            // then gcd(u, v) = gcd(u, v/2). 

            while ((u & 1) == 0)
                u >>= 1;
            // Step 4.
            // if u and v are both odd, and u ≥ v, 
            // then gcd(u, v) = gcd((u − v)/2, v). 
            // If both are odd and u < v, then gcd(u, v) = gcd((v − u)/2, u). 
            // These are combinations of one step of the simple 
            // Euclidean algorithm, 
            // which uses subtraction at each step, and an application 
            // of step 3 above. 
            // The division by 2 results in an integer because the 
            // difference of two odd numbers is even.
            do
            {
                while ((v & 1) == 0)  // Loop x
                    v >>= 1;
                // Now u and v are both odd, so diff(u, v) is even.
                //   Let u = min(u, v), v = diff(u, v)/2. 
                if (u < v)
                {
                    v -= u;
                }
                else
                {
                    int diff = u - v;
                    u = v;
                    v = diff;
                }
                v >>= 1;
                // Step 5.
                // Repeat steps 3–4 until u = v, or (one more step) 
                // until u = 0.
                // In either case, the result is (2^k) * v, where k is 
                // the number of common factors of 2 found in step 2. 
            } while (v != 0);
            u <<= k;
            sw.Stop();
            time = sw.ElapsedTicks;
            Tuple<int, long> res1 = new Tuple<int, long>(u, time);
            return res1;
        }
        public static Tuple<int, long> FindGCDEuclid(int nod, int _a)
        {
            long time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (nod == 0) {
                sw.Stop();
                time = sw.ElapsedTicks;
                Tuple<int, long> res1 = new Tuple<int, long>(_a, time);
                return res1;
            }
            while (_a != 0)
            {
                if (nod > _a)
                {
                    nod -= _a;
                }
                else
                {
                    _a -= nod;
                }
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            Tuple<int, long> res = new Tuple<int, long>(nod, time);
            return res;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int nod, a;

            Console.WriteLine("Введите два числа");

            nod = Convert.ToInt32(Console.ReadLine());
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(GCDAlgorithms.FindGCDStein(nod, a));
            Console.WriteLine(GCDAlgorithms.FindGCDEuclid(nod, a));
        }
    }
}
