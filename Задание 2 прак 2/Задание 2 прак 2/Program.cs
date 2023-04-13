using System;
using System.Collections.Generic;

namespace Задание_2_прак_2
{
    class GCDAlgorithms
    {
        public static int FindGCDEuclid(ref int nod, int _a)
        {
            if (nod == 0) return _a;
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
            return nod;

        }
        public static int FindGCDEuclid(ref int nod, params int[] _a)
        {
            for(int i = 0; i < _a.Length; i++)
            {
                nod = FindGCDEuclid(ref nod, _a[i]);
            }
            return nod;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int nod = 0, i = 0;
            int[] a = new int[100000];
            string[] c;
            string b;
            b = Console.ReadLine();
            c = b.Split(" ");
            foreach(string s in c)
            {
                a[i] = Convert.ToInt32(s);
                i++;
            }
            Console.WriteLine(GCDAlgorithms.FindGCDEuclid(ref nod, a));
        }
    }
}
