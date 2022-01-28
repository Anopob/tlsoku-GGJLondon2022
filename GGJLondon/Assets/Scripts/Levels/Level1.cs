using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level1 : LevelManager
{
    public override void OnLeftClick(int x, int y)
    {
        _gameActions.Push(new GAStoreColor(x, y, _board1));
        _gameActions.Push(new GARightSwap(x, y, _board2));
    }

    public override void OnRightClick(int x, int y)
    {
        _gameActions.Push(new GAPaintStoredColor(x, y, _board1));
        _gameActions.Push(new GADownSwap(x, y, _board2));
    }
}
