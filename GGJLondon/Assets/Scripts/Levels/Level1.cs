﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Level1 : LevelManager
{
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
