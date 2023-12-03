namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Выводим сообщение и результат выполнения каждого задания
            Console.WriteLine("Первое задание:");
            Console.WriteLine(ArifmProgr(7, 45, 8));
            Console.WriteLine("Второе задание:");
            Console.WriteLine(GeomProgr(7, 10, 0.6));
            Console.WriteLine("Третье задание:");
            Console.WriteLine(NumbersComp(6, -50));
            Console.WriteLine("Четвертое задание:");
            Console.WriteLine("Введите число, которое нужно вывести в обратном порядке:");
            int num = Convert.ToInt32(Console.ReadLine());
            Reverse(num);
        }
        // Метод для вычисления n-го члена арифметической прогрессии
        static int ArifmProgr(int n, int a, int d) // Задание 1
        {
            int res = 0;
            if (n != 0)
            {
                res = a + d * (n - 1);
                ArifmProgr(n - 1, a, res); // Рекурсия
            }
            return res;
        }
        // Метод для вычисления n-го члена шеометрической прогрессии
        static double GeomProgr(int n, int b, double q) // Задание 2
        {
            double res = 1;
            if (n != 0)
            {
                res = b * Math.Pow(q, n - 1);
                GeomProgr(n - 1, b, res); // Рекурсия
            }
            return res;
        }
        // Метод для сравнения чисел и вывода их в убывающем порядке
        static int NumbersComp(int A, int B) // Задание 3
        {
            if (A != B) // База
            {
                Console.Write($"{A}, ");
                NumbersComp(A - 1, B); // Рекурсия
            }
            return B;
        }
        // Метод для вывода числа в обратном порядке
        static void Reverse(int num) // Задание 4(пункт 4)
        {
            if (num < 10)
            {
                Console.Write(num);
                return;
            }
            Console.Write(num % 10);
            Reverse(num / 10); // Рекурсия

        }
    }
}