using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAPaintStoredColor : GameAction
{
    protected int _oldColor;
    
    public GAPaintStoredColor(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override bool Redo()
    {
        
        _oldColor = _board.GetTile(_x, _y).type;
        _board.SetTileType(_x, _y, _board.storedType);
        return (_oldColor != _board.storedType);
    }

    public override void Undo()
    {
        _board.SetTileType(_x, _y, _oldColor);
    }
}
