using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelQuiteEasy : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAStoreColor)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GAShiftLeft)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GACycle)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GABlank)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);

        _board1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        _board1.StoreType(0);

        int[,] puzzle1 = new int[,]{
                {1, 2, 2, 5},
                {2, 0, 3, 4},
                {0, 3, 1, 2},
                {5, 3, 5, 5},
            };

        int[,] puzzle2 = new int[,]{
                {1, 5, 2, 2},
                {2, 1, 4, 3},
                {0, 3, 0, 2},
                {2, 3, 5, 5},
            };

        _board1.CreateBoard(4, 4, puzzle1);
        _board2.CreateBoard(4, 4, puzzle2);

    }

    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAStoreColor(x, y, _board1));
        _board2Actions.Push(new GACycle(x, y, _board2, false));
        PerformMove();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GAShiftLeft(x, y, _board1));
        _board2Actions.Push(new GABlank(x, y, _board2));
        PerformMove();
    }
}
