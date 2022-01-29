using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class LevelInitializer : MonoBehaviour
    {
        private SceneCalculator _sceneCalculator;
        [SerializeField]
        private Board _boardPrefab;

        private void Awake()
        {
            _sceneCalculator = FindObjectOfType<SceneCalculator>();
        }

        private void Start()
        {
            LevelManager manager = (LevelManager)gameObject.AddComponent(_sceneCalculator.GetLevelScript());
            manager.SetupBoards(_boardPrefab);
        }
    }
}
