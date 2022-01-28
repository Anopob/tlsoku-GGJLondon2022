using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{
    [SerializeField] protected Board _board1, _board2;
    protected Stack<GameAction> _board1Actions = new Stack<GameAction>();
    protected Stack<GameAction> _board2Actions = new Stack<GameAction>();

    public void OnUndoClick()
    {
        _board1Actions.Pop().Undo();
        _board2Actions.Pop().Undo();
    }

    public void OnRedoClick()
    {
        // todo : redo (stretch goal)
    }

    public abstract void OnLeftClick(int x, int y);
    public abstract void OnRightClick(int x, int y);
    
    // EVENTS
    public void TileLeftClick(Vector2Int data)
    {
        Debug.Log("Manager sees left click");
        OnLeftClick(data[0], data[1]);   
    }
    
    public void TileRightClick(Vector2Int data)
    {
        Debug.Log("Manager sees right click");
        OnRightClick(data[0], data[1]);
    }
}
