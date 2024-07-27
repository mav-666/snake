using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameController.UI
{
    public class LevelContent : MonoBehaviour
    {
        [Serializable]
        private class Level
        {
            [SerializeField] private string sceneName;
            [SerializeField] private Sprite preview;

            public string SceneName => sceneName;
            public Sprite Preview => preview;
        }
        
        [SerializeField] private GameManager gameManager;
        [SerializeField] private LevelItem prefab;
        [SerializeField] private Level[] levels;

        private void Awake()
        {

            
            
            var completedLevel = gameManager.CompletedLevel;

            for (var i = gameManager.FirstLevelIndex; i < Math.Min(gameManager.LastLevelIndex, SceneManager.sceneCountInBuildSettings - 1); i++)
            {
                var sceneName = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                CreateLevel(levels.First(level => level.SceneName == sceneName).Preview, i, i <= completedLevel + 1);
            }
        }

        private void CreateLevel(Sprite preview, int levelIndex, bool isOpened)
        {
            var levelItem = Instantiate(prefab, transform, false);
            levelItem.Init(gameManager, preview, levelIndex, isOpened);
        }
    }
}