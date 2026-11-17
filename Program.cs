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
                string? capacityInput = Console.ReadLine();
                if (capacityInput == null)
                {
                    return;
                }

                if (int.TryParse(capacityInput, out capacity) && capacity > 0)
                {
                    break;
                }

                Console.WriteLine("Введи целое число больше нуля.");
            }

            var buffer = new CircularBuffer<int>(capacity);
            Console.WriteLine("Вводи по одному целому числу. Пустая строка завершает ввод.");

            while (true)
            {
                Console.Write("Число: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Введи целое число.");
                    continue;
                }

                buffer.Add(number);
            }

            Console.WriteLine("От старого к новому:");
            foreach (int number in buffer)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("От нового к старому:");
            foreach (int number in buffer.Reverse())
            {
                Console.WriteLine(number);
            }
        }
    }
}
