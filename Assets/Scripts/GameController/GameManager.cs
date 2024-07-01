using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameController
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TweenAnimation transition;
    
        private CheckpointHandler _checkpointHandler;

        private bool _hasCheckpoints;
    
        private void Awake()
        {
            _hasCheckpoints = TryGetComponent( out _checkpointHandler);
            transition.gameObject.SetActive(true);
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
            Debug.Log($"Switched to the next scene {current}");
            if (SceneManager.sceneCountInBuildSettings <= ++current)
                current = 0;
            SceneManager.LoadScene(current);
        }
    }
}