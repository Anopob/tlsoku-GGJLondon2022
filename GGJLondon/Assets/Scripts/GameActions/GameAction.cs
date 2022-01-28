using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction
{
    private int _x, _y;
    private Board _board;

    public abstract void Redo();
    public abstract void Undo();

    public GameAction(int x, int y, Board board)
    {
        _x = x;
        _y = y;
        _board = board;
    }
}