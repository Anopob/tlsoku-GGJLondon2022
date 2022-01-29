using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Tutorial : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAShiftLeft)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GABlank)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GABlank)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GAShiftUp)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);

        Color[,] puzzle1 = new Color[,]{
                {Color.red, Color.red, Color.blue},
                {Color.red, Color.red, Color.blue},
                {Color.blue, Color.red, Color.blue},
            };

        Color[,] puzzle2 = new Color[,]{
                {Color.red, Color.red, Color.blue},
                {Color.red, Color.red, Color.red},
                {Color.blue, Color.blue, Color.blue},
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
        _board2Actions.Push(new GAShiftUp(x, y, _board2));
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
