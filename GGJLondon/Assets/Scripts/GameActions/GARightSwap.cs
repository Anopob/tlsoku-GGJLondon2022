using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GARightSwap : GameAction
{
    public GARightSwap(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override void Redo()
    {
        _board.SwapTiles(_x, _y, _x, _y + 1);
    }

    public override void Undo()
    {
        _board.SwapTiles(_x, _y, _x, _y + 1);
    }
}
