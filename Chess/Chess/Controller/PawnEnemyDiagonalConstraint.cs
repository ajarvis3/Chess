using System;
using System.Collections.Generic;
using System.Text;
using Chess.Model;

namespace Chess.Controller
{
    /// <summary>
    /// Checks to see if a pawn can move diagonally.
    /// Does not account for en passant.
    /// </summary>
    class PawnEnemyDiagonalConstraint : IConstraint
    {
        private static readonly PawnEnemyDiagonalConstraint Pedc = new PawnEnemyDiagonalConstraint();

        /// <summary>
        /// Private, default constructor to enforce singleton
        /// </summary>
        private PawnEnemyDiagonalConstraint()
        {
        }
    
        /// <summary>
        /// Gets the instance of this constraint
        /// </summary>
        /// <returns> the instance of this constraint </returns>
        public static IConstraint GetConstraint()
        {
            return Pedc;
        }

        /// <summary>
        /// Checks to see if the pawn can move diagonally
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
                if (board.GetBoardPos(toRow, toCol).Equals(default(Piece)))
                {
                    return false;
                }
                return !board.GetBoardPos(toRow, toCol).Owner.Equals(piece.Owner);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }
}
