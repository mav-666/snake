using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace GameController
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TweenAnimation transition;
        [SerializeField] private LevelIndexBorders levelIndexBorders;
        private CheckpointHandler _checkpointHandler;
        private bool _hasCheckpoints;

        public int FirstLevelIndex => levelIndexBorders.firstLevelIndex;
        public int LastLevelIndex => levelIndexBorders.lastLevelIndex;
        
        public int CompletedLevel { get; private set; }
        
        private const string CompletedLevelPref = "CompletedLevel";
        
        private void Awake()
        {
            _hasCheckpoints = TryGetComponent( out _checkpointHandler);
            transition.gameObject.SetActive(true);
            CompletedLevel = PlayerPrefs.GetInt(CompletedLevelPref, FirstLevelIndex-1);
        }

        private void Start()
        {
            if(_hasCheckpoints)
                _checkpointHandler.LoadCheckPoint();
        }

        public void RestartLevel()
        {
            transition.Animation.OnRewind(ReloadLevel).PlayBackwards();
        }

        private void ReloadLevel()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void NexLevel()
        {
            if (_hasCheckpoints)
            {
                _checkpointHandler.Reset();
                _checkpointHandler.enabled = false;
            }
           
        
            transition.Animation.OnRewind(LoadNextLevel).PlayBackwards();
        }

        private void LoadNextLevel()
        {
            DOTween.KillAll();
        
            var current = SceneManager.GetActiveScene().buildIndex;
            
            if(current > CompletedLevel)
                PlayerPrefs.SetInt(CompletedLevelPref, current);
            
            if (SceneManager.sceneCountInBuildSettings <= ++current)
                current = 0;
            
            SceneManager.LoadScene(current);
        }

        public void SetLevel(int index)
        {
            transition.Animation.OnRewind(() => LoadLevel(index)).PlayBackwards();
        }

        private void LoadLevel(int index)
        {
            DOTween.KillAll();
            
            if (SceneManager.sceneCountInBuildSettings <= index)
                index = 0;
            SceneManager.LoadScene(index);
        }
        
    }
}