using System;

namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a; // вводим переменные а, b, c с типом double
            double b;
            double c;
            double f1; // вводим переменные f1-f19 для каждого действия с типом double
            double f2;
            double f3;
            double f4;
            double f5;
            double f6;
            double f7;
            double f8;
            double f9;
            double f10;
            double f11;
            double f12;
            double f13;
            double f14;
            double f15;
            double f16;
            double f17;
            double f18;
            double f19;
            double result; // вводим переменную result для подсчёта конечного результата
            Console.WriteLine("Введите значение переменной a:");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите значение переменной b:"); // выводим текст на экран
            b = Convert.ToInt32(Console.ReadLine()); // пользователь вводит значения для переменных

            Console.WriteLine("Введите значение переменной c:");
            c = Convert.ToInt32(Console.ReadLine());

            f1 = a - b; // вычитаем из значения переменной a значение переменной b
            f2 = Math.Pow(f1, 2); // возводим во вторую степень результат вычитания
            f3 = 1.5 * f2; // умножаем возведённое во вторую степень число на 1.5
            f4 = Math.Abs(a - b); // находим модуль числа, которое получается при вычитании из значения переменной a значения переменной b
            f5 = c * f4; // умножаем модуль числа на переменную c
            f6 = f3 / f5; // делим результат f3 на результат f5
            f7 = Math.Pow(10, 3); // возводим 10 в 3 степень
            f8 = Math.Abs(a - b); // находим модуль числа, которое получается при вычитании из значения переменной a значения переменной b
            f9 = Math.Sqrt(f8); // вычисляем корень числа f8
            f10 = f7 * f9; // умножаем результат f7 на результат f8
            f11 = Math.Pow(a, 2); // возводим переменную a во вторую степень
            f12 = f11 + 2.75; // складываем результат f11 с 2.75
            f13 = 2.5 * f12; // умножаем результат f12 на 2.5
            f14 = Math.Sin(-2 * a); // находим синус произведения -2 * a
            f15 = f13 * f14; // умножаем результат f13 на f14
            f16 = Math.Pow(a, 2); // возводим переменную a во вторую степень
            f17 = f16 * b * c; // умножаем результат f16 на b и c
            f18 = 3 + f17; // к f17 прибавляем 3
            f19 = f15 / f18; // делим результат f15 на f17
            result = f6 + f10 - f19; // складываем f6 и f10 и из этого значения вычитаем f19
            Console.WriteLine("Результат:" + result); // выводим результат на консоль
            Console.ReadKey();
        }
    }
}