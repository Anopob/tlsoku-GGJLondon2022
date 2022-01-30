using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelSpaceTime : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAShiftUp)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GAShiftUp)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GADownSwap)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GAShiftLeft)];

    public override void SetupBoards(Board boardPrefab)
    {
                
        base.SetupBoards(boardPrefab);
        
        int[,] puzzle1 = new int[,]{
                {5, 5, 5, 5},
                {5, 2, 2, 5},
                {4, 4, 4, 4},
                {4, 4, 4, 4},
            };

        int[,] puzzle2 = new int[,]{
                {4, 5, 4, 2},
                {5, 4, 5, 4},
                {4, 5, 4, 5},
                {2, 4, 5, 4},
            };
        
        _board1.CreateBoard(4,4, puzzle1);
        _board2.CreateBoard(4,4, puzzle2);
        
    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAShiftUp(x, y, _board1));
        _board2Actions.Push(new GADownSwap(x, y, _board2));
        PerformMove();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GAShiftUp(x, y, _board1));
        _board2Actions.Push(new GAShiftLeft(x, y, _board2));
        PerformMove();
    }
}
