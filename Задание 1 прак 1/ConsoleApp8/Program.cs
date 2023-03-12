/*                                 ТАБЛИЦА НЕЯВНЫХ ПРЕОБРАЗОВАНИЙ
                 sbyte	short, int, long, float, double, decimal или nint
                 byte	short, ushort, int, uint, long, ulong, float, double, decimal, nint или nuint
                 short	int, long, float, double или decimal либо nint
                 ushort	int, uint, long, ulong, float, double или decimal, nint или nuint
                 int	long, float, double или decimal, nint
                 uint	long, ulong, float, double или decimal либо nuint
                 long	float, doubleили decimal
                 ulong	float, doubleили decimal
                 float	double
                 nint	long, float, double или decimal
                 nuint	ulong, float, double или decimal

                                   ТАБЛИЦА ЯВНЫХ ПРЕОБРАЗОВАНИЙ
                 sbyte	byte, ushort, uint, ulong или nuint
                 byte	sbyte
                 short	sbyte, byte, ushort, uint, ulong или nuint
                 ushort	sbyte, byteили short
                 int	sbyte, byte, short, ushort, uint, ulong или nuint
                 uint	sbyte, byte, short, ushort, int или nint
                 long	sbyte, byte, short, ushort, int, uint, ulong, nint или nuint
                 ulong	sbyte, byte, short, ushort, int, uint, long, nint или nuint
                 float	sbyte, byte, short, ushort, int, uint, long, ulong, decimal, nint или nuint
                 double	sbyte, byte, short, ushort, int, uint, long, ulong, float, decimal, nint или nuint
                 decimal	sbyte, byte, short, ushort, int, uint, long, ulong, float, double, nint или nuint
                 nint	sbyte, byte, short, ushort, int, uint, ulong или nuint
                 nuint	sbyte, byte, short, ushort, int, uint, long или nint
*/
using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    class FirstClass {
        int a = 123;
        string g = "Gek";
    }
    class SecondClass {
        double h = 2.12;
        byte l = 23;
        char c = 'f';
    }
    class ThirdClass {
        public int i;
        public ThirdClass(int i)
        {
            this.i = i;
        }
        public static implicit operator int(ThirdClass t) => t.i;
        public static explicit operator ThirdClass(int k) => new ThirdClass(k);
    }

    class Program
    {
        public static void TryParsing()
        {
            int num;
            string h = "12323";
            if (int.TryParse(h, out num))
            {
                Console.WriteLine($"{num} - {num.GetType()}");
            }
        }
        public static void Parsing()
        {
            try
            {
                int numVal = Int32.Parse("-105");
                Console.WriteLine(numVal);
                Console.WriteLine(numVal.GetType());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void BezPrIs(object obj)
        {
            if(obj is FirstClass)
            {
                Console.WriteLine("Это FirstClass");
            }
            if (obj is SecondClass)
            {
                Console.WriteLine("Это SecondClass");
            }
        }
        public static void Iskl(int i)
        {
            byte b;
            try
            {
                b = Convert.ToByte(i);
                Console.WriteLine($"{b} - {b.GetType()}");
            }
            catch(Exception e) {
                Console.WriteLine("Не удалось преобразовать Int32 в Byte");
                Console.WriteLine(e);
            }
        }
        public static void Neyavnoe(int i)
        {
            double d;
            d = i;
            Console.WriteLine(i.GetType());
            Console.WriteLine(i);
            Console.WriteLine(d.GetType());
            Console.WriteLine(d);
        }
        public static void Yavnoe(int i)
        {
            double d = (int)i;
            Console.WriteLine(i.GetType());
            Console.WriteLine(i);
            Console.WriteLine(d.GetType());
            Console.WriteLine(d);
        }

        static void Main(string[] args)
        {
            FirstClass first = new FirstClass();
            SecondClass second = new SecondClass();
            int i, choice;
            i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1. Явное 2.Неявное");
            choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
                Yavnoe(i);
            }
            else if (choice == 2)
            {
                Neyavnoe(i);
            }

            Iskl(i);

            Console.WriteLine("1. is 2. as");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("1. Проверить перемнную first 2. Проверить перемнную second");
                int cho = Convert.ToInt32(Console.ReadLine());
                if (cho == 1)
                {
                    BezPrIs(first);
                }
                else if (cho == 2)
                {
                    BezPrIs(second);
                }
            }
            else if (choice == 2)
            {
                IEnumerable<int> numbers = new[] { 10, 20, 30 };
                IList<int> indexable = numbers as IList<int>;
                if (indexable != null)
                {
                    Console.WriteLine("IList<int> indexable преобразовался в IEnumerable<int>");
                }
            }
            ThirdClass third = new ThirdClass(10);
            int g = third;
            ThirdClass third2 = (ThirdClass)g;
            Console.WriteLine($" third - {third.GetType()} и равен {third.i} \n g - {g.GetType()} и равен {g} \n third2 - {third2.GetType()} и равен {third2.i}");

            int a = 10;
            string h = Convert.ToString(a);

            Parsing();
            TryParsing();
        }
    }
}
