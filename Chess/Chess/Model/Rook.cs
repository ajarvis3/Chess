using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

namespace Chess.Model
{
    /// <summary>
    /// A class representing a rook in chess
    /// </summary>
    class Rook : Piece
    {

        /// <summary>
        /// Default constructor for Rook
        /// </summary>
        public Rook() : base()
        {
            Name = "Rook";
            List<Movement> moves = new List<Movement>();
            moves.Add(new Movement(1, 0, 8));
            moves.Add(new Movement(0, 1, 8));
            moves.Add(new Movement(-1, 0, 8));
            moves.Add(new Movement(0, -1, 8));
            IConstraint noJump = NoJumpConstraint.GetConstraint();
            foreach (Movement m in moves)
            {
                m.addConstraint(noJump);
            }
        }

        /// <summary>
        /// Overloaded constructor for Rook
        /// </summary>
        /// <param name="row"> int representing the start row </param>
        /// <param name="column"> int representing the start column </param>
        /// <param name="owner"> the string representing the owner </param>
        public Rook(int row, int column, string owner) : this()
        {
            Row = row;
            Column = column;
            Owner = owner;
        }
    }
}
