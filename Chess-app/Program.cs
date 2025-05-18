string[,] str = new string[8, 8];//TODO: Board class in cs file

Console.Write("Enter position=");//TODO: GameIO class in cs file 
string position1 = Console.ReadLine();
PlaceMarker(position1);
DrawBoard();

Console.Write("Enter position=");
string position2 = Console.ReadLine();
PlaceMarker(position2);
DrawBoard();

//RockMove();
DrawBoard();
KnightMoveCount();
Console.ReadLine();
void DrawBoard()
{
    for (int i = 0; i < 8; i++)
    {
        Console.Write($" {8 - i} ");
        for (int j = 0; j < 8; j++)
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

void PlaceMarker(string pos)//TODO: Board class in cs file
{
    if (pos.Length != 2) 
        return;   //TODO: throw new exaption

    int col = char.ToUpper(pos[0]) - 'A';

    int row = 8 - (pos[1] - '0');

    if (row < 0 || row > 7 || col < 0 || col > 7) 
        return;//TODO: throw new exaption

    str[row, col] = "X"; 
}

void RockMove()
{
    int x1 = char.ToUpper(position1[0]) - 'A';
    int y1 = 8 - (position1[1] - '0');       //TODO: Coordinate struct

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
void KnightMoveCount()
{
    int x1 = char.ToUpper(position1[0]) - 'A';
    int y1 = 8 - (position1[1] - '0');

    int x2 = char.ToUpper(position2[0]) - 'A';
    int y2 = 8 - (position2[1] - '0');

    int[,] memo = new int[8, 8];   //TODO:boolean 2d matrix 
    for (int i = 0; i < 8; i++)
        for (int j = 0; j < 8; j++)
            memo[i, j] = -1;

    int steps = MinKnightSteps(x1, y1, x2, y2, memo);
    Console.WriteLine($"Minimum knight moves from {position1} to {position2}:{steps}");

}
int MinKnightSteps(int x, int y, int targetX, int targetY, int[,] memo)
{
    if (x < 0 || x >= 8 || y < 0 || y >= 8)
        return int.MaxValue;

    if (x == targetX && y == targetY)
        return 0;

    if (memo[x, y] != -1)
        return memo[x, y];

    memo[x, y] = int.MaxValue - 1; 

    int[] dRow = { -2, -2, -1, 1, 2, 2, 1, -1 };
    int[] dCol = { -1, 1, 2, 2, 1, -1, -2, -2 };

    int min = int.MaxValue;

    for (int i = 0; i < 8; i++)
    {
        int nextX = x + dRow[i];
        int nextY = y + dCol[i];

        int steps = MinKnightSteps(nextX, nextY, targetX, targetY, memo);

        if (steps != int.MaxValue)
        {
            min = Math.Min(min, steps + 1);
        }
    }
    memo[x, y] = min; 
    return min;
}
