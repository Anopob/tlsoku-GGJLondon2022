using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Tutorial1 : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAShiftLeft)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GAShiftUp)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GABlank)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GABlank)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);

        int[,] puzzle1 = new int[,]{
                {2, 3, 4},
                {1, 5, 1},
                {4, 3, 2},
            };

        int[,] puzzle2 = new int[,]{
                {1, 2, 3},
                {4, 5, 4},
                {3, 2, 1},
            };

        _board1.CreateBoard(3, 3, puzzle1);
        _board2.CreateBoard(3, 3, puzzle2);

    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAShiftLeft(x, y, _board1));
        _board2Actions.Push(new GABlank(x, y, _board2));
        PerformMove();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GAShiftUp(x, y, _board1));
        _board2Actions.Push(new GABlank(x, y, _board2));
        PerformMove();
    }
}
