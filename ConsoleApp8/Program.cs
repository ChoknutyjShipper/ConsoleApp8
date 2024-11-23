using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {

        public enum EquationType
        {
            Standard, // ax^2 + bx + c = 0
            Incomplete_b, // ax^2 + c = 0
            Incomplete_c // ax^2 + bx = 0
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип квадратного уравнения:");
            Console.WriteLine("1. Стандартное (ax^2 + bx + c = 0)");
            Console.WriteLine("2. Неполное (без b): ax^2 + c = 0");
            Console.WriteLine("3. Неполное (без c): ax^2 + bx = 0");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число от 1 до 3.");
            }

            EquationType equationType = (EquationType)(choice - 1);

            double a, b = 0, c = 0;

            Console.Write("Введите коэффициент a: ");
            while (!double.TryParse(Console.ReadLine(), out a) || a == 0)
            {
                Console.WriteLine("Неверный ввод. Коэффициент a не может быть равен нулю.");
                Console.Write("Введите коэффициент a: ");
            }


            if (equationType == EquationType.Standard)
            {
                Console.Write("Введите коэффициент b: ");
                while (!double.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Неверный ввод. Повторите ввод.");
                    Console.Write("Введите коэффициент b: ");
                }
                Console.Write("Введите коэффициент c: ");
                while (!double.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Неверный ввод. Повторите ввод.");
                    Console.Write("Введите коэффициент c: ");
                }
            }
            else if (equationType == EquationType.Incomplete_b)
            {
                Console.Write("Введите коэффициент c: ");
                while (!double.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Неверный ввод. Повторите ввод.");
                    Console.Write("Введите коэффициент c: ");
                }
            }
            else if (equationType == EquationType.Incomplete_c)
            {
                Console.Write("Введите коэффициент b: ");
                while (!double.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Неверный ввод. Повторите ввод.");
                    Console.Write("Введите коэффициент b: ");
                }
            }
            SolveEquation(a, b, c, equationType);
            Console.ReadKey();
        }
        static void SolveEquation(double a, double b, double c, EquationType type)
        {
            double discriminant = b * b - 4 * a * c;
            Console.WriteLine($"Дискриминант: {discriminant}");

            if (type == EquationType.Incomplete_c)
            {
                Console.WriteLine("Корни:");
                Console.WriteLine($"x1 = 0");
                Console.WriteLine($"x2 = {-b / a}");
                return;
            }
            if (type == EquationType.Incomplete_b)
            {
                if (discriminant < 0) Console.WriteLine("Нет действительных корней");
                else
                {
                    Console.WriteLine("Корни:");
                    double x = Math.Sqrt(-c / a);
                    Console.WriteLine($"x1 = {x}");
                    Console.WriteLine($"x2 = {-x}");

                }
                return;
            }

            if (discriminant > 0)
            {
                Console.WriteLine("Корни:");
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"x1 = {x1}");
                Console.WriteLine($"x2 = {x2}");
            }
            else if (discriminant == 0)
            {
                Console.WriteLine("Один корень:");
                double x = -b / (2 * a);
                Console.WriteLine($"x = {x}");
            }
            else
            {
                Console.WriteLine("Нет действительных корней.");
            }
        }
    }
}
