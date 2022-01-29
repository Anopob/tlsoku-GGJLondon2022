using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelWaterFire : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAPaintColor)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GADownSwap)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GAPaintColor)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GARightSwap)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);
        
        int[,] puzzle1 = new int[,]{
                {3, 2, 2, 2},
                {2, 2, 2, 3},
                {2, 3, 3, 2},
                {2, 2, 2, 2},
            };

        int[,] puzzle2 = new int[,]{
                {3, 2, 3, 2},
                {3, 2, 2, 3},
                {3, 2, 2, 3},
                {2, 3, 2, 3},
            };
        
        _board1.CreateBoard(4,4, puzzle1);
        _board2.CreateBoard(4,4, puzzle2);
        
    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAPaintColor(x, y, _board1, 3));
        _board2Actions.Push(new GAPaintColor(x, y, _board2, 2));
        PerformMove();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GADownSwap(x, y, _board1));
        _board2Actions.Push(new GARightSwap(x, y, _board2));
        PerformMove();
    }
}
