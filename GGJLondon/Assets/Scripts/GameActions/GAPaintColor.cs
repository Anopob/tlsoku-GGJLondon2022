using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAPaintColor : GameAction
{
    protected int _oldColor;
    protected int _paintColor;
    
    public GAPaintColor(int x, int y, Board board, int colour) : base(x, y, board)
    {
        _paintColor = colour;
    }

    public override bool Redo()
    {
        
        _oldColor = _board.GetTile(_x, _y).type;
        _board.SetTileType(_x, _y, _paintColor);
        return (_oldColor != _paintColor);
    }

    public override void Undo()
    {
        _board.SetTileType(_x, _y, _oldColor);
    }
}
