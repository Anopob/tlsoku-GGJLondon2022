using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Tutorial : LevelManager
{
    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);

        Color[,] puzzle1 = new Color[,]{
                {Color.red, Color.green, Color.blue},
                {Color.green, Color.red, Color.blue},
                {Color.blue, Color.red, Color.green},
            };

        Color[,] puzzle2 = new Color[,]{
                {Color.green, Color.red, Color.blue},
                {Color.red, Color.blue, Color.green},
                {Color.blue, Color.green, Color.red},
            };

        _board1.CreateBoard(3, 3, puzzle1);
        _board2.CreateBoard(3, 3, puzzle2);

    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAShiftLeft(x, y, _board1));
        bool board1Result = _board1Actions.Peek().Redo();
        _board2Actions.Push(new GABlank(x, y, _board2));
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
        _board1Actions.Push(new GABlank(x, y, _board1));
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
}
