using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag;

        /// <summary>
        /// Draws the game board
        /// </summary>
        static void Drawboard()
        {
            Console.WriteLine("  {0} |  {1} |  {2} ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("____|____|____");
            Console.WriteLine("    |    |    ");
            Console.WriteLine("  {0} |  {1} |  {2} ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("____|____|____");
            Console.WriteLine("    |    |    ");
            Console.WriteLine("  {0} |  {1} |  {2} ", spaces[6], spaces[7], spaces[8]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static int CheckWin()
        {
            if (spaces[0] == spaces[1] &&// row 1
                spaces[1] == spaces[2] ||
                spaces[3] == spaces[4] &&// row 2
                spaces[4] == spaces[5] ||
                spaces[6] == spaces[7] &&// row 3
                spaces[7] == spaces[8] ||
                spaces[0] == spaces[3] &&//column 1
                spaces[3] == spaces[6] ||
                spaces[1] == spaces[4] &&//column 2
                spaces[4] == spaces[7] ||
                spaces[2] == spaces[5] &&//column 3
                spaces[5] == spaces[8] ||
                spaces[0] == spaces[4] &&//diagonal 1
                spaces[4] == spaces[8] ||
                spaces[2] == spaces[4] &&//diagonal 2
                spaces[4] == spaces[6])
            {
                return 1;
            }
            else if (spaces[0] != '1' &&
                    spaces[1] != '2' &&
                    spaces[2] != '3' &&
                    spaces[3] != '4' &&
                    spaces[4] != '5' &&
                    spaces[5] != '6' &&
                    spaces[6] != '7' &&
                    spaces[7] != '8' &&
                    spaces[8] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
        
        
        /// <summary>
        /// Draws an X on the game board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawX(int pos)
        {
            spaces[pos] = 'x';
        }

        /// <summary>
        /// This function drows an O on the game board
        /// </summary>
        /// <param name="args"></param> remember to change args to pos if it doesn't work
        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }

        /// <summary>
        /// The main Game loop
        /// </summary>
        /// <param name="args"></param>
        

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 : x and Player 2: O");

                if(player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }else
                {
                    Console.WriteLine("Player 1's turn");
                }

                Console.WriteLine("");
                Drawboard();
                choice = int.Parse(Console.ReadLine()) - 1;

                if(spaces[choice] != 'x' && spaces[choice] != 'O')
                {
                    if(player % 2 == 0)
                    {
                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry the {0} is already marked with {1} ", choice, spaces[choice]);
                    Console.WriteLine("Reloading...");
                    System.Threading.Thread.Sleep(1000);
                }

                flag = CheckWin();
               
            }
            while (flag != 1 && flag != -1);

            Console.Clear();
            Drawboard();

            if(flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Tie Game");
            }

            Console.ReadLine();
        }
    }
}
