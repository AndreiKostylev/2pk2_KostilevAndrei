namespace PZ_04
{
internal class Program
{
    static void Main(string[] args)
    {
            // задание 1
            Console.WriteLine("Задание 1");
            for (int i = 30; i <= 100; i += 7)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Задание 2");
            // задание 2
            char a = 'L';
            for (int i = 0; i <= 7; i++)
            {
                Console.Write(a);
                a++;
            }
            Console.WriteLine();
            Console.WriteLine("Задание 3");
            // задание 3
            int n = 4;
            int m = 4;
            char f = '#';
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(f);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Задание 4");
            // задание 4
            int c = 0;
            for (int i = 90; i <= 900; i++)
            {
                if (i % 9 == 0)
                {
                    Console.Write(i + " ");
                    c++;
                }
            }
            Console.WriteLine("\nКоличество чисел, кратных 9: " + c);
            Console.WriteLine("Задание 5");
            // задание 5
            for (int i = 4, j = 50; j - i >= 11; i++, j--)
            {
                Console.WriteLine("i: " + i + ", j: " + j);
            }
        }
    }
}

