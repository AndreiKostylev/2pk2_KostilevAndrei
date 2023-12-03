using System;
using System.IO;
namespace PZ_14
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Имя файла с исходным текстом
                string inputFileName = "f1.txt";
                // Имя файла, в который будут записаны четные строки
                string outputFileName = "f2.txt";

                Console.WriteLine($"Файл {inputFileName} создан успешно.");
                // Создание файла f1.txt
                Console.WriteLine("Введите строки для файла f1.txt. Для завершения ввода введите 'exit':");

                using (StreamWriter inputFileWriter = new StreamWriter(inputFileName))
                {
                    string inputLine;
                    while (true)
                    {
                        inputLine = Console.ReadLine();
                        if (inputLine.ToLower() == "exit")
                            break;

                        inputFileWriter.WriteLine(inputLine);
                    }
                }

                // Чтение из файла f1 и запись в файл f2
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    using (StreamWriter writer = new StreamWriter(outputFileName))
                    {
                        int lineNumber = 1;
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            // Проверка на четность строки
                            if (lineNumber % 2 == 0)
                            {
                                // Запись четной строки в файл f2
                                writer.WriteLine(line);
                            }

                            lineNumber++;
                        }
                    }
                }
                Console.WriteLine($"Файл {outputFileName} создан успешно.");
                Console.WriteLine($"Четные строки из {inputFileName} записаны в {outputFileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}