public class Game
{
    private int x = 5;
    private int y = 5;
    private char[,] field = new char[10, 10];
    public void FillTheField()
    {
        Console.Clear();
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (j == x && i == y) field[i, j] = '@';
                else field[i, j] = '_';

                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
    }
    public void MovingThePerson(char direction)
    {
        switch (direction)
        {
            case 'w':
                y -= 1;
                FillTheField();
                break;
            case 's':
                y += 1;
                FillTheField();
                break;
            case 'a':
                x -= 1;
                FillTheField();
                break;
            case 'd':
                x += 1;
                FillTheField();
                break;
        }
    }
}