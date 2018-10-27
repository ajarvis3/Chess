using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    class UnoccupiedConstraint : IConstraint
    {
        private static readonly UnoccupiedConstraint UNOC = new UnoccupiedConstraint();

        public static IConstraint GetConstraint()
        {
            return UNOC;
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
