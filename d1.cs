using System;

namespace d1
{
    class Program
    {
        static double Function(double x)
        {
            return x * x * x - x - 2;
        }

        static void Main(string[] args)
        {
            double a = 1.0;
            double b = 2.0;
            double epsilon = 0.0001;
            int iterations = 0;

            if (Function(a) * Function(b) >= 0)
            {
                Console.WriteLine("Помилка: f(a) та f(b) не мають протилежних знаків.");
                Console.WriteLine($"На проміжку: [{a}, {b}]");
                return;
            }

            double c = a;

            Console.WriteLine($"f(x) = x^3 - x - 2");
            Console.WriteLine($"Проміжок: [{a}, {b}]");

            while ((b - a) >= epsilon)
            {
                iterations++;

                c = (a + b) / 2;

                if (Function(c) == 0.0)
                {
                    break;
                }
                
                if (Function(c) * Function(a) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }

            Console.WriteLine($"Корінь рівняння знайдено з точністю {epsilon}");
            Console.WriteLine($"x = {c}");
            Console.WriteLine($"Кількість ітерацій: {iterations}");
        }
    }
}