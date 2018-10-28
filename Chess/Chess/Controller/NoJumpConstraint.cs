using System;
using System.Collections.Generic;
using System.Text;
using Chess.Model;

namespace Chess.Controller
{
    /// <summary>
    /// Ensures that a piece does not move through or on top of another piece
    /// </summary>
    class NoJumpConstraint : IConstraint
    {
        private static readonly NoJumpConstraint NoJump = new NoJumpConstraint();

        /// <summary>
        /// Private constructor so singleton pattern is enforced
        /// </summary>
        private NoJumpConstraint() { }

        /// <summary>
        /// Gets the instance of the NoJumpConstraint
        /// </summary>
        /// <returns> the instance of the NoJumpConstraint </returns>
        public static IConstraint GetConstraint()
        {
            return NoJump;
        }

        /// <summary>
        /// Ensures that a piece does not move through/over other pieces
        /// </summary>
        /// <param name="piece"> Piece that is trying to move </param>
        /// <param name="toRow"> the row the piece is trying to move to </param>
        /// <param name="toCol"> the column the piece is trying to move to </param>
        /// <param name="board"> the Board that is used by this game </param>
        /// <returns> the bool for whether the constraint is satisfied </returns>
        public bool ConstraintSatisfied(Piece piece, int toRow, int toCol, Board<Piece> board)
        {
            int r = piece.Row;
            int c = piece.Column;
            int rInc = (piece.Row < toRow ? 1 : -1); 
            int cInc = (piece.Column < toCol ? 1 : -1);
            try
            {
                if (toCol.Equals(piece.Column))
                {
                    cInc = 0;
                }
                else if (toRow.Equals(piece.Row))
                {
                    rInc = 0;
                }
                r = piece.Row + rInc;
                c = piece.Column + cInc;
                while (r != toRow && c != toCol)
                {
                    if (!board.GetBoardPos(r, c).Equals(default(Piece)))
                    {
                        return false;
                    }
                    r = r + rInc;
                    c = c + cInc;
                }
                return true;
            }                
            catch(IndexOutOfRangeException e)
            {
                return false;
            }
        }

    }
}
