using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

namespace Chess.Model
{
    /// <summary>
    /// Represents the Queen piece in chess
    /// </summary>
    class Queen : Royal
    {

        /// <summary>
        /// Default constructor for Queen.
        /// </summary>
        public Queen() : base()
        {
            Name = "Queen";
            foreach (Movement move in PossibleMovements)
            {
                move.NumTimes = 8;
            }
        }

        /// <summary>
        /// Overlaoded Constructor
        /// </summary>
        /// <param name="row"> int representing start row </param>
        /// <param name="column"> int representing start column </param>
        /// <param name="owner"> string representing the owner of the piece </param>
        public Queen(int row, int column, string owner) : this()
        {
            Row = row;
            Column = column;
            Owner = owner;
        }

    }
}
