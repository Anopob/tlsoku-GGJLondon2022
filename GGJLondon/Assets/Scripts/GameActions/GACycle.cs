using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GACycle : GameAction
{
    private bool _forward;
    private int _size;

    public GACycle(int x, int y, Board board, bool forward, int size = Tile.NUMBER_OF_TILE_TYPES) : base(x, y, board)
    {
        _forward = forward;
        _size = size;
    }

    public override bool Redo()
    {
        _board.CycleTileType(_x, _y, _forward, _size);
        return true;
    }

    public override void Undo()
    {
        _board.CycleTileType(_x, _y, !_forward, _size);
    }
}
