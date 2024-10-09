namespace _01_Overview
{
    internal static class Extensions
    {
        public static void PrintLog(this string s, ConsoleColor color = ConsoleColor.Green)
        {
            lock (Console.Out)
            {
                ConsoleColor lastColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(s);
                Console.ForegroundColor = lastColor;
            }
        }
    }
}
