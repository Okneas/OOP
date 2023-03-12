using System;
using System.Collections.Generic;

namespace Задание_1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            dynamic d;

            Console.WriteLine("Введите какое-либо значение");

            d = Console.ReadLine();

            Console.WriteLine(d.GetType());

            Console.WriteLine("Во что преобразовать? \n 1. В char \n 2. В string \n 3. В byte \n 4. В int \n 5. В float " +
                "\n 6. В double \n 7. В decimal \n 8. В bool \n 9. В object");

            while(choice > 9 || choice < 1)
            {
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Недопистимое значение выбора!");
                }
            }
            switch (choice)
            {
                case 1:
                    try
                    {
                        d = Convert.ToChar(d);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
                case 2:
                    try
                    {
                       d = Convert.ToString(d);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
                case 3:
                    try
                    {
                        d = Convert.ToByte(d);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
                case 4:
                    try
                    {
                       d = Convert.ToInt32(d);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
                case 5:
                    try
                    {
                        d = Convert.ToSingle(d);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
                case 6:
                    try
                    {
                        d = Convert.ToDouble(d);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
                case 7:
                    try
                    {
                        d = Convert.ToDecimal(d);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
                case 8:
                    try
                    {
                        d = Convert.ToBoolean(d);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
                case 9:
                    try
                    {
                        d = (object)d;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не удалось преобразовать");
                        Console.WriteLine(e);
                        return;
                    }
                    break;
            }
            Console.WriteLine($"Введённые значение теперь имеет тип {d.GetType()}");
        }
    }
}
