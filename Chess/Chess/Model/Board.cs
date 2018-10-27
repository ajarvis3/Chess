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
        public Board()
        {
            Matrix = new T[1, 1];
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="rows"> represents the number of rows </param>
        /// <param name="columns"> represents the number of columns </param>
        public Board(int rows, int columns)
        {
            Matrix = new T[rows, columns];
        }

        /// <summary>
        /// Gets the T from a specific row and column
        /// </summary>
        /// <param name="row"> the row of the board </param>
        /// <param name="column"> the column of the board</param>
        /// <returns> the T at the row and column </returns>
        public T GetBoardPos(int row, int column)
        {
            /// <exception cref="System.IndexOutOfRangeException"> thrown when a row or column is out of range </exception>
            try
            {
                return this.Matrix[row, column];
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }
    }
}
