using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public static class ConsoleHelper
    {
        public static void WriteHeader(string text)
        {
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"║ {text,-36} ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
        }

        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ {message}");
            Console.ResetColor();
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ {message}");
            Console.ResetColor();
        }

        public static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"⚠ {message}");
            Console.ResetColor();
        }

        public static void WriteItem(ItemBase item)
        {
            Console.ForegroundColor = item.Quality switch
            {
                int n when n >= 7 => ConsoleColor.Magenta,
                int n when n >= 5 => ConsoleColor.Blue,
                int n when n >= 3 => ConsoleColor.Green,
                _ => ConsoleColor.Gray
            };

            Console.WriteLine($"► {item.Description}");
            Console.ResetColor();
        }

        public static int ShowMenu(string title, params string[] options)
        {
            ConsoleHelper.WriteHeader(title);

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.WriteLine();
            Console.Write("Выберите вариант: ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= options.Length)
                {
                    return choice;
                }

                Console.Write("Неверный ввод. Попробуйте снова: ");
            }
        }
    }
}
