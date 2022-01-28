using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class GADownSwap : GameAction
    {
        public GADownSwap(int x, int y, Board board) : base (x, y, board)
        {
        }

        public override void Redo()
        {
            _board.SwapTiles(_x, _y, _x, _y+1);
        }

        public override void Undo()
        {
            _board.SwapTiles(_x, _y, _x, _y+1);
        }
    }
}
