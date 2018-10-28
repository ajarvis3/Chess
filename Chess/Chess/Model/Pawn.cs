using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

namespace Chess.Model
{
    /// <summary>
    /// Class representing a Pawn in chess.
    /// Only currently accounts for single move forward and diagonal capture.
    /// </summary>
    class Pawn : Piece
    {

        /// <summary>
        /// Overloaded Constructor for Pawn
        /// </summary>
        /// <param name="upDown"> the int for whether the pawn moves up or down </param>
        public Pawn(int upDown) : base()
        {
            Name = "pawn";
            Movement forward = new Movement(upDown, 0, 1);
            forward.AddConstraint(PawnUnoccupiedConstraint.GetConstraint());
            Movement diag1 = new Movement(1, 1, 1);
            Movement diag2 = new Movement(1, -1, 1);
            diag1.AddConstraint(PawnEnemyDiagonalConstraint.GetConstraint());
            diag2.AddConstraint(PawnEnemyDiagonalConstraint.GetConstraint());
            List<Movement> moves = new List<Movement>
            {
                forward,
                diag1,
                diag2
            };
            PossibleMovements = moves;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="row"> the int representing the start row </param>
        /// <param name="column"> the int representing the start column </param>
        /// <param name="owner"> the string representing the owner </param>
        /// <param name="upDown"> the int for whether the pawn moves up or down </param>
        /// <param name="uniqueId"> the string with a unique identifier </param>
        public Pawn(int row, int column, string owner, int upDown, string uniqueId) : this(upDown)
        {
            Row = row;
            Column = column;
            Owner = owner;
            UniqueId = uniqueId;
        }
    }
}
