using System;

namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a; // вводится число a для определения кода города
            double c; // вводится число c для определения стоимости разговора

            Console.WriteLine("Введите код города (Москва - 905, Ростов - 194, Краснодар - 491, Киров - 800):"); // надпись выводится на экран
            a = Convert.ToInt32(Console.ReadLine()); // пользователь вводит код региона

            switch (a) // по коду города определяем стоимость десяти минут разговора
            {
                case 905:
                    c = 4.15;
                    break;
                case 194:
                    c = 1.98;
                    break;
                case 491:
                    c = 2.69;
                    break;
                case 800:
                    c = 5.00;
                    break;
                default:
                    Console.WriteLine("Некорректный код города.");
                    return; // завершаем программу, если введен некорректный код города
            }
            Console.WriteLine($"Стоимость 10-минутного разговора: {c} руб.");
        }
    }
}