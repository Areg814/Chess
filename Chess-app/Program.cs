string[,] str = new string[8, 8];

Console.WriteLine("Enter position=");
string position1 = Console.ReadLine();
PlaceMarker(position1);
DrawBoard();

Console.WriteLine("Enter position=");
string position2 = Console.ReadLine();
PlaceMarker(position2);
DrawBoard();

RockMove();
DrawBoard();
Console.WriteLine(2);

void DrawBoard()
{
    for (int i = 0; i < str.GetLength(0); i++)
    {

        Console.Write($" {8 - i} ");
        for (int j = 0; j < str.GetLength(1); j++)
        {

            if ((i + j) % 2 == 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }


            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write($" {str[i, j] ?? " "} ");
        }
        Console.ResetColor();
        Console.WriteLine();
    }


    Console.Write("   ");
    for (char c = 'A'; c <= 'H'; c++)
    {
        Console.Write($" {c} ");
    }
    Console.WriteLine();
}

void PlaceMarker(string pos)
{
    if (pos.Length != 2) return;

    int col = char.ToUpper(pos[0]) - 'A';

    int row = 8 - (pos[1] - '0');

    if (row < 0 || row > 7 || col < 0 || col > 7) return;

    str[row, col] = "X";
}

void RockMove()
{
    int x1 = char.ToUpper(position1[0]) - 'A';
    int y1 = 8 - (position1[1] - '0');

    int x2 = char.ToUpper(position2[0]) - 'A';
    int y2 = 8 - (position2[1] - '0');

    if (x1 == x2)
    {
        int minY = Math.Min(y1, y2);
        int maxY = Math.Max(y1, y2);
        for (int y = minY + 1; y < maxY; y++)
        {
            str[y, x1] = "X";
        }
    }
    else if (y1 == y2)
    {
        int minX = Math.Min(x1, x2);
        int maxX = Math.Max(x1, x2);
        for (int x = minX + 1; x < maxX; x++)
        {
            str[y1, x] = "X";
        }
    }
    else
    {
        int minY = Math.Min(y1, y2);
        int maxY = Math.Max(y1, y2);
        for (int y = minY; y < maxY; y++)
        {
            str[y, x1] = "X";
        }

        int minX = Math.Min(x1, x2);
        int maxX = Math.Max(x1, x2);
        for (int x = minX; x < maxX; x++)
        {
            str[y2, x] = "X";
        }

        str[y2, x2] = "X";
    }
}
