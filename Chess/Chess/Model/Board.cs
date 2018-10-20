using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    class Board<T>
    {
        internal T[,] Matrix { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        Board()
        {
            Matrix = new T[1, 1];
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="rows"> represents the number of rows </param>
        /// <param name="columns"> represents the number of columns </param>
        Board(int rows, int columns)
        {
            Matrix = new T[rows, columns];
        }
    }
}
