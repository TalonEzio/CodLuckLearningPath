namespace _02_Oop;

class ConsoleHelper
{
    public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
    public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
    public void WriteLine(object message)
    {
        WriteLine(message, ForegroundColor, BackgroundColor);
    }
    public static void WriteLine(
        object message,
        ConsoleColor fgColor = ConsoleColor.White,
        ConsoleColor bgColor = ConsoleColor.Black,
        bool reset = true)
    {
        Console.ForegroundColor = fgColor;
        Console.BackgroundColor = bgColor;
        Console.WriteLine(message);
        if (reset)
            Console.ResetColor();
    }
}