namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Запрашиваем строку S
            Console.WriteLine("Введите строку S:");
            string s = Console.ReadLine();

            int n;
            // Повторяем запрос значения N до тех пор, пока не будет введено корректное число
            do
            {
                // Запрашиваем целое число N
                Console.WriteLine("Введите целое число N:");
                // Если введено некорректное значение, выводим сообщение и повторяем запрос
                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("Некорректный ввод. Введите целое число N > 0.");
                }
            } while (n <= 0);

            if (s.Length > n)
            {
                // Если длина строки S больше значения N, отбрасываем первые символы
                int charactersToDrop = s.Length - n;
                string droppedCharacters = s.Substring(0, charactersToDrop);
                string remainingCharacters = s.Substring(charactersToDrop);
                // Выводим отброшенные символы и результат преобразования
                Console.WriteLine($"Отброшенные символы: {droppedCharacters}");
                Console.WriteLine($"Результат преобразования: {remainingCharacters}");
            }
            else
            {
                // Если длина строки S меньше N, добавляем смволы "." в начало
                int dotsToAdd = n - s.Length;
                string dots = new string('.', dotsToAdd);
                Console.WriteLine($"Результат преобразования: {dots + s}");
            }
        }
    }
}