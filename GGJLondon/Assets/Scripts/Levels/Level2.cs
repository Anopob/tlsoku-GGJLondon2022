using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Level2 : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAPaintStoredColor)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GABlank)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GADownSwap)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GAShiftLeft)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);
        
        _board1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        _board1.StoreType(1);
                
        int[,] puzzle1 = new int[,]{
                {3, 2, 3, 3},
                {2, 3, 3, 3},
                {3, 3, 3, 3},
                {3, 3, 2, 2},
            };

        int[,] puzzle2 = new int[,]{
                {1, 1, 1, 3},
                {1, 3, 3, 1},
                {3, 1, 1, 3},
                {2, 2, 2, 2},
            };
        
        _board1.CreateBoard(4,4, puzzle1);
        _board2.CreateBoard(4,4, puzzle2);
        
    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAPaintStoredColor(x, y, _board1));
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
