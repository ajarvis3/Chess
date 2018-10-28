using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

namespace Chess.Views
{
    /// <summary>
    /// Will probably be most or all of the View for Chess.
    /// </summary>
    class ChessMain
    {

        /// <summary>
        /// Gets input from the user
        /// </summary>
        /// <param name="output"></param>
        /// <returns> The string representing user's input </returns>
        static string GetInput(string output)
        {
            string ret = "";
            Console.WriteLine(output);
            while ((ret = Console.ReadLine()).Length.Equals(0))
            {
                Console.WriteLine(output);
            }
            return ret;
        }

        /// <summary>
        /// Prints the board for this game.
        /// </summary>
        /// <param name="bc"> The BoardController of the game. </param>
        static void PrintBoard(BoardController bc)
        {
            Console.Write(bc);
        }

        /// <summary>
        /// Plays the game
        /// </summary>
        private static void PlayGame(string p1, string p2, BoardController bc)
        {
            //int currPlayer = 0;
            Console.WriteLine(bc.MakeMove("pb1", 'b', 3, 1));
        }

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"> Program args </param>
        static void Main(String[] args)
        {
            string p1 = GetInput("Player 1 Enter Your Name");
            string p2 = GetInput("Player 2 Enter Your Name");
            BoardController bc = new BoardController(p1, p2);
            PrintBoard(bc);
            PlayGame(p1, p2, bc);
            PrintBoard(bc);
            GetInput("Ready?");
        }
    }
}
