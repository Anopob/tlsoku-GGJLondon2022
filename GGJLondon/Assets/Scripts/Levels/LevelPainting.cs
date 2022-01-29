using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelPainting : LevelManager
{
    public override string LeftBoardLeftClickInstructions => _GAToInstructions[typeof(GAStoreColor)];

    public override string LeftBoardRightClickInstructions => _GAToInstructions[typeof(GAPaintStoredColor)];

    public override string RightBoardLeftClickIntructions => _GAToInstructions[typeof(GAPaintStoredColor)];

    public override string RightBoardRightClickIntructions => _GAToInstructions[typeof(GAStoreColor)];

    public override void SetupBoards(Board boardPrefab)
    {
        base.SetupBoards(boardPrefab);
        
        // enable "storage image" child
        _board1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        _board2.gameObject.transform.GetChild(0).gameObject.SetActive(true);


        int[,] puzzle1 = new int[,]{
                {1, 1, 4},
                {2, 2, 1},
                {3, 1, 2},
            };

        int[,] puzzle2 = new int[,]{
                {3, 4, 3},
                {1, 1, 1},
                {3, 1, 3},
            };

        _board1.CreateBoard(3, 3, puzzle1);
        _board2.CreateBoard(3, 3, puzzle2);

    }


    public override void OnLeftClick(int x, int y)
    {
        _board1Actions.Push(new GAStoreColor(x, y, _board1));
        _board2Actions.Push(new GAPaintStoredColor(x, y, _board2));
        PerformMove();
    }

    public override void OnRightClick(int x, int y)
    {
        _board1Actions.Push(new GAPaintStoredColor(x, y, _board1));
        _board2Actions.Push(new GAStoreColor(x, y, _board2));
        PerformMove();
    }
}
