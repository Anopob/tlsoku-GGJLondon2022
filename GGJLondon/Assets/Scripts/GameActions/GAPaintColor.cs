using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAPaintColor : GameAction
{
    protected Color _oldColor;
    protected Color _paintColor;
    
    public GAPaintColor(int x, int y, Board board, Color colour) : base(x, y, board)
    {
        _paintColor = colour;
    }

    public override bool Redo()
    {
        
        _oldColor = _board.GetTile(_x, _y).colour;
        _board.ColourTile(_x, _y, _paintColor);
        return (_oldColor != _paintColor);
    }

    public override void Undo()
    {
        _board.GetTile(_x, _y).SetColour(_oldColor);
    }
}
