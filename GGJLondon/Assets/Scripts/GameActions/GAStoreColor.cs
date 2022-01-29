using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAStoreColor : GameAction
{
    protected Color _oldColor = Color.black;
    public GAStoreColor(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override bool Redo()
    {
        Color storageColour  = _board.GetTile(_x, _y).colour;
        _oldColor = _board.StoreColour(storageColour);
        return (_oldColor != storageColour);
    }

    public override void Undo()
    {
        if (_oldColor != Color.black)
            _board.StoreColour(_oldColor);
    }
}
