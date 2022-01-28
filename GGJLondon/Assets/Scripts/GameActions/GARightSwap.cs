﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class GARightSwap : GameAction
    {
        public GARightSwap(int x, int y, Board board) : base (x, y, board)
        {
        }

        public override void Redo()
        {
            Board.SwapTiles(_x, _y, _x+1, _y);
        }

        public override void Undo()
        {
            Board.SwapTiles(_x, _y, _x+1, _y);
        }
    }
}
