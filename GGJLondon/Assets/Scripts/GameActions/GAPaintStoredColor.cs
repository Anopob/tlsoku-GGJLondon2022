using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAPaintStoredColor : GameAction
{
    protected Color _oldColor;
    
    public GAPaintStoredColor(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override void Redo()
    {
        _oldColor = _board.GetTile(_x, _y).colour;
        _board.ColourTile(_x, _y, _board.storedColour);
    }

    public override void Undo()
    {
        _board.GetTile(_x, _y).SetColour(_oldColor);
    }
}
