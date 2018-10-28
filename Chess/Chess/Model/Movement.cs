using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

namespace Chess.Model
{
    /// <summary>
    /// Contains information on how a piece can move.
    /// </summary>
    class Movement
    {
        internal int Numerator { get; set; }
        internal int Denominator { get; set; }
        internal int NumTimes { get; set; }
        internal List<IConstraint> Cons { get; set; }

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
        public Movement (int numerator, int denominator, int num)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            this.NumTimes = num;
            this.Cons = new List<IConstraint>();
        }

        /// <summary>
        /// Adds a constraint to this movement
        /// </summary>
        /// <param name="c"> the Constraint to be added </param>
        public void AddConstraint(IConstraint c)
        {
            this.Cons.Add(c);
        }


    }
}
