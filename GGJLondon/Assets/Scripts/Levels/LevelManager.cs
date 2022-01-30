using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{
    [SerializeField] protected Board _board1, _board2;
    protected Stack<GameAction> _board1Actions = new Stack<GameAction>();
    protected Stack<GameAction> _board2Actions = new Stack<GameAction>();

    protected AudioController _audioController;

    public abstract string LeftBoardLeftClickInstructions { get; }
    public abstract string LeftBoardRightClickInstructions { get; }
    public abstract string RightBoardLeftClickIntructions { get; }
    public abstract string RightBoardRightClickIntructions { get; }

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

    private bool IsPlayerVictorious()
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

    protected void PerformMove()
    {
        bool board1Result = _board1Actions.Peek().Redo();
        bool board2Result = _board2Actions.Peek().Redo();
        if (!(board1Result && board2Result))
            UndoInvalidAction();
        else
        {
            _audioController.PlayValidMoveClip();
            CheckEndOfGame();
        }
    }

    public abstract void OnLeftClick(int x, int y);
    public abstract void OnRightClick(int x, int y);
    
    // EVENTS
    public void TileLeftClick(Vector2Int data)
    {
        OnLeftClick(data[0], data[1]);   
    }
    
    public void TileRightClick(Vector2Int data)
    {
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

    protected Dictionary<Type, string> _GAToInstructions = new Dictionary<Type, string>();
    private void Awake()
    {
        _GAToInstructions[typeof(GABlank)] = "N/A";

        _GAToInstructions[typeof(GARightSwap)] = "Swap the selected tile with the tile to the right of it.";
        _GAToInstructions[typeof(GADownSwap)] = "Swap the selected tile with the tile below it.";

        _GAToInstructions[typeof(GAShiftLeft)] = "Shift the selected row to the left.";
        _GAToInstructions[typeof(GAShiftUp)] = "Shift the selected column upwards.";

        _GAToInstructions[typeof(GAStoreColor)] = "Store the selected tile's color.";
        _GAToInstructions[typeof(GAPaintStoredColor)] = "Paint the stored color onto the selected tile.";

        _GAToInstructions[typeof(GAPaintColor)] = "Paint the selected tile a specific color.";

        _GAToInstructions[typeof(GACycle)] = "Cycle the selected tile's type.";
    }

    void Start()
    {
        _audioController = FindObjectOfType<AudioController>();
    }

    public virtual void SetupBoards(Board boardPrefab)
    {
        _board1 = Instantiate(boardPrefab, transform);

        _board2 = Instantiate(boardPrefab, transform);
        _board2.transform.position = transform.position + new Vector3(150, 184, 0);
    }
}
