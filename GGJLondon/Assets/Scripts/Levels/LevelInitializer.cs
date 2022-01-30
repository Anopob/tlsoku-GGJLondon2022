using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class LevelInitializer : MonoBehaviour
    {
        private SceneCalculator _sceneCalculator;
        private UndoGameAction _undo;
        [SerializeField]
        private VictoryPanel _victoryPanel;
        [SerializeField]
        private Board _boardPrefab;

        private TextMeshProUGUI[] _instructions = new TextMeshProUGUI[4];

        private void Awake()
        {
            _sceneCalculator = FindObjectOfType<SceneCalculator>();
            _instructions = GetComponentsInChildren<TextMeshProUGUI>();
            _victoryPanel.SceneCalculator = _sceneCalculator;
        }

        private void Start()
        {
            LevelManager manager = (LevelManager)gameObject.AddComponent(_sceneCalculator.GetLevelScript());
            manager.SetupBoards(_boardPrefab);
            manager.VictoryPanel = _victoryPanel;

            _instructions[0].text += manager.LeftBoardLeftClickInstructions;
            _instructions[1].text += manager.LeftBoardRightClickInstructions;
            _instructions[2].text += manager.RightBoardLeftClickIntructions;
            _instructions[3].text += manager.RightBoardRightClickIntructions;

            _undo = GetComponentInChildren<UndoGameAction>();
            _undo.LevelManager = manager;
        }
    }
}
