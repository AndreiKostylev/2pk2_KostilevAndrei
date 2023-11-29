namespace PZ_11
{
    internal class Program
    {
        // Метод для рассчета площади окружности
        static void GetCircleArea(int radius, out double circleArea)
        {
            circleArea = Math.PI * radius * radius;
        }

        // Метод для рассчета объема сферы
        static void GetSphereVolume(int radius, out double sphereVolume)
        {
            sphereVolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
        }

        // Метод для рассчета площади сферы
        static void GetSphereSurfaceArea(int radius, out double sphereSurfaceArea)
        {
            sphereSurfaceArea = 4 * Math.PI * Math.Pow(radius, 2);
        }

        static void Main()
        {
            int radius;

            do
            {
                Console.WriteLine("Введите целое неотрицательное число N:");
            } while (!int.TryParse(Console.ReadLine(), out radius) || radius < 0);

            double circleArea, sphereVolume, sphereSurfaceArea;

            // Вызываем методы, которые принимают значение радиуса и выводят результаты расчетов
            GetCircleArea(radius, out circleArea);
            GetSphereVolume(radius, out sphereVolume);
            GetSphereSurfaceArea(radius, out sphereSurfaceArea);

            // Вывод результатов
            Console.WriteLine($"Площадь окружности с радиусом {radius}: {circleArea}");
            Console.WriteLine($"Объем сферы с радиусом {radius}: {sphereVolume}");
            Console.WriteLine($"Площадь сферы с радиусом {radius}: {sphereSurfaceArea}");
        }
    }
}