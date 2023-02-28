/* n*n
 * coordinates -0,1,-1,-1...
 *matrix
 *   firstPlayer++
 *   foreach coordinates
 *   if is in range
 *   if >
 *     firstPlayer-=1; x
 *   else if <
 *     secondPlayer-=1; x
 *   else if #
 *    X up/down right/left diagonals 
 *     up/down if >||< firstPlayer/secondPlayer--
 * no coordinates || firstPlayer == 0 ||secondPlayer == 0    
 */
int n = int.Parse(Console.ReadLine());



int[] coordinates = Console.ReadLine()
    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
string[,] matrix = new string[n, n];

int firstPlayer = 0; //<
int secondPlayer = 0;//>
int totalShips = 0;

for (int row = 0; row < matrix.GetLength(0); row++)
{
    // # < > *
    string[] input = Console.ReadLine().Split();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];

        if (matrix[row, col] == "<")
        {
            firstPlayer++;
        }
        else if (matrix[row, col] == ">")
        {
            secondPlayer++;
        }
    }
}

totalShips = firstPlayer + secondPlayer;

for (int i = 0; i < coordinates.Length - 1; i += 2)
{
    int row = coordinates[i];
    int col = coordinates[i + 1];

    if (!IsInRange(matrix, row, col))
    {
        continue;
    }

    if (matrix[row, col] == ">")
    {
        secondPlayer--;
        matrix[row, col] = "X";
    }
    else if (matrix[row, col] == "<")
    {
        firstPlayer--;
        matrix[row, col] = "X";
    }
    else if (matrix[row, col] == "#")
    {
        //up
        BombCell(matrix, ref firstPlayer, ref secondPlayer, row - 1, col);
        //down
        BombCell(matrix, ref firstPlayer, ref secondPlayer, row + 1, col);
        //left
        BombCell(matrix, ref firstPlayer, ref secondPlayer, row, col - 1);
        //righ
        BombCell(matrix, ref firstPlayer, ref secondPlayer, row, col + 1);
        //up left
        BombCell(matrix, ref firstPlayer, ref secondPlayer, row - 1, col - 1);
        //up right
        BombCell(matrix, ref firstPlayer, ref secondPlayer, row - 1, col + 1);
        //down left
        BombCell(matrix, ref firstPlayer, ref secondPlayer, row + 1, col - 1);
        //down right
        BombCell(matrix, ref firstPlayer, ref secondPlayer, row + 1, col + 1);

    }
}

if (firstPlayer > 0 && secondPlayer > 0)
{
    Console.WriteLine($"It's a draw! Player One has {firstPlayer} ships left. Player Two has {secondPlayer} ships left.");
}
else if (firstPlayer > 0)
{
    Console.WriteLine($"Player One has won the game! {totalShips - firstPlayer} ships have been sunk in the battle.");
}
else
{
    Console.WriteLine($"Player Two has won the game! {totalShips - secondPlayer} ships have been sunk in the battle.");
}


bool IsInRange(string[,] matrix, int row, int col)
=> row >= 0 && row <= matrix.GetLength(0) && col >= 0 && col <= matrix.GetLength(1);

void BombCell(string[,] matrix, ref int firstPlayer, ref int secondPlayer, int row, int col)
{
    if (!IsInRange(matrix, row, col))
    {
        return;

    }
    if (matrix[row, col] == ">")
    {
        secondPlayer--;
    }
    else if (matrix[row, col] == "<")
    {
        firstPlayer--;
    }
    matrix[row, col] = "X";
}