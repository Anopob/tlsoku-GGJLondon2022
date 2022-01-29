using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Level2 : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAPaintColor)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GABlank)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GADownSwap)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GAShiftLeft)];
/*
    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);
        
        Color[,] puzzle1 = new Color[,]{
                {Color.blue, Color.red, Color.blue, Color.blue},
                {Color.red, Color.blue, Color.blue, Color.blue},
                {Color.blue, Color.blue, Color.blue, Color.blue},
                {Color.blue, Color.blue, Color.red, Color.red},
            };

        Color[,] puzzle2 = new Color[,]{
                {Color.blue, Color.blue, Color.green, Color.blue},
                {Color.green, Color.blue, Color.blue, Color.green},
                {Color.blue, Color.green, Color.green, Color.blue},
                {Color.red, Color.red, Color.red, Color.red},
            };
        
        _board1.CreateBoard(4,4, puzzle1);
        _board2.CreateBoard(4,4, puzzle2);
        
    }
*/

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);
        
        int[,] puzzle1 = new int[,]{
                {0,0,1,0},
                {0,0,1,0},
                {0,0,1,0},
                {0,0,1,0},
            };

        int[,] puzzle2 = new int[,]{
                {0,0,1,0},
                {3,0,1,0},
                {0,2,1,0},
                {0,0,1,3},
            };
        
        _board1.CreateBoard(4,4, puzzle1);
        _board2.CreateBoard(4,4, puzzle2);
        
    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAPaintColor(x, y, _board1, Color.green));
        _board2Actions.Push(new GADownSwap(x, y, _board2));
        PerformMove();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GABlank(x, y, _board1));
        _board2Actions.Push(new GAShiftLeft(x, y, _board2));
        PerformMove();
    }
}
