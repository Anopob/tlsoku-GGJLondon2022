using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoGameAction : MonoBehaviour
{
    public LevelManager LevelManager { get; set; }

    private void CallUndo()
    {
        LevelManager?.OnUndoClick();
    }

    public void OnUndoButtonClick()
    {
        CallUndo();
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            CallUndo();
        }
    }
}
