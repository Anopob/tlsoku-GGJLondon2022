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
 
    public void MenuMouseClicked()
    {
        Debug.Log(levelNumber);
        if(levelNumber == 1)
            _sceneCalculator.StartNewGame();
        if(levelNumber == 2)
            _sceneCalculator.GoToLevelSelect();
        if(levelNumber == 3)
            _sceneCalculator.StartNewGame();
        if(levelNumber == 4)
            _sceneCalculator.StartNewGame();
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
