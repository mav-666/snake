using UnityEngine;
using UnityEngine.InputSystem;

namespace GameController.UI
{
    public class SetLevelOnKey : MonoBehaviour
    {
        [SerializeField] private InputActionReference actionReference;
        [SerializeField] private int index;
        [SerializeField] private GameManager gameManager;
        
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
            gameManager.SetLevel(index);
        }
    }
}