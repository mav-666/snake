using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameController
{
    public class QuitOnClick : MonoBehaviour
    {
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Quit);
        }

        private void Quit()
        {
            Application.Quit();
        }
    }
}