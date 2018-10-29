using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

namespace Chess.Model
{
    class Knight : Piece
    {

        /// <summary>
        /// Default constructor for knight
        /// </summary>
        public Knight() : base()
        {
            Name = "Night";
            List<Movement> moves = new List<Movement>();
            IConstraint unoc = UnoccupiedConstraint.GetConstraint();
            moves.Add(new Movement(2, 1, 1));
            moves.Add(new Movement(1, 2, 1));
            moves.Add(new Movement(2, -1, 1));
            moves.Add(new Movement(1, -2, 1));
            moves.Add(new Movement(-2, 1, 1));
            moves.Add(new Movement(-1, 2, 1));
            moves.Add(new Movement(-2, -1, 1));
            moves.Add(new Movement(-1, -2, 1));
            foreach (Movement m in moves)
            {
                m.AddConstraint(unoc);
            }
            PossibleMovements = moves;
        }

        /// <summary>
        /// Overloaded Constructor for Knight
        /// </summary>
        /// <param name="row"> the int representing the row </param>
        /// <param name="column"> the int representing the column </param>
        /// <param name="owner"> the string representing the owner </param>
        /// <param name="uniqueId"> the string with a uniqueId </param>
        public Knight(int row, int column, string owner, string uniqueId) : this()
        {
            Row = row;
            Column = column;
            Owner = owner;
            UniqueId = uniqueId;
        }
    }
}
