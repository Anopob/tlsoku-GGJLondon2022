using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAShiftUp : GameAction
{
    public GAShiftUp(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override bool Redo()
    {
        _board.ShiftColumnUp(_y);
        return true;
    }

    public override void Undo()
    {
        _board.ShiftColumnDown(_y);
    }
}
