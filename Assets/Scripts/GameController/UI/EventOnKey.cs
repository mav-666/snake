using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace GameController.UI
{
    public class EventOnKey : MonoBehaviour
    {
        [SerializeField] private InputActionReference actionReference;
        [SerializeField] private UnityEvent action;

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
            action.Invoke();
        }
    }
}