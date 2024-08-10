using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace GameController.UI
{
    public class ActionOnKeyVector : MonoBehaviour
    {
        [SerializeField] private InputActionReference actionReference;
        [Space]
        [SerializeField] private UnityEvent actionLeft;
        [SerializeField] private UnityEvent actionRight;
        [SerializeField] private UnityEvent actionUp;
        [SerializeField] private UnityEvent actionDown;

        private InputAction _action;

        private void Awake()
        {
            _action = actionReference.ToInputAction();
        }

        private void OnEnable()
        {
            _action.performed += Animation;
            _action.Enable();
        }

        private void OnDisable()
        {
            _action.performed -= Animation;
            _action.Disable();
        }

        private void Animation(InputAction.CallbackContext ctx)
        {
            var vector = actionReference.ToInputAction().ReadValue<Vector2>();

            if(vector.x > 0)
                actionRight.Invoke();
            if(vector.x < 0)
                actionLeft.Invoke();
            if(vector.y > 0)
                actionUp.Invoke();
            if(vector.y < 0)
                actionDown.Invoke();
        }
    }
}