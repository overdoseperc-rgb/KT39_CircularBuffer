namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity;
            while (true)
            {
                Console.Write("Сколько чисел хранить? ");
                string? input = Console.ReadLine();
                if (input == null)
                {
                    return;
                }

                if (int.TryParse(input, out capacity) && capacity > 0)
                {
                    break;
                }

                Console.WriteLine("Введи целое число больше нуля.");
            }

            var buffer = new CircularBuffer<int>(capacity);
            Console.WriteLine("1 — Добавить число");
            Console.WriteLine("2 — Показать буфер");
            Console.WriteLine("0 — Выход");

            while (true)
            {
                Console.Write("Команда: ");
                switch (Console.ReadLine()?.Trim())
                {
                    case "1":
                        Console.Write("Число: ");
                        string? input = Console.ReadLine();
                        if (input == null)
                        {
                            return;
                        }

                        if (int.TryParse(input, out int number))
                        {
                            buffer.Add(number);
                        }
                        else
                        {
                            Console.WriteLine("Введи целое число.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("От старого к новому:");
                        foreach (int value in buffer)
                        {
                            Console.WriteLine(value);
                        }

                        Console.WriteLine("От нового к старому:");
                        foreach (int value in buffer.Reverse())
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "0":
                    case null:
                        return;

                    default:
                        Console.WriteLine("Выбери 1, 2 или 0.");
                        break;
                }
            }
        }
    }
}
