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
        /// Checks if the game is over.
        /// I think this could be done better. Perhaps check which piece is removed to determine?
        /// </summary>
        /// <returns> Returns the bool for whether the game is over </returns>
        public bool IsGameOver()
        {
            bool flag = false;
            foreach (Piece p in Player1)
            {
                if (p.Name.Equals("King"))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                return false;
            }
            foreach (Piece p in Player2)
            {
                if (p.Name.Equals("King"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sets up player 1's pieces
        /// </summary>
        private void SetUpPlayer1()
        {
            Player1.Add(new Rook(0, 0, P1Name, "0"));
            Player1.Add(new Knight(0, 1, P1Name, "0"));
            Player1.Add(new Bishop(0, 2, P1Name, "0"));
            Player1.Add(new Queen(0, 3, P1Name, "0"));
            Player1.Add(new King(0, 4, P1Name, "0"));
            Player1.Add(new Bishop(0, 5, P1Name, "1"));
            Player1.Add(new Knight(0, 6, P1Name, "1"));
            Player1.Add(new Rook(0, 7, P1Name, "1"));
            for (int i = 0; i < 8; i++)
            {
                Player1.Add(new Pawn(1, i, P1Name, 1, i.ToString()));
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
            Player2.Add(new Rook(7, 0, P2Name, "0"));
            Player2.Add(new Knight(7, 1, P2Name, "0"));
            Player2.Add(new Bishop(7, 2, P2Name, "0"));
            Player2.Add(new Queen(7, 3, P2Name, "0"));
            Player2.Add(new King(7, 4, P2Name, "0"));
            Player2.Add(new Bishop(7, 5, P2Name, "1"));
            Player2.Add(new Knight(7, 6, P2Name, "1"));
            Player2.Add(new Rook(7, 7, P2Name, "1"));
            for (int i = 0; i < 8; i++)
            {
                Player2.Add(new Pawn(6, i, P2Name, -1, i.ToString()));
            }
            foreach (Piece p in Player2)
            {
                Board.SetBoardPos(p.Row, p.Column, p);
            }
        }

        /// <summary>
        /// Attempts to make a move.
        /// </summary>
        /// <param name="piece"> The piece that the player is trying to move. </param>
        /// <param name="player"> The player who is trying to move the piece. </param>
        /// <param name="toRow"> The row the player wants to move the piece to. </param>
        /// <param name="toCol"> The column the player wants to move the piece to. </param>
        /// <returns> A string message for what happened. Empty if completed. </returns>
        public string MakeMove(string piece, char player, int toRow, int toCol)
        {
            try
            {
                char c = piece.ToCharArray()[1];
                if (c != player)
                {
                    return "Not your piece!";
                }
                if (player == P1Name.ToCharArray()[0])
                {
                    Piece p = null;
                    foreach (Piece pie in Player1)
                    {
                        if (pie.ToString().Equals(piece))
                        {
                            p = pie;
                            break;
                        }
                    }
                    if (p == null)
                    {
                        return "Piece does not exist!";
                    }
                    List<Movement> moves = p.PossibleMovements;
                    // check for valid move
                    Board.SetBoardPos(p.Row, p.Column, default(Piece));
                    Board.SetBoardPos(toRow, toCol, p);
                    p.Row = toRow;
                    p.Column = toCol;
                }
                else
                {

                }
                return "";
            }
            catch(IndexOutOfRangeException e)
            {
                return "Piece does not exist!";
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
                        res += "XX ";
                    }
                }
                res += "\n";
            }
            return res;
        }

    }
}
