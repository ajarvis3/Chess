using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    /// <summary>
    /// Ensures that a piece does not move through or on top of another piece
    /// </summary>
    class NoJumpConstraint : IConstraint
    {
        /// <summary>
        /// Empty Default Constructor
        /// </summary>
        public NoJumpConstraint()
        {

        }


        public bool ConstraintSatisfied(Piece piece, int toRow, int toCol, Board<Piece> board)
        {
            throw new NotImplementedException();
        }
    }
}
