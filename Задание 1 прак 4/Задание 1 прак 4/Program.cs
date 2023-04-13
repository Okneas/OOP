using System;

namespace Задание_1_прак_4
{
    struct Complex
    {
        float real;
        float img;

        public Complex(float a, float b)
        {
            this.real = a;
            this.img = b;
        }
        public void print()
        {
            if(this.img >= 0)
                Console.WriteLine($"{this.real}+{img}i");
            else
                Console.WriteLine($"{this.real}{img}i");
        }
        public static Complex operator +(Complex a, float b)
        {
            a.real += b;
            return a;
        }
        public static Complex operator *(Complex a, float b)
        {
            a.real *= b;
            a.img *= b;
            return a;
        }
        public static Complex operator +(Complex a, Complex b)
        {
            Complex c = new Complex(a.real+b.real, a.img+b.img);
            return c;
        }
        public static Complex operator -(Complex a, Complex b)
        {
            Complex c = new Complex(a.real - b.real, a.img - b.img);
            return c;
        }
        public static Complex operator *(Complex a, Complex b)
        {
            Complex c = new Complex((a.real * b.real - a.img * b.img), (a.real * b.img + b.real * a.img));
            return c;
        }
        public static Complex operator /(Complex a, Complex b)
        {
            Complex c = new Complex((a.real*b.real+a.img*b.img)/(b.real* b.real+b.img* b.img), (a.img*b.real-a.real*b.img)/(b.real * b.real + b.img * b.img));
            return c;
        }
        public static bool operator ==(Complex a, Complex b)
        {
            if(a.real==b.real && a.img == b.img)
                return true;
            else
                return false;
        }
        public static bool operator !=(Complex a, Complex b)
        {
            if (a.real == b.real && a.img == b.img)
                return false;
            else
                return true;
        }
        public override string ToString()
        {
            if(this.img >= 0)
                return $"{this.real}+{this.img}i";
            else
                return $"{this.real}{this.img}i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(2, -3);
            Complex b = new Complex(8, 4);
            Complex c = new Complex();

            c = a + b;
            c.print();
            c = a - b;
            c.print();
            c =a * b;
            c.print();
            c = a / b;
            c.print();
            if(a != b)
            {
                string s = c.ToString();
                Console.WriteLine(s);
            }
        }
    }
}
