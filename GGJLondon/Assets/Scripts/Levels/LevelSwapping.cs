using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelSwapping : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GADownSwap)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GARightSwap)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GARightSwap)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GADownSwap)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);

        
        int[,] puzzle1 = new int[,]{
                {0, 1, 2, 0},
                {3, 5, 5, 3},
                {3, 5, 5, 3},
                {0, 2, 1, 0},
            };

        int[,] puzzle2 = new int[,]{
                {0, 1, 3, 5},
                {3, 0, 5, 2},
                {1, 5, 0, 3},
                {5, 3, 2, 0},
            };
        
        _board1.CreateBoard(4,4, puzzle1);
        _board2.CreateBoard(4,4, puzzle2);
        
    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GADownSwap(x, y, _board1));
        _board2Actions.Push(new GARightSwap(x, y, _board2));
        PerformMove();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GARightSwap(x, y, _board1));
        _board2Actions.Push(new GADownSwap(x, y, _board2));
        PerformMove();
    }
}
