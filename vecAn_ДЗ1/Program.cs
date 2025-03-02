using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Решение системы уравнений с комплексными числами 2x2 методом Крамера");
        Console.WriteLine("Формат ввода: действительная и мнимая части через пробел (пример: 2 3 → 2+3i)\n");

        var a11 = ToComplex(InputThis("Введите a11 (Re Im):"));
        var a12 = ToComplex(InputThis("Введите a12 (Re Im):"));
        var b1 = ToComplex(InputThis("Введите  b1 (Re Im):"));

        var a21 = ToComplex(InputThis("Введите a21 (Re Im):"));
        var a22 = ToComplex(InputThis("Введите a22 (Re Im):"));
        var b2 = ToComplex(InputThis("Введите b2 (Re Im):"));

        var det = a11 * a22 - a12 * a21;

        if (det == Complex.Zero)
            {
            Console.WriteLine("Система не имеет единственного решения (определитель равен нулю)");
            }

        else
            {
            var detX = b1 * a22 - b2 * a12;
            var detY = a11 * b2 - a21 * b1;

            // Вычисление решений
            var x = detX / det;
            var y = detY / det;

            // Вывод результатов
            Console.WriteLine("Результат:");
            Console.WriteLine($"x:{x.Real} {x.Imaginary}");
            Console.WriteLine($"y:{y.Real} {y.Imaginary}");
            }
        }

    static Complex ToComplex(string input)
    {
        string[] parts = input.Split();
        if (parts.Length != 2)
            throw new FormatException("Ошибка формата ввода! Используйте числа вида '3.14 -2.71'");
        return new Complex(
            real: double.Parse(parts[0]),
            imaginary: double.Parse(parts[1])
        );
    }

    static string InputThis(string expectNum)
    {
        Console.WriteLine(expectNum);
        var input = Console.ReadLine();
        return input;
    }
}