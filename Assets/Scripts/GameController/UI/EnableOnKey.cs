using UnityEngine;
using UnityEngine.InputSystem;

namespace GameController.UI
{
    public class EnableOnKey : MonoBehaviour
    {
        [SerializeField] private InputActionReference actionReference;
        [SerializeField] private GameObject[] gameObjects;
        [SerializeField] private bool doDisable;
        
        private void OnEnable()
        {
            actionReference.action.performed += NextInput;
            actionReference.action.Enable();
        }

        private void OnDisable()
        {
            actionReference.action.performed -= NextInput;
            actionReference.action.Disable();
        }
        
        private void NextInput(InputAction.CallbackContext ctx)
        {
            foreach (var o in gameObjects) 
                o.SetActive(!doDisable);
        }
    }
}