using System;

namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double A, B;
            Console.Write("Введите число A: ");
            A = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число B: ");
            B = Convert.ToDouble(Console.ReadLine());

            // Проверяем, что A и B больше нуля и A > B
            if (A > 0 && B > 0 && A > B)
            {
                double length = A; // Изначально длина незанятой части равна A

                while (length >= B)
                {
                    length -= B; // Вычитаем длину отрезка B из незанятой части
                }
                length = Math.Round(length, 2);
                Console.WriteLine("Длина незанятой части отрезка A: " + length);
            }
            else
            {
                Console.WriteLine("Числа A и B должны быть положительными и A должно быть больше B.");
                Main(args);
            }
        }
    }
}