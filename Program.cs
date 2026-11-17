namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var buffer = new CircularBuffer<int>(3);

            buffer.Add(1);
            buffer.Add(2);
            buffer.Add(3);
            Console.WriteLine($"После заполнения: {string.Join(", ", buffer)}");

            buffer.Add(4);
            buffer.Add(5);

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
