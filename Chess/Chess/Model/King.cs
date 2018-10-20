﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Model
{
    class King : Royal
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public King() : base()
        {
            Name = "King";
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="row"> int representing start value for row </param>
        /// <param name="column"> int representing start value for column </param>
        public King(int row, int column) : this()
        {
            Row = row;
            Column = column;
        }
    }
}