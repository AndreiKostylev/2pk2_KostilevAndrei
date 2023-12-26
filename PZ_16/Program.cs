using System;
namespace PZ_16
{
    internal class Program
    {
        static int mapSize = 25; // размер карты
        static char[,] map = new char[mapSize, mapSize]; // карта

        // координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;

        static byte maxEnemies = 5; // максимальное количество врагов
        static byte maxBuffs = 5; // максимальное количество усилений
        static byte maxHealthAids = 5; // максимальное количество аптечек
        static int stepsSinceLastBuff = 0;
        static int playerDamage = 10;
        static int playerHP = 50;
        static int buffDuration = 20;
        static bool buffActive = false;
        static int buffRemainingSteps = 0;
        // Добавляем переменную для отслеживания силы игрока

        static int totalSteps = 0;
        static int totalEnemies = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                LoadGameOrGenerateMap();
                Move();
            }
        }

        static void LoadGameOrGenerateMap()
        {
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("Начать новую игру? (N)");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("Хотите загрузить сохраненную игру? (Y)");
            ConsoleKeyInfo loadKey = Console.ReadKey(true);
            bool isNewGame = loadKey.Key == ConsoleKey.N;
            if (loadKey.Key == ConsoleKey.Y && File.Exists("save.txt"))
            {
                Console.Clear();
                LoadGame();
            }
            else if (loadKey.Key == ConsoleKey.N)
            {
                Console.Clear();
                GenerationMap();
            }
            else
            {

                LoadGameOrGenerateMap();
            }
        }

        static void LoadGame()
        {
            string fileName = "save.txt";

            using (StreamReader reader = new StreamReader(fileName))
            {
                // Чтение параметров игры из файла
                playerX = int.Parse(reader.ReadLine().Split(':').Last().Trim()); // .Split(':'): Разбивает строку на части, используя символ ':' в качестве разделителя.(формат "название_параметра: значение")
                playerY = int.Parse(reader.ReadLine().Split(':').Last().Trim()); // .Last(): Выбирает последний элемент из массива строк.(зачение параметра)
                playerHP = int.Parse(reader.ReadLine().Split(':').Last().Trim());
                totalSteps = int.Parse(reader.ReadLine().Split(':').Last().Trim());
                totalEnemies = int.Parse(reader.ReadLine().Split(':').Last().Trim()); // .Trim(): Удаляет лишние пробелы с обеих сторон строки

                // Чтение карты из файла
                for (int i = 0; i < mapSize; i++)
                {
                    string line = reader.ReadLine();
                    for (int j = 0; j < mapSize; j++)
                    {
                        map[i, j] = line[j];
                    }
                }
            }


            DisplayStats();
            UpdateMap();
        }
        static void GenerationMap()
        {
            Random random = new Random();

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }

            map[playerY, playerX] = 'P';

            int x, y;

            while (totalEnemies < maxEnemies)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    totalEnemies++;
                }
            }

            while (maxBuffs > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    maxBuffs--;
                }
            }

            while (maxHealthAids > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    maxHealthAids--;
                }
            }

            UpdateMap();
        }

        static void Move()
        {
            Console.CursorVisible = false;

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                int playerOldX = playerX;
                int playerOldY = playerY;

                bool isTeleport = false; // Флаг для проверки телепортации

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (playerX == 0)
                        {
                            playerX = mapSize - 1;
                            isTeleport = true;
                        }
                        else
                        {
                            playerX = Math.Max(0, playerX - 1);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerX == mapSize - 1)
                        {
                            playerX = 0;
                            isTeleport = true;
                        }
                        else
                        {
                            playerX = Math.Min(mapSize - 1, playerX + 1);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (playerY == 0)
                        {
                            playerY = mapSize - 1;
                            isTeleport = true;
                        }
                        else
                        {
                            playerY = Math.Max(0, playerY - 1);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerY == mapSize - 1)
                        {
                            playerY = 0;
                            isTeleport = true;
                        }
                        else
                        {
                            playerY = Math.Min(mapSize - 1, playerY + 1);
                        }
                        break;
                    case ConsoleKey.Escape:
                        SaveGame();
                        break;

                }

                totalSteps++;
                stepsSinceLastBuff++;

                if (buffActive && stepsSinceLastBuff >= buffDuration)
                {
                    buffActive = false;
                    Console.SetCursorPosition(40, 8);
                    Console.WriteLine("Бафф закончился.");
                }
                if (map[playerX, playerY] == 'E')
                {
                    AnimateEncounter();
                    FightEnemy();
                }
                else if (map[playerX, playerY] == 'H')
                {
                    UseHealthAid();
                }
                else if (map[playerX, playerY] == 'B')
                {
                    UseBuff();
                }
                else if (map[playerX, playerY] == 'S')
                {
                    AnimateBoss();
                    BossFight();

                }

                map[playerOldX, playerOldY] = '_';
                map[playerX, playerY] = 'P';

                DisplayStats();
                UpdateMap();
            }
        }
        static void SaveGame()
        {
            Console.SetCursorPosition(40, 9);
            Console.WriteLine("Вы хотите сохранить игру? (Y/N)");
            ConsoleKeyInfo saveKey = Console.ReadKey(true);

            if (saveKey.Key == ConsoleKey.Y)
            {
                string fileName = "save.txt";

                if (File.Exists(fileName))
                {
                    Console.SetCursorPosition(40, 11);
                    Console.WriteLine("Файл сохранения уже существует. Вы уверены, что хотите перезаписать его? (Y/N)");
                    ConsoleKeyInfo overwriteKey = Console.ReadKey(true);

                    if (overwriteKey.Key != ConsoleKey.Y)
                    {
                        Console.SetCursorPosition(40, 12);
                        Console.WriteLine("Файл сохранения не перезаписан. Игра продолжается...");
                        return;
                    }
                    else
                    {
                        Console.SetCursorPosition(40, 13);
                        Console.WriteLine("Файл сохранения перезаписан!");
                    }
                }
                else
                {
                    Console.SetCursorPosition(40, 10);
                    Console.WriteLine("Игра успешно сохранена в файле save.txt.");
                }

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Сохранение параметров игры в файл
                    writer.WriteLine("Позиция игрока (X): " + playerX);
                    writer.WriteLine("Позиция игрока (Y): " + playerY);
                    writer.WriteLine("Здоровье игрока: " + playerHP);
                    writer.WriteLine("Всего сделано шагов: " + totalSteps);
                    writer.WriteLine("Оставшееся количество врагов: " + totalEnemies);

                    // Сохранение карты в файл
                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            writer.Write(map[i, j]);
                        }
                        writer.WriteLine();

                    }

                }
            }
            else
            {
                Console.SetCursorPosition(40, 12);
                Console.WriteLine("Игра не сохранена. Игра продолжается...");
            }
        }

        static void FightEnemy()
        {
            if (buffActive)
            {
                playerHP -= 7; // Уменьшение урона, если бафф активен
            }
            else
            {
                playerHP -= 10;
            }

            if (playerHP <= 0)
            {
                Console.Clear();
                Console.SetCursorPosition(30, 10);
                Console.WriteLine($"Игра окончена! Вы проиграли! Вы продержались {totalSteps} шагов. Осталось врагов: {totalEnemies}");

                Environment.Exit(0);
            }

            totalEnemies--;

            if (totalEnemies == 0)
            {
                Console.SetCursorPosition(40, 8);
                Console.WriteLine("Босс появляется!");
                map[mapSize / 2, mapSize / 2] = 'S';

            }
        }
        static void BossFight()
        {

            if (buffActive)
            {
                playerHP -= 10; // Уменьшение урона, если бафф активен
            }
            else
            {
                playerHP -= 15;
            }
            if (playerHP <= 0)
            {
                Console.Clear();
                Console.SetCursorPosition(30, 10);
                Console.WriteLine($"Игра окончена! Вы проиграли! Вы продержались {totalSteps} шагов. Вы не смогли победить босса!");

                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(30, 10);
                Console.WriteLine($"Поздравляю! Вы убили босса и прошли игру за {totalSteps} шагов.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        static void UseHealthAid()
        {
            playerHP = Math.Min(50, playerHP + 5); // Восстановление здоровья, но не больше максимума
            Console.SetCursorPosition(40, 5);
            Console.WriteLine($"Вы использовали аптечку. Ваше здоровье теперь {playerHP}.");
        }

        static void UseBuff()
        {
            if (stepsSinceLastBuff >= 20)
            {
                buffActive = true;
                buffRemainingSteps = buffDuration;
                DisplayStats();
                Console.SetCursorPosition(40, 6);
                Console.WriteLine($"Вы использовали усиление. Вы получили щит на следующих {buffDuration} шагов(-а).");

                // Обнуление счетчика шагов с последнего сбора баффа
                stepsSinceLastBuff = 0;
            }
            else
            {
                Console.SetCursorPosition(40, 7);
                Console.WriteLine($"Вы не можете использовать бафф. Подождите еще {20 - stepsSinceLastBuff} шагов(-а).");
            }
        }

        static void DisplayStats()
        {
            Console.SetCursorPosition(0, mapSize);
            Console.WriteLine($" Здоровье: {playerHP} | Осталось врагов без учета босса: {totalEnemies} | Шагов: {totalSteps} | Сила: {playerDamage}");
        }

        static void UpdateMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Console.SetCursorPosition(j, i);
                    switch (map[i, j])
                    {
                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'H':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 'B':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 'S':
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        default:
                            Console.ResetColor();
                            break;
                    }
                    Console.Write(map[i, j]);
                }
            }

        }
        static void AnimateEncounter()
        {
            Console.Clear(); // Очистить консоль перед анимацией

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(playerY, playerX);

                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Цвет для мигания
                    Console.Write('P');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('E');
                }

                System.Threading.Thread.Sleep(200); // Задержка между кадрами
            }

            Console.ResetColor(); // Сброс цвета после анимации

        }
        static void AnimateBoss()
        {
            Console.Clear(); // Очистить консоль перед анимацией боя с боссом

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(playerY, playerX);

                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Цвет для мигания
                    Console.Write('P');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write('S'); // 'S' - символ для анимации босса
                }

                System.Threading.Thread.Sleep(200); // Задержка между кадрами
            }

            Console.ResetColor(); // Сброс цвета после анимации
        }
    }
}