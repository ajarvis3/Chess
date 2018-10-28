using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

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
            IConstraint noJump = NoJumpConstraint.GetConstraint();
            IConstraint unoc = UnoccupiedConstraint.GetConstraint();
            moves.Add(new Movement(1, 1, 1));
            moves.Add(new Movement(0, 1, 1));
            moves.Add(new Movement(1, 0, 1));
            moves.Add(new Movement(1, -1, 1));
            moves.Add(new Movement(0, -1, 1));
            moves.Add(new Movement(-1, 0, 1));
            moves.Add(new Movement(-1, 1, 1));
            moves.Add(new Movement(-1, -1, 1));
            foreach (Movement m in moves)
            {
                m.AddConstraint(unoc);
                m.AddConstraint(noJump);
            }
            PossibleMovements = moves;
        }

    }
}
