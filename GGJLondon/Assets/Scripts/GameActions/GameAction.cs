using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction
{
    protected int _x, _y;
    protected Board _board;

    public abstract bool Redo();
    public abstract void Undo();

    public GameAction(int x, int y, Board board)
    {
        _x = x;
        _y = y;
        _board = board;
    }
}
