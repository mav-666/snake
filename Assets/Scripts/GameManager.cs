using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TweenAnimation transition;

    private void Awake()
    {
        transition.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        DOTween.KillAll();
        transition.Animation.OnRewind(ReloadLevel).PlayBackwards();
    }

    private void ReloadLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NexLevel()
    {
        DOTween.KillAll();
        transition.Animation.OnComplete(LoadNextLevel).PlayBackwards();
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}