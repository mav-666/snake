using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TweenAnimation transition;
    
    public void RestartLevel()
    {
        transition.Animation.OnRewind(ReloadLevel).PlayBackwards();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NexLevel()
    {
        transition.Animation.OnComplete(LoadNextLevel).PlayBackwards();
       
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}