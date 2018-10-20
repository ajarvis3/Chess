using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    /// <summary>
    /// Represents a Chess Piece. Individual Pieces will be derived from this one.
    /// </summary>
    class Piece
    {
        internal int Row { get; set; }
        internal int Column { get; set; }
        internal string Name { get; set; }
        internal List<Movement> PossibleMovements { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        internal Piece()
        {
            this.Row = 0;
            this.Column = 0;
            this.Name = "Piece";
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="row"> the int representing row of this piece </param>
        /// <param name="col"> the int representing column of this piece </param>
        /// <param name="name"> the string representing the name of this piece </param>
        /// <param name="moves"> the list of Movements that can be performed by this piece </param>
        internal Piece(int row, int col, string name, List<Movement> moves)
        {
            this.Row = row;
            this.Column = col;
            this.Name = name;
        }
    }
}
