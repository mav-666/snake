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
        transition.Animation.OnRewind(ReloadLevel).PlayBackwards();
    }

    private void ReloadLevel()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NexLevel()
    {
        transition.Animation.OnComplete(LoadNextLevel).PlayBackwards();
    }

    private void LoadNextLevel()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}