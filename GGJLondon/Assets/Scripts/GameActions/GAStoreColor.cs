using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAStoreColor : GameAction
{
    protected Color _oldColor;
    public GAStoreColor(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override void Redo()
    {
        _oldColor = _board.StoreColour(_board.GetTile(_x, _y).colour);
    }

    public override void Undo()
    {
        // unstore color
    }
}
