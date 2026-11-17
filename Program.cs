namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var buffer = new CircularBuffer<int>(3);
            Console.WriteLine("Буфер хранит три последних числа.");
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
