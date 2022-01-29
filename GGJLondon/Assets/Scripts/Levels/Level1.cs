using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Level1 : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAStoreColor)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GAPaintStoredColor)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GARightSwap)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GADownSwap)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);
        // enable "storage image" child
        _board1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        
        Color[,] puzzle1 = new Color[,]{
                {Color.blue, Color.red, Color.green, Color.magenta},
                {Color.blue, Color.magenta, Color.red, Color.green},
                {Color.blue, Color.green, Color.red, Color.magenta},
                {Color.blue, Color.red, Color.green, Color.magenta},
            };

        Color[,] puzzle2 = new Color[,]{
                {Color.green, Color.red, Color.green, Color.magenta},
                {Color.blue, Color.magenta, Color.blue, Color.green},
                {Color.blue, Color.green, Color.magenta, Color.magenta},
                {Color.red, Color.red, Color.green, Color.magenta},
            };
        
        _board1.CreateBoard(4,4, puzzle1);
        _board2.CreateBoard(4,4, puzzle2);
        
    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAStoreColor(x, y, _board1));
        bool board1Result = _board1Actions.Peek().Redo();
        _board2Actions.Push(new GARightSwap(x, y, _board2));
        bool board2Result = _board2Actions.Peek().Redo();
        if (!(board1Result && board2Result))
            UndoInvalidAction();
        else
        {
            _audioController.PlayValidMoveClip();
            CheckEndOfGame();
        }
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GAPaintStoredColor(x, y, _board1));
        bool board1Result = _board1Actions.Peek().Redo();
        _board2Actions.Push(new GADownSwap(x, y, _board2));
        bool board2Result = _board2Actions.Peek().Redo();
        if (!(board1Result && board2Result))
            UndoInvalidAction();
        else
        {
            _audioController.PlayValidMoveClip();
            CheckEndOfGame();
        }
    }
}
