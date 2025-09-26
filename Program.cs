public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.FillTheField();

        while (true)
        {
            char button = Console.ReadKey().KeyChar;
            game.MovingThePerson(button);
        }
    }
}