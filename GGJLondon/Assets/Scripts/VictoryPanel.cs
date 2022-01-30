using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    public SceneCalculator SceneCalculator { get; set; }
    private AudioController _audioController;

    public void NextLevel()
    {
        SceneCalculator.GoToNextLevel();
        _audioController.PlayButtonClickClip();
    }

    public void LevelSelect()
    {
        SceneCalculator.GoToLevelSelect();
        _audioController.PlayButtonClickClip();
    }

    public void MainMenu()
    {
        SceneCalculator.GoToMainMenu();
        _audioController.PlayButtonClickClip();
    }

    public void VictoryIsAchieved()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        _audioController = FindObjectOfType<AudioController>();
    }

    private void Update()
    {
        // todo : button hotkeys
    }
}
