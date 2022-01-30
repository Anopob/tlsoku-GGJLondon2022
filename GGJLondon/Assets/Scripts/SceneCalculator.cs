using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCalculator : MonoBehaviour
{
    private const int LAST_LEVEL_INDEX = 9;

    [SerializeField]
    private AudioController _audioController;

    private Dictionary<int, Type> _levelNumberToScript = new Dictionary<int, Type>();
    private static SceneCalculator _instance;
    private int _level = -1;

    public bool HasBeatenGame { get; private set; } = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _levelNumberToScript.Add(1, typeof(Tutorial1));
        _levelNumberToScript.Add(2, typeof(Tutorial2));
        _levelNumberToScript.Add(3, typeof(Tutorial3));
        _levelNumberToScript.Add(4, typeof(Levelabc));
        // NEED LEVEL 5
        _levelNumberToScript.Add(6, typeof(LevelSliding));
        // NEED LEVEL 7
        _levelNumberToScript.Add(8, typeof(LevelWaterFire));
        _levelNumberToScript.Add(9, typeof(Level2)); //THIS LEVEL IS IMPOSSIBLE

        // NEED LEVEL 10
        _levelNumberToScript.Add(11, typeof(LevelPainting));
        _levelNumberToScript.Add(12, typeof(Level1));
        _audioController.PlayGameplayMusic();

    }

    public void StartNewGame()
    {
        GoToLevelNumber(1);
    }

    public void JustBeatLevel()
    {
        if (_level == LAST_LEVEL_INDEX)
            HasBeatenGame = true;
    }

    public Type GetLevelScript()
    {
        return _levelNumberToScript[_level];
    }

    public void GoToNextLevel()
    {
        GoToLevelNumber(_level + 1);
    }

    public void GoToLevelNumber(int index)
    {
        _level = index;
        ClickAsync("GameScene");
        _audioController.PlayGameplayMusic();
    }

    public void GoToLevelSelect()
    {
        ClickAsync("LevelSelect");
    }

    public void GoToMainMenu()
    {
        ClickAsync("MainMenu");
    }

    public Slider LoadingBar;
    public GameObject LoadingImage;

    private AsyncOperation _async;

    private void ClickAsync(string name)
    {
        LoadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar(name));
    }

    private IEnumerator LoadLevelWithBar(string name)
    {
        _async = SceneManager.LoadSceneAsync(name);
        while (!_async.isDone)
        {
            LoadingBar.value = _async.progress;
            yield return null;
        }
        LoadingImage.SetActive(false);
    }
}