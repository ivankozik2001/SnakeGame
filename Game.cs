using System;
using System.Collections.Generic;

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
        return !(first == second);
    }

    // щоб уникнути попереджень
    public override bool Equals(object obj) => obj is Point p && this == p;
    public override int GetHashCode() => HashCode.Combine(x, y);
}

public class Game
{
    private char[,] field = new char[11, 11];
    private List<Point> snake = new List<Point>();
    private Point food;
    private Random random = new Random();

    // напрямки
    private Dictionary<char, Point> directions = new Dictionary<char, Point>()
    {
        { 'w', new Point(0, -1) }, // вгору
        { 's', new Point(0, 1) },  // вниз
        { 'a', new Point(-1, 0) }, // вліво
        { 'd', new Point(1, 0) }   // вправо
    };

    public Game()
    {
        snake.Add(new Point(5, 5)); // стартова голова
        GenerateFood();
    }

    private Point GenRandom()
    {
        return new Point(random.Next(1, field.GetLength(1) - 1),
                         random.Next(1, field.GetLength(0) - 1));
    }

    public void GenerateFood()
    {
        food = GenRandom();
        while (snake.Contains(food)) food = GenRandom();
    }

    public void FillTheField()
    {
        Console.Clear();

        // малюємо стіни та поле
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == 0 || j == 0 || i == field.GetLength(0) - 1 || j == field.GetLength(1) - 1)
                    field[i, j] = '#';
                else if (food.y == i && food.x == j)
                    field[i, j] = '*';
                else
                    field[i, j] = ' ';
            }
        }

        // малюємо змійку
        foreach (var part in snake)
        {
            field[part.y, part.x] = '@';
        }

        // виводимо
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
    }

    public bool MovingTheSnake(char direction)
    {
        if (!directions.ContainsKey(direction)) return true; // ігноруємо інші кнопки

        Point newHead = snake[0] + directions[direction];

        // перевірка зіткнення зі стіною
        if (newHead.x < 1 || newHead.x > field.GetLength(1) - 2 ||
            newHead.y < 1 || newHead.y > field.GetLength(0) - 2)
        {
            Console.WriteLine("Game Over!");
            return false;
        }

        // перевірка зіткнення із самим собою
        if (snake.Contains(newHead))
        {
            Console.WriteLine("Game Over!");
            return false;
        }

        // додаємо голову
        snake.Insert(0, newHead);

        // якщо не з’їв їжу → видаляємо хвіст
        if (newHead == food)
        {
            GenerateFood();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }

        FillTheField();
        return true;
    }
}


