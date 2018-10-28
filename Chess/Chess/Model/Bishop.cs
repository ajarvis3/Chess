using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

namespace Chess.Model
{
    /// <summary>
    /// A class representing the bishop piece in chess
    /// </summary>
    class Bishop : Piece
    {

        /// <summary>
        /// Default Constructor for a Bishop piece
        /// </summary>
        public Bishop() : base()
        {
            Name = "Bishop";
            List<Movement> moves = new List<Movement>();
            IConstraint noJump = NoJumpConstraint.GetConstraint();
            moves.Add(new Movement(1, 1, 8));
            moves.Add(new Movement(1, -1, 8));
            moves.Add(new Movement(-1, 1, 8));
            moves.Add(new Movement(-1, -1, 8));
            foreach (Movement m in moves)
            {
                m.addConstraint(noJump);
            }
            PossibleMovements = moves;
        }


        /// <summary>
        /// Overloaded constructor for Bishop
        /// </summary>
        /// <param name="row"> int representing the start row </param>
        /// <param name="column"> int representing the start column </param>
        /// <param name="owner"> string representing the owner </param>
        public Bishop(int row, int column, String owner) : this()
        {
            Row = row;
            Column = column;
            Owner = owner;
        }

    }
}
