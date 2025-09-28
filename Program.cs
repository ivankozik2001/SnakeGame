public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.FillTheField();

        bool gameProcess = true;

        while (gameProcess)
        {
            char button = Console.ReadKey(true).KeyChar;
            if (!game.MovingTheSnake(button))
            {
                gameProcess = false;
            }
        }

        Console.WriteLine("Натисни будь-яку клавішу, щоб вийти...");
        Console.ReadKey(true);
    }
}