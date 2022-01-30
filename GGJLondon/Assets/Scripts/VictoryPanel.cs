using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    public SceneCalculator SceneCalculator { get; set; }

    public void NextLevel()
    {
        SceneCalculator.GoToNextLevel();
    }

    public void LevelSelect()
    {
        SceneCalculator.GoToLevelSelect();
    }

    public void MainMenu()
    {
        SceneCalculator.GoToMainMenu();
    }

    public void VictoryIsAchieved()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        // todo : button hotkeys
    }
}
