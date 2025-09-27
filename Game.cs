using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;

public struct Point
{
    public int x;
    public int y;
    
    public Point(int x_, int y_)
    {
        x = x_;
        y = y_;
    }

    public static Point operator +(Point first, Point second)
    {
        return new Point(first.x + second.x, first.y + second.y);
    }
    
    public static bool operator ==(Point first, Point second)
    {
        return first.x == second.x && first.y == second.y;
    }

    public static bool operator !=(Point first, Point second)
    {
        return first.x != second.x || first.y != second.y;
    }
}
public class Game
{
    Point food;
    Point snakeHead;
    Random random = new Random();
    public Game()
    {
        snakeHead.x = 5;
        snakeHead.y = 5;

    
    }

    private char[,] field = new char[10, 10];

    private int foodX;
    private int foodY;

    public Point genRandom()
    {
        return new Point(random.Next(1, field.GetLength(0) - 2), random.Next(1, field.GetLength(0) - 2));
    }

    public void GenerateFood()
    {
        snakeHead = genRandom();
        food = genRandom();
        while (snakeHead == food) food = genRandom();
    }
    public void FillTheField()
    {
        Console.Clear();
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {

                if (j == snakeHead.x && i == snakeHead.y) field[i, j] = '@';
                else if (i == 0 || j == 0 || i == field.GetLength(0) - 1 || j == field.GetLength(1) - 1) field[i, j] = '#';
                else
                {
                    if (i == foodX && j == foodY)
                    {
                        field[i, j] = '*';
                    }
                    else field[i, j] = ' ';
                }

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
                snakeHead.y -= 1;
                if (snakeHead.y < 1)
                {
                    Console.WriteLine("Game Over!");
                    return false;
                }
                FillTheField();
                break;
            case 's':
                snakeHead.y += 1;
                if (snakeHead.y > field.GetLength(0) - 2)
                {
                    Console.WriteLine("Game Over!");
                    return false;
                }
                FillTheField();
                break;
            case 'a':
                snakeHead.x -= 1;
                if (snakeHead.x < 1)
                {
                    Console.WriteLine("Game Over!");
                    return false;
                }
                FillTheField();
                break;
            case 'd':
                snakeHead.x += 1;
                if (snakeHead.x > field.GetLength(1) - 2)
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