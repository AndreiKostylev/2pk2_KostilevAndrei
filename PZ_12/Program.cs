namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            bool isPalindrome = IsPalindrome(input); //Вызов метода для проверки, является ли введенная строка палиндромом

            if (isPalindrome)
            {
                Console.WriteLine("Введенная строка является палиндромом.");
            }
            else
            {
                Console.WriteLine("Введенная строка не является палиндромом.");
            }
        }

        static bool IsPalindrome(string str)
        {
            // Ввод метода для того, чтобы программа игнорировала пробелы, регистры и символы, кроме букв и цифр
            str = new string(str.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToLower();
            // Проверка на палиндром
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                if (str[i] != str[j]) // Сравнение символов, которые находятся в начале и в конце строки
                {
                    return false; // Возвращает false, если символы не совпадают, то есть строка-не палиндром
                }
            }

            return true; // Возвращает true, если символы совпадают, то есть строка-палиндром
        }
    }
}