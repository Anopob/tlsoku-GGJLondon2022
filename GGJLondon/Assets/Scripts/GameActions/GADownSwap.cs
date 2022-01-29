using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GADownSwap : GameAction
{
    public GADownSwap(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override bool Redo()
    {
        _board.SwapTiles(_x, _y, _x + 1, _y );
        return true;
    }

    public override void Undo()
    {
        _board.SwapTiles(_x, _y, _x + 1, _y);
    }
}
