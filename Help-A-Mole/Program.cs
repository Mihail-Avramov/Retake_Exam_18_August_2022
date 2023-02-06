using System;

namespace Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];

            int mRow = -1;
            int mCol = -1;
            int s1Row = -1;
            int s1Col = -1;
            int s2Row = -1;
            int s2Col = -1;

            int totalPoints = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                string colValues = Console.ReadLine();
                for (int col = 0; col < fieldSize; col++)
                {
                    field[row,col] = colValues[col];

                    if (colValues[col] == 'M')
                    {
                        mRow = row;
                        mCol = col;
                        continue;
                    }

                    if (colValues[col] == 'S')
                    {
                        if (s1Row == -1)
                        {
                            s1Row = row;
                            s1Col = col;
                        }
                        else
                        {
                            s2Row = row;
                            s2Col = col;
                        }
                        continue;
                    }
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End" && totalPoints < 25)
            {
                switch (input)
                {
                    case "up":
                    {
                        int indexToCheck = mRow - 1;
                        if (isValidIndex(indexToCheck, fieldSize))
                        {
                            field[mRow, mCol] = '-';
                            mRow = indexToCheck;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }

                        break;
                    }
                    case "down":
                    {
                        int indexToCheck = mRow + 1;
                        if (isValidIndex(indexToCheck, fieldSize))
                        {
                            field[mRow, mCol] = '-';
                            mRow = indexToCheck;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }

                        break;
                    }
                    case "left":
                    {
                        int indexToCheck = mCol - 1;
                        if (isValidIndex(indexToCheck, fieldSize))
                        {
                            field[mRow, mCol] = '-';
                            mCol = indexToCheck;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }

                        break;
                    }
                    case "right":
                    {
                        int indexToCheck = mCol + 1;
                        if (isValidIndex(indexToCheck, fieldSize))
                        {
                            field[mRow, mCol] = '-';
                            mCol = indexToCheck;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }

                        break;
                    }
                }

                if (field[mRow, mCol] == 'S')
                {
                    totalPoints -= 3;
                    field[mRow, mCol] = '-';
                    if (mRow == s1Row && mCol == s1Col)
                    {
                        mRow = s2Row;
                        mCol = s2Col;
                    }
                    else
                    {
                        mRow = s1Row;
                        mCol = s1Col;
                    }
                    field[mRow, mCol] = 'M';
                    continue;
                }

                if (char.IsDigit(field[mRow, mCol]))
                {
                    int pointsToAdd = (int)field[mRow, mCol] - 48;
                    totalPoints += pointsToAdd;
                    field[mRow, mCol] = 'M';
                    continue;
                }

                field[mRow, mCol] = 'M';

            }

            if (totalPoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {totalPoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {totalPoints} points.");
            }

            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool isValidIndex(int indexToCheck, int fieldSize)
        {
            return indexToCheck >= 0 && indexToCheck < fieldSize;
        }
    }
}
