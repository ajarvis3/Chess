using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    class Knight : Piece
    {

        public Knight() : base()
        {
            Name = "Knight";
        }

        public Knight(int row, int column, string owner) : this()
        {
            Row = row;
            Column = column;
            List<Movement> moves = new List<Movement>();
            UnoccupiedConstraint unoc = new UnoccupiedConstraint();

        }
    }
}
