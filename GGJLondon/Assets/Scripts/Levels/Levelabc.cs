using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Levelabc : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GABlank)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GAShiftUp)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GABlank)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GACycle)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);
        
        int[,] puzzle1 = new int[,]{
                {0, 0, 1, 0},
                {0, 1, 0, 0},
                {1, 0, 0, 0},
                {0, 0, 0, 1},
            };

        int[,] puzzle2 = new int[,]{
                {0, 0, 0, 1},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
            };
        
        _board1.CreateBoard(4,4, puzzle1);
        _board2.CreateBoard(4,4, puzzle2);
        
    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GABlank(x, y, _board1));
        _board2Actions.Push(new GABlank(x, y, _board2));
        PerformMove();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GAShiftUp(x, y, _board1));
        _board2Actions.Push(new GACycle(x, y, _board2, true, 2));
        PerformMove();
    }
}
