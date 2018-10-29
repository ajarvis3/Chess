using System;
using System.Collections.Generic;
using System.Text;
using Chess.Model;

namespace Chess.Controller
{
    /// <summary>
    /// A constraint to prevent a pawn from moving forward when there are any pieces.
    /// </summary>
    class PawnUnoccupiedConstraint : IConstraint
    {
        private static readonly PawnUnoccupiedConstraint Poc = new PawnUnoccupiedConstraint();

        /// <summary>
        /// Private, default constructor to enforce singleton
        /// </summary>
        private PawnUnoccupiedConstraint()
        {
        }

        /// <summary>
        /// Gets the singleton constraint
        /// </summary>
        /// <returns> The singleton constraint </returns>
        public static IConstraint GetConstraint()
        {
            return Poc;
        }

        /// <summary>
        /// Checks to see if the constraint is satisfied
        /// </summary>
        /// <param name="piece"> The piece that is trying to move </param>
        /// <param name="toRow"> The row the piece is trying to move to </param>
        /// <param name="toCol"> The column the piece is trying to move to </param>
        /// <param name="board"> The board that the piece is on </param>
        /// <returns></returns>
        public bool ConstraintSatisfied(Piece piece, int toRow, int toCol, Board<Piece> board)
        {
            try
            {
                return board.GetBoardPos(toRow, toCol).Equals(default(Piece));
            }
            catch (NullReferenceException)
            {
                return true;
            }
        }
    }
}
