using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GameController.UI
{
    public class SelectOnKey : MonoBehaviour
    {
        [SerializeField] private InputActionReference actionReference;
        [SerializeField] private Selectable selectable;
        private void OnEnable()
        {
            actionReference.action.performed += Select;
            actionReference.action.Enable();
        }

        private void OnDisable()
        {
            actionReference.action.performed -= Select;
            actionReference.action.Disable();
        }
        
        private void Select(InputAction.CallbackContext ctx)
        {
            selectable.Select();
        }
    }
}