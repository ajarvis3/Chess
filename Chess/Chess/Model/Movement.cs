using System;
using System.Collections.Generic;
using System.Text;
using Chess.Model;

namespace Chess.Model
{
    class Movement
    {
        internal int AbsNumerator { get; set; }
        internal int AbsDenominator { get; set; }
        internal int NumTimes { get; set; }
        internal IConstraint Cons { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Movement() { }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="numerator"> the int representing the numerator for a slope </param>
        /// <param name="denominator"> the int representing the denominator for a slope </param>
        /// <param name="num"> the int representing the number of times a slop can be moved along </param>
        /// <param name="cons"> the Constraint that restricts movement for this slope </param>
        public Movement (int numerator, int denominator, int num, IConstraint cons)
        {
            this.AbsNumerator = numerator;
            this.AbsDenominator = denominator;
            this.NumTimes = num;
            this.Cons = cons;
        }


    }
}
