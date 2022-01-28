using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level1 : LevelManager
{
    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAStoreColor(x, y, _board1));
        _board1Actions.Peek().Redo();
        _board2Actions.Push(new GARightSwap(x, y, _board2));
        _board2Actions.Peek().Redo();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GAPaintStoredColor(x, y, _board1));
        _board1Actions.Peek().Redo();
        _board2Actions.Push(new GADownSwap(x, y, _board2));
        _board2Actions.Peek().Redo();
    }
}
