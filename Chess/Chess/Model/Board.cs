using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    /// <summary>
    /// Represents a Generic 2D Board.
    /// </summary>
    /// <typeparam name="T"> The Type of pieces on the board </typeparam>
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

        /// <summary>
        /// Sets a specified board position to a given piece
        /// </summary>
        /// <param name="row"> the row to be changed </param>
        /// <param name="column"> the column to be changed </param>
        /// <param name="piece"> the object to take up the spot </param>
        public void SetBoardPos(int row, int column, T piece)
        {
            try
            {
                Matrix[row, column] = piece;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }
    }
}
