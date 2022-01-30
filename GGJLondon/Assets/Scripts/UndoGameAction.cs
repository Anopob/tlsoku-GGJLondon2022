using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoGameAction : MonoBehaviour
{
    public LevelManager LevelManager { get; set; }

    private void CallUndo()
    {
        Debug.Log("Undo!");
        LevelManager?.OnUndoClick();
    }

    public void OnUndoButtonClick()
    {
        CallUndo();
    }

    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            CallUndo();
        }
    }
}
