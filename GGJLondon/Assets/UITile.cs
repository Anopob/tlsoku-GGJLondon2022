using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITile : Tile
{
    public int levelNumber  = 0;
    private SceneCalculator _sceneCalculator;

    new public void MouseIn()
    {
        SetHighlight(true);
    }

    new public void MouseOut()
    {
        SetHighlight(false);
    }
    
    public void MouseClicked()
    {
        _sceneCalculator.GoToLevelNumber(levelNumber);
    }
 
    
    // Start is called before the first frame update
    void Start()
    {
        _sceneCalculator = FindObjectOfType<SceneCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
