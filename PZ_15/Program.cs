using System;
namespace PZ_15
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите полный путь к каталогу:");
                    string directoryPath = Console.ReadLine();

                    // Проверка существования каталога
                    if (Directory.Exists(directoryPath))
                    {
                        string[] subDirectories = Directory.GetDirectories(directoryPath);

                        // Сортировка подкаталогов по размеру (убывающая)
                        for (int i = 0; i < subDirectories.Length - 1; i++)
                        {
                            for (int j = i + 1; j < subDirectories.Length; j++)
                            {
                                long size1 = GetDirectorySize(subDirectories[i]);
                                long size2 = GetDirectorySize(subDirectories[j]);

                                if (size2 > size1)
                                {
                                    // Обмен местами
                                    string temp = subDirectories[i];
                                    subDirectories[i] = subDirectories[j];
                                    subDirectories[j] = temp;
                                }
                            }
                        }

                        // Вывод имен подкаталогов в порядке убывания по размеру
                        foreach (var subDir in subDirectories)
                        {
                            Console.WriteLine($"Каталог: {Path.GetFileName(subDir)}, Размер: {GetDirectorySize(subDir)} байт");
                        }

                        // Выход из цикла, так как успешно завершили работу
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Указанный каталог не существует. Повторите ввод.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}. Повторите ввод.");
                }
            }
        }

        // Метод для рекурсивного подсчета размера каталога
        static long GetDirectorySize(string directoryPath)
        {
            long size = 0;

            // Учтем размер файлов в текущем каталоге
            string[] files = Directory.GetFiles(directoryPath);
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            // Рекурсивно пройдемся по подкаталогам
            string[] subDirectories = Directory.GetDirectories(directoryPath);
            foreach (var subDir in subDirectories)
            {
                size += GetDirectorySize(subDir);
            }

            return size;
        }
    }
}