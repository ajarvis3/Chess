using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    class Queen : Royal
    {

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
