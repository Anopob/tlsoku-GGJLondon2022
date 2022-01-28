using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{
    protected Board _board1, _board2;
    protected Stack<GameAction> _gameActions;

    public void OnUndoClick()
    {
        _gameActions.Pop().Undo();
    }

    public void OnRedoClick()
    {
        // todo : redo (stretch goal)
    }

    public abstract void OnLeftClick(int x, int y);
    public abstract void OnRightClick(int x, int y);
}
