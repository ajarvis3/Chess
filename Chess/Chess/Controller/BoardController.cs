using System;
using System.Collections.Generic;
using System.Text;
using Chess.Model;

namespace Chess.Controller
{
    /// <summary>
    /// The Controller for the board.
    /// Also contains pieces.
    /// </summary>
    class BoardController
    {
        private static readonly int N = 8;
        private Board<Piece> Board;
        private List<Piece> Player1;
        private List<Piece> Player2;
        private string P1Name;
        private string P2Name;

        /// <summary>
        /// Default constructor
        /// </summary>
        private BoardController()
        {
            this.Board = new Board<Piece>(N, N);
            this.Player1 = new List<Piece>();
            this.Player2 = new List<Piece>();
        }

        /// <summary>
        /// User-Defined Constructor
        /// </summary>
        /// <param name="p1"> the name of player 1 </param>
        /// <param name="p2"> the name of player 2 </param>
        public BoardController(string p1, string p2) : this()
        {
            this.P1Name = p1;
            this.P2Name = p2;
            SetUpPlayer1();
            SetUpPlayer2();
        }

        /// <summary>
        /// Sets up player 1's pieces
        /// </summary>
        private void SetUpPlayer1()
        {
            Player1.Add(new Rook(0, 0, P1Name));
            Player1.Add(new Knight(0, 1, P1Name));
            Player1.Add(new Bishop(0, 2, P1Name));
            Player1.Add(new Queen(0, 3, P1Name));
            Player1.Add(new King(0, 4, P1Name));
            Player1.Add(new Bishop(0, 5, P1Name));
            Player1.Add(new Knight(0, 6, P1Name));
            Player1.Add(new Rook(0, 7, P1Name));
            for (int i = 0; i < 8; i++)
            {
                Player1.Add(new Pawn(1, i, P1Name, 1));
            }
            foreach (Piece p in Player1)
            {
                Board.SetBoardPos(p.Row, p.Column, p);
            }
        }

        /// <summary>
        /// Sets up player 2.
        /// </summary>
        private void SetUpPlayer2()
        {
            Player1.Add(new Rook(7, 0, P1Name));
            Player1.Add(new Knight(7, 1, P1Name));
            Player1.Add(new Bishop(7, 2, P1Name));
            Player1.Add(new Queen(7, 3, P1Name));
            Player1.Add(new King(7, 4, P1Name));
            Player1.Add(new Bishop(7, 5, P1Name));
            Player1.Add(new Knight(7, 6, P1Name));
            Player1.Add(new Rook(7, 7, P1Name));
            for (int i = 0; i < 8; i++)
            {
                Player1.Add(new Pawn(6, i, P1Name, -1));
            }
            foreach (Piece p in Player1)
            {
                Board.SetBoardPos(p.Row, p.Column, p);
            }
        }

        /// <summary>
        /// Overrides ToString. 
        /// </summary>
        /// <returns> Returns a formatted string representation of the board. </returns>
        public override string ToString()
        {
            string res = "";
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    Piece p = Board.GetBoardPos(r, c);
                    try
                    {
                        res += p.ToString() + " ";
                    }
                    catch(NullReferenceException)
                    {
                        res += "XXX ";
                    }
                }
                res += "\n";
            }
            return res;
        }

    }
}
