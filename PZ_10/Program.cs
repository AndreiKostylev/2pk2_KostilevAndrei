namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст, состоящий из нескольких строк, для разделения строк, используйте точку (завершите ввод, введя пустую строку):");

            // Считывание текста с консоли
            string inputText = "";
            string line;
            do
            {
                line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    inputText += line + Environment.NewLine;
            } while (!string.IsNullOrWhiteSpace(line));

            // Разделение текста на предложения
            string[] sentences = inputText.Split('.');

            // Создание ступенчатого двумерного массива для слов
            string[][] wordsArray = new string[sentences.Length - 1][]; // убираем лишнее пустое предложение в конце

            // Заполнение массива словами из каждого предложения
            for (int i = 0; i < sentences.Length - 1; i++)
            {
                string[] words = sentences[i].Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                wordsArray[i] = words;
            }

            // Вывод двумерного массива слов
            for (int i = 0; i < wordsArray.Length; i++)
            {
                Console.Write($"Предложение {i + 1}: ");
                for (int j = 0; j < wordsArray[i].Length; j++)
                {
                    Console.Write($"{wordsArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}