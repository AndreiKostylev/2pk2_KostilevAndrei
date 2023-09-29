using System;

namespace PZ_07 
{
    class Program
    {
        static void Main()
        {
            // Выводим приглашение к вводу размерности матрицы
            Console.WriteLine("Введите размерность матрицы (через пробел, например 3 3):");
            string[] dimensions = Console.ReadLine().Split(' ');
            int rows, cols;

            // Проверка корректности ввода размерности
            while (true)
            {
                // Проверяем, что введено ровно два элемента и они могут быть преобразованы в целые числа
                if (dimensions.Length != 2 || !int.TryParse(dimensions[0], out rows) || !int.TryParse(dimensions[1], out cols))
                {
                    // Если ввод неверный, просим пользователя ввести два целых числа через пробел
                    Console.WriteLine("Неверный формат. Пожалуйста, введите два целых числа через пробел.");
                    dimensions = Console.ReadLine().Split(' ');
                }
                else
                {
                    break; // Выход из цикла, если ввод корректен
                }
            }

            // Создаем двумерный массив с указанными размерами
            double[,] matrix = new double[rows, cols];

            // Просим пользователя ввести элементы матрицы
            Console.WriteLine("Введите через пробел элементы матрицы в соответсвии с указанной размерностью, после корректного заполнения строки нажмите enter:");

            for (int i = 0; i < rows; i++)
            {
                string[] rowValues = Console.ReadLine().Split(' ');

                // Проверка корректности ввода элементов строки
                while (rowValues.Length != cols)
                {
                    // Если количество введенных элементов не совпадает с количеством столбцов, просим пользователя ввести правильное количество
                    Console.WriteLine($"Неверное количество элементов. Введите {cols} чисел(числа) и после этого нажмите на enter.");
                    rowValues = Console.ReadLine().Split(' ');
                }

                for (int j = 0; j < cols; j++)
                {
                    // Преобразовываем элементы строки в тип double и заполняем матрицу
                    matrix[i, j] = Convert.ToDouble(rowValues[j]);
                }
            }

            // Нахождение строки с максимальной суммой
            double maxSum = double.MinValue;
            int maxSumRowIndex = -1;

            for (int i = 0; i < rows; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < cols; j++)
                {
                    rowSum += matrix[i, j];
                }

                if (rowSum > maxSum)
                {
                    maxSum = rowSum;
                    maxSumRowIndex = i;
                }
                else if (rowSum == maxSum && maxSumRowIndex != -1)
                {
                    // Если есть строки с одинаковой максимальной суммой, сообщаем об этом
                    Console.WriteLine($"Строки {maxSumRowIndex + 1} и {i + 1} имеют одинаковую максимальную сумму.");
                }
            }

            // Выводим индекс строки с максимальной суммой
            Console.WriteLine($"Строка с максимальной суммой элементов: {maxSumRowIndex + 1}");

            // Ожидание нажатия клавиши перед закрытием консоли
            Console.ReadKey();
        }
    }
}