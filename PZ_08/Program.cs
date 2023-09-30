using System;

namespace PZ_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[][] array = new string[9][];

            // Создание ступенчатого массива со случайной длиной второго измерения
            for (int i = 0; i < array.Length; i++)
            {
                int length = random.Next(6, 21);
                array[i] = new string[length];
                for (int j = 0; j < length; j++)
                {
                    array[i][j] = GenerateRandomString(random);
                }
            }

            // Вывод сгенерированного массива
            Console.WriteLine("Сгенерированный массив:");
            foreach (var row in array)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

            // Создание нового одномерного массива и запись в него последних элементов каждой строки
            string[] newArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i][array[i].Length - 1];
            }

            // Вывод нового массива
            Console.WriteLine("Новый массив:");
            foreach (var element in newArray)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            // Поиск максимального элемента в каждой строке и запись их в другой массив
            string[] maxArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                string max = array[i][0];
                foreach (var element in array[i])
                {
                    if (string.Compare(element, max) > 0)
                    {
                        max = element;
                    }
                }
                maxArray[i] = max;
            }

            // Вывод содержимого массива с максимальными элементами
            Console.WriteLine("Массив с максимальными элементами:");
            foreach (var element in maxArray)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            // Обмен первого элемента и максимального в каждой строке
            for (int i = 0; i < array.Length; i++)
            {
                string maxElement = maxArray[i];
                int maxIndex = Array.IndexOf(array[i], maxElement);

                string temp = array[i][0];
                array[i][0] = maxElement;
                array[i][maxIndex] = temp;
            }

            // Вывод обновленного массива
            Console.WriteLine("Обновленный массив:");
            foreach (var row in array)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

            // Реверс каждой строки ступенчатого массива
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }

            // Вывод реверсированного массива
            Console.WriteLine("Реверсированный массив:");
            foreach (var row in array)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

            // Подсчет общего количества символов в строках каждой строки массива
            Console.WriteLine("Общее количество символов в каждой строке:");
            foreach (var row in array)
            {
                int totalCharacters = 0;
                foreach (var element in row)
                {
                    totalCharacters += element.Length;
                }
                Console.WriteLine(totalCharacters);
            }

            // создание метода GenerateRandomString, который создает случайные строки
            static string GenerateRandomString(Random random)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                int length = random.Next(1, 11);
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }
    }
}