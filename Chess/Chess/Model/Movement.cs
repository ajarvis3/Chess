using System;
using System.Collections.Generic;
using System.Text;
using Chess.Model;

namespace Chess.Model
{
    class Movement
    {
        internal int AbsSlope { get; set; }
        internal int NumTimes { get; set; }
        internal IConstraint Cons { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Movement() { }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="slope"> the int representing slope that a piece can move </param>
        /// <param name="num"> the int representing the number of times a slop can be moved along </param>
        /// <param name="cons"> the Constraint that restricts movement for this slope </param>
        public Movement (int slope, int num, IConstraint cons)
        {
            this.AbsSlope = slope;
            this.NumTimes = num;
            this.Cons = cons;
        }


    }
}
