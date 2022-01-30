using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITile : Tile
{
    public int levelNumber  = 0;
    private SceneCalculator _sceneCalculator;
    private AudioController _audioController;

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
        _sceneCalculator.GoToLevelNumber(levelNumber - 1);
        _audioController.PlayButtonClickClip();
    }
 
    public void MenuMouseClicked()
    {
        if(levelNumber == 0)
            _sceneCalculator.GoToMainMenu();
        if(levelNumber == 1)
            _sceneCalculator.StartNewGame();
        if(levelNumber == 2)
            _sceneCalculator.GoToLevelSelect();
        if(levelNumber == 3)
            _sceneCalculator.StartNewGame();
        if(levelNumber == 4)
            _sceneCalculator.StartNewGame();

        _audioController.PlayButtonClickClip();
    }
    
    void Start()
    {
        _sceneCalculator = FindObjectOfType<SceneCalculator>();
        _audioController = FindObjectOfType<AudioController>();
    }
}
