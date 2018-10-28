﻿using System;
using System.Collections.Generic;
using System.Text;
using Chess.Controller;

namespace Chess.Model
{
    /// <summary>
    /// Class representing a Pawn in chess.
    /// Only currently accounts for single move forward and diagonal capture.
    /// </summary>
    class Pawn : Piece
    {

        /// <summary>
        /// Default Constructor for Pawn
        /// </summary>
        public Pawn() : base()
        {
            Name = "Pawn";
            Movement forward = new Movement(1, 0, 1);
            forward.addConstraint(PawnUnoccupiedConstraint.GetConstraint());
            Movement diag1 = new Movement(1, 1, 1);
            Movement diag2 = new Movement(1, -1, 1);
            diag1.addConstraint(PawnEnemyDiagonalConstraint.GetConstraint());
            diag2.addConstraint(PawnEnemyDiagonalConstraint.GetConstraint());
            List<Movement> moves = new List<Movement>();
            moves.Add(forward);
            moves.Add(diag1);
            moves.Add(diag2);
            PossibleMovements = moves;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="row"> the int representing the start row </param>
        /// <param name="column"> the int representing the start column </param>
        /// <param name="owner"> the string representing the owner </param>
        public Pawn(int row, int column, string owner) : this()
        {

        }
    }
}