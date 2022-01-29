using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{
    [SerializeField] protected Board _board1, _board2;
    protected Stack<GameAction> _board1Actions = new Stack<GameAction>();
    protected Stack<GameAction> _board2Actions = new Stack<GameAction>();

    protected AudioController _audioController;

    protected void UndoInvalidAction()
    {
        PerformUndo();
        _audioController.PlayInvalidMoveClip();
    }

    private void PerformUndo()
    {
        if (_board1Actions.Count ==  0) return;
        _board1Actions.Pop().Undo();
        _board2Actions.Pop().Undo();
    }

    public void OnUndoClick()
    {
        PerformUndo();
    }

    public void OnRedoClick()
    {
        // todo : redo (stretch goal)
    }

    public bool IsPlayerVictorious()
    {
        for (int i = 0; i < _board1.tiles.GetLength(0); i++)
        {
            for (int j = 0; j < _board1.tiles.GetLength(1); j++)
            {
                if (_board1.tiles[i, j].colour != _board2.tiles[i, j].colour)
                    return false;
            }
        }
        return true;
    }

    public void CheckEndOfGame()
    {
        if (IsPlayerVictorious())
        {
            Debug.Log("Victory!");
        }
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

    public void TileHighlightOn(Vector2Int data)
    {
        _board1.SetHighlight(data[0], data[1], true);
        _board2.SetHighlight(data[0], data[1], true);
    }

    public void TileHighlightOff(Vector2Int data)
    {
        _board1.SetHighlight(data[0], data[1], false);
        _board2.SetHighlight(data[0], data[1], false);
    }
    
    public void InvalidMove()
    {
        PerformUndo();
    }
    
    void Start()
    {
        _audioController = FindObjectOfType<AudioController>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            PerformUndo();
        }
    }
}
