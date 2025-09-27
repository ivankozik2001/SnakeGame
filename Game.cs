using System.Diagnostics.Contracts;

public class Game
{
    private int x = 5;
    private int y = 5;
    private char[,] field = new char[10, 10];
    private Random food;
    public void FillTheField()
    {
        Console.Clear();
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (j == x && i == y) field[i, j] = '@';
                else if (i == 0 || j == 0 || i == field.GetLength(0) - 1 || j == field.GetLength(1) - 1) field[i, j] = '#';
                else field[i, j] = ' ';

                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
    }
    public bool MovingThePerson(char direction)
    {
        switch (direction)
        {
            case 'w':
                y -= 1;
                if (y < 1)
                {
                    Console.WriteLine("Game Over!");
                    return false;
                }
                FillTheField();
                break;
            case 's':
                y += 1;
                if (y > field.GetLength(0)-2)
                {
                    Console.WriteLine("Game Over!");
                    return false;
                }
                FillTheField();
                break;
            case 'a':
                x -= 1;
                if (x < 1)
                {
                    Console.WriteLine("Game Over!");
                    return false;
                }
                FillTheField();
                break;
            case 'd':
                x += 1;
                if (x > field.GetLength(1)-2)
                {
                    Console.WriteLine("Game Over!");
                    return false;
                }
                FillTheField();
                break;
        }
        return true;
    }
}