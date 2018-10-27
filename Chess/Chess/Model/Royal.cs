using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    /// <summary>
    /// A superclass for King and Queen Pieces
    /// </summary>
    class Royal : Piece
    {

        /// <summary>
        /// default constructor
        /// </summary>
        internal Royal() : base()
        {
            Row = 0;
            Column = 3;
            List<Movement> moves = new List<Movement>();
            NoJumpConstraint noJump = new NoJumpConstraint();
            moves.Add(new Movement(1, 1, 1, noJump));
            moves.Add(new Movement(0, 1, 1, noJump));
            moves.Add(new Movement(1, 0, 1, noJump));
            PossibleMovements = moves;
        }

    }
}
