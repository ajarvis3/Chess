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
        private Dictionary<string, Piece> Player1;
        private Dictionary<string, Piece> Player2;
        private string P1Name;
        private string P2Name;

        /// <summary>
        /// Default constructor
        /// </summary>
        private BoardController()
        {
            this.Board = new Board<Piece>(N, N);
            this.Player1 = new Dictionary<string, Piece>();
            this.Player2 = new Dictionary<string, Piece>();
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
            return !Player1.ContainsKey("K" + P1Name.ToCharArray()[0] + "0") || !Player2.ContainsKey("K" + P2Name.ToCharArray()[0] + "0");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="p"></param>
        private void AddToDictionary(Dictionary<string, Piece> dict, Piece p)
        {
            dict.Add(p.ToString(), p);
        }

        /// <summary>
        /// Sets up player 1's pieces
        /// </summary>
        private void SetUpPlayer1()
        {
            AddToDictionary(Player1, new Rook(0, 0, P1Name, "0"));
            AddToDictionary(Player1, new Knight(0, 1, P1Name, "0"));
            AddToDictionary(Player1, new Bishop(0, 2, P1Name, "0"));
            AddToDictionary(Player1, new Queen(0, 3, P1Name, "0"));
            AddToDictionary(Player1, new King(0, 4, P1Name, "0"));
            AddToDictionary(Player1, new Bishop(0, 5, P1Name, "1"));
            AddToDictionary(Player1, new Knight(0, 6, P1Name, "1"));
            AddToDictionary(Player1, new Rook(0, 7, P1Name, "1"));
            for (int i = 0; i < 8; i++)
            {
                AddToDictionary(Player1, new Pawn(1, i, P1Name, 1, i.ToString()));
            }
            foreach (KeyValuePair<string, Piece> p in Player1)
            {
                Board.SetBoardPos(p.Value.Row, p.Value.Column, p.Value);
            }
        }

        /// <summary>
        /// Sets up player 2.
        /// </summary>
        private void SetUpPlayer2()
        {
            AddToDictionary(Player2, new Rook(7, 0, P2Name, "0"));
            AddToDictionary(Player2, new Knight(7, 1, P2Name, "0"));
            AddToDictionary(Player2, new Bishop(7, 2, P2Name, "0"));
            AddToDictionary(Player2, new Queen(7, 3, P2Name, "0"));
            AddToDictionary(Player2, new King(7, 4, P2Name, "0"));
            AddToDictionary(Player2, new Bishop(7, 5, P2Name, "1"));
            AddToDictionary(Player2, new Knight(7, 6, P2Name, "1"));
            AddToDictionary(Player2, new Rook(7, 7, P2Name, "1"));
            for (int i = 0; i < 8; i++)
            {
                AddToDictionary(Player2, new Pawn(6, i, P2Name, -1, i.ToString()));
            }
            foreach (KeyValuePair<string, Piece> p in Player2)
            {
                Board.SetBoardPos(p.Value.Row, p.Value.Column, p.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private List<IndexBundle> PossibleMovementHelper(Piece p, Movement m)
        {
            List<IndexBundle> bundle = new List<IndexBundle>();
            int initRow = p.Row;
            int initCol = p.Column;
            int numer = m.Numerator;
            int denom = m.Denominator;
            List<IConstraint> cons = m.Cons;
            for (int i = 1; i <= m.NumTimes; i++)
            {
                int tNum = numer * i;
                int tDen = denom * i;
                bool flag = true;
                foreach (IConstraint c in cons)
                {
                    try
                    {
                        if (!c.ConstraintSatisfied
                            (p, initRow + tNum, initCol + tDen, Board))
                        {
                            flag = false;
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    bundle.Add(new IndexBundle(initRow + tNum, initCol + tDen));
                }
            }
            p.AddIndices(bundle);
            return bundle;
        }

        /// <summary>
        /// Gets the possible movements for a given piece.
        /// Can probably refactor some of the information into other methods.
        /// </summary>
        /// <param name="piece"> The piece someone is trying to move </param>
        /// <param name="player"> The player trying to move the piece </param>
        /// <returns></returns>
        public string GetPossibleMovements(string piece, char player)
        {
            List<IndexBundle> bundle = new List<IndexBundle>();
            char c = piece.ToCharArray()[1];
            string ret = "";
            if (c != player)
            {
                ret = "Not your piece!";
            }
            else if (player == P1Name.ToCharArray()[0])
            {                
                if (!Player1.ContainsKey(piece))
                {
                    ret = "Piece does not exist!";
                }
                else
                {
                    Piece p = Player1[piece];
                    List<Movement> moves = p.PossibleMovements;
                    foreach (Movement m in moves)
                    {
                        bundle.AddRange(PossibleMovementHelper(p, m));
                    }
                    ret = "[";
                    foreach (IndexBundle b in bundle)
                    {
                        ret = ret + b.ToString() + " ";
                    }
                    ret = ret + "]";
                }
            }
            else
            {                
                if (!Player2.ContainsKey(piece))
                {
                    ret = "Piece does not exist!";
                }
                else
                {
                    Piece p = Player2[piece];
                    List<Movement> moves = new List<Movement>();
                    foreach (Movement m in moves)
                    {
                        bundle.AddRange(PossibleMovementHelper(p, m));
                    }
                    ret = "[";
                    foreach (IndexBundle b in bundle)
                    {
                        ret = ret + b.ToString() + " ";
                    }
                    ret = ret + "]";
                }
            }
            return ret;
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
                if (player == P1Name.ToCharArray()[0])
                {
                    try
                    {
                        Piece p = Player1[piece];
                        // check for valid move
                        Board.SetBoardPos(p.Row, p.Column, default(Piece));
                        Board.SetBoardPos(toRow, toCol, p);
                        p.Row = toRow;
                        p.Column = toCol;
                    }
                    catch
                    {
                        return "Piece Does Not Exist";
                    }
                }
                else
                {
                    if (!Player2.ContainsKey(piece))
                    {
                        return "Piece doesn't exist";
                    }
                    Piece p = Player2[piece];
                    Board.SetBoardPos(p.Row, p.Column, default(Piece));
                    Board.SetBoardPos(toRow, toCol, p);
                    p.Row = toRow;
                    p.Column = toCol;
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
                        res += "XXX ";
                    }
                }
                res += "\n";
            }
            return res;
        }

    }
}
