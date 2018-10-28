using System;
using System.Collections.Generic;
using System.Text;
using Chess.Model;

namespace Chess.Controller
{
    /// <summary>
    /// Checks that the spot on the board being moved to does not have a piece with the same owner.
    /// </summary>
    class UnoccupiedConstraint : IConstraint
    {
        private static readonly UnoccupiedConstraint Unoc = new UnoccupiedConstraint();

        /// <summary>
        /// Private constructor to ensure that singleton is used
        /// </summary>
        private UnoccupiedConstraint() { }

        /// <summary>
        /// Gets the instance of this constraint
        /// </summary>
        /// <returns> the only instance of this constraint </returns>
        public static IConstraint GetConstraint()
        {
            return Unoc;
        }

        /// <summary>
        /// Ensures that a piece does not land on a spot occupied by another piece with the same owner
        /// </summary>
        /// <param name="piece"> the piece to move </param>
        /// <param name="toRow"> the row the piece is trying to move to </param>
        /// <param name="toCol"> the column the piece is trying to move to </param>
        /// <param name="board"> the Board of Pieces that represent the game board </param>
        /// <returns></returns>
        public bool ConstraintSatisfied(Piece piece, int toRow, int toCol, Board<Piece> board)
        {
            Piece other = board.GetBoardPos(toRow, toCol);
            if (other.Equals(default(Piece)))
            {
                return true;
            }
            if (!other.Owner.Equals(piece.Owner))
            {
                return true;
            }
            return false;
        }
    }
}
