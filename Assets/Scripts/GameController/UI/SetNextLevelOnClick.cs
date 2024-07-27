using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI
{
    public class SetNextLevelOnClick : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(NextLevel);
        }

        private void NextLevel()
        {
            gameManager.SetLevel(gameManager.CompletedLevel + 1);
        }
    }
}