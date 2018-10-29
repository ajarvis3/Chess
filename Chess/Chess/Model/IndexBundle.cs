using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    /// <summary>
    /// Bundles a row and column together
    /// </summary>
    class IndexBundle
    {
        private int Row { get; set; }
        private int Column { get; set; }

        /// <summary>
        /// Constructor for Index Bundle
        /// </summary>
        /// <param name="row"> The row in the index </param>
        /// <param name="column"> The column in the index </param>
        public IndexBundle(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        /// <summary>
        /// Formats this object as a strign
        /// </summary>
        /// <returns> The string representation of this IndexBundle </returns>
        public override string ToString()
        {
            string ret = "(";
            ret = ret + Row;
            ret = ret + " , ";
            ret = ret + Column;
            ret = ret + ")";
            return ret;
        }
    }
}
