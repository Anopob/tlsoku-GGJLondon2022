using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GAStoreColor : GameAction
{
    public GAStoreColor(int x, int y, Board board) : base(x, y, board)
    {
    }

    public override void Redo()
    {
        // store color
    }

    public override void Undo()
    {
        // unstore color
    }
}
