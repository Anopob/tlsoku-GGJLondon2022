using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITile : Tile
{
    public int levelNumber  = 0;
    [SerializeField]
    private SceneCalculator _sceneCalculator;

    new public void MouseIn()
    {
        //SendMessageUpwards(nameof(LevelManager.TileHighlightOn), new Vector2Int(x, y));
    }

    new public void MouseOut()
    {
        //SendMessageUpwards(nameof(LevelManager.TileHighlightOff), new Vector2Int(x, y));
    }
    
    public void MouseClicked()
    {
        _sceneCalculator.GoToLevelNumber(levelNumber);
    }
 
    
    // Start is called before the first frame update
    void Start()
    {
        SetType(type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
