using System;
using System.Collections.Generic;
using System.Text;
using Chess.Model;

namespace Chess.Controller
{
    /// <summary>
    /// Acts as a way of restricting movement of pieces.
    /// Specific constraints will inherit from here
    /// </summary>
    interface IConstraint
    {

        /// <summary>
        /// Tests to see if the constraint is satisfied
        /// </summary>
        /// <param name="piece"> the Piece that is being moved </param>
        /// <param name="toRow"> the int representing the row the piece is moving to </param>
        /// <param name="toCol"> the int representing the column the piece is moving to </param>
        /// <param name="board"> the board containing all the pieces </param>
        /// <returns> A bool for whether the move is applicable </returns>
        bool ConstraintSatisfied(Piece piece, int toRow, int toCol, Board<Piece> board);
        
    }
}
