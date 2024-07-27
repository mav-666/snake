using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI
{
    public class EnableOnClick : MonoBehaviour
    {
        [SerializeField] private GameObject[] gameObjects;
        [SerializeField] private bool doDisable;
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(SetActiveObjects);
        }

        private void SetActiveObjects()
        {
            foreach (var o in gameObjects)
                o.SetActive(!doDisable);
        }
    }
}