using System;

namespace PZ_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение b: "); // на консоль пользователю выводится надпись
            int b = Convert.ToInt32(Console.ReadLine()); // пользователь вводит значения числа b с типом int
            Console.Write("Введите значение f: "); // на консоль пользователю выводится надпись
            double f = Convert.ToDouble(Console.ReadLine()); // пользователь вводит значения числа f с типом double
            double p, t, r; // добавляем переменные, значение которых нужно будет вычислить

            if (b > 0 && b > f) // проверяем условия, условие b>f добавляется, чтобы не было деления на 0 и отрицательного числа под корнем
            {
                p = f * Math.Cos(b) / Math.Sqrt(Math.Abs(Math.Pow(b, 2) - Math.Pow(f, 2))); // вычисляем p, добавляем Math.Abs, чтобы не было отрицательного числа под корнем
            }
            else // иначе
            {
                p = 2 * f - Math.Sin(b); // вычисляем p по другой формуле
            }

            if (p <= 0) // если значение числа p меньше или равно 0, то
            {
                t = Math.Pow(Math.Sin(b * f), 2) - Math.Pow(Math.Cos(b + p), 2); // вычисляем t
            }
            else // иначе
            {
                t = Math.Pow(Math.Sin(b * p), 2) - Math.Pow(Math.Cos(b - p), 2); // вычисляем t по другой формуле
            }

            r = 12 * b + 3 * p * Math.Pow(t, 2) + f / 3; // вычисляем r

            // выводим все получившиеся значения на экран пользователю
            Console.WriteLine("b = " + b);
            Console.WriteLine("f = " + f);
            Console.WriteLine("p = " + p);
            Console.WriteLine("t = " + t);
            Console.WriteLine("r = " + r);
        }
    }
}