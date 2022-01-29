using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAStoreColor : GameAction
{
    protected int _oldColor = 5;
    public GAStoreColor(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override bool Redo()
    {
        int storageColour  = _board.GetTile(_x, _y).type;
        _oldColor = _board.StoreType(storageColour);
        return (_oldColor != storageColour);
    }

    public override void Undo()
    {
        if (_oldColor != 5)
            _board.StoreType(_oldColor);
    }
}
