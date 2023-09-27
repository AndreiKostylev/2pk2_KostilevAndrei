using System;

namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем массив из 10 целочисленных элементов
            int[] numbers = new int[10];

            // Вводим элементы массива с клавиатуры
            Console.WriteLine("Введите 10 целочисленных элементов:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                bool s = false; // Флаг для проверки успешности ввода
                // Проверяется, может ли введенное значение быть преобразовано в целое число. Это делается с помощью метода `int.TryParse(Console.ReadLine(), out int input)`.
                while (!s)
                {
                    if (int.TryParse(Console.ReadLine(), out int input))
                    {
                        numbers[i] = input;
                        s = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                    }
                }
            }

            // Находим количество отрицательных чисел и выводим их
            int negativeCount = 0;
            Console.WriteLine("\nОтрицательные числа:");
            bool hasNegative = false; // Добавлен флаг, показывающий, были ли отрицательные числа
            for (int i = 0; i < 10; i++)
            {
                if (numbers[i] < 0)
                {
                    negativeCount++;
                    Console.WriteLine(numbers[i]);
                    hasNegative = true; // Устанавливаем флаг, если найдено отрицательное число
                }
            }

            // Выводим количество отрицательных чисел
            Console.WriteLine($"\nКоличество отрицательных чисел: {negativeCount}");

            // Если не было отрицательных чисел, выводим соответствующее сообщение
            if (!hasNegative)
            {
                Console.WriteLine("Отрицательные числа не были введены.");
            }
            else
            {
                // Сортируем массив с отрицательными числами в порядке убывания
                Array.Sort(numbers, (a, b) => -1 * a.CompareTo(b));

                // Выводим отрицательные числа в порядке убывания
                Console.WriteLine("\nОтрицательные числа в порядке убывания:");
                for (int i = 0; i < 10; i++)
                {
                    if (numbers[i] < 0)
                    {
                        Console.WriteLine(numbers[i]);
                    }
                }
            }
        }
    }
}