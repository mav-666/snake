using Electricity.Couplers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Snake
{
    public class SnakeInput : MonoBehaviour
    {
        [SerializeField] private InputActionAsset actions;

        private IMobility _mobility;
        private FindingCoupler _snakeConnection;
        
        private InputAction _move;
        private InputAction _connect;
        private InputAction _disconnect;
        private InputActionMap _playerMap;
        
        private void Awake()
        {
            _playerMap = actions.FindActionMap("Player");

            _move = _playerMap.FindAction("Move");
            
            _connect = _playerMap.FindAction("Connect");
            _disconnect = _playerMap.FindAction("Disconnect");
  
            _connect.performed += Connect;
            _disconnect.performed += Disconnect;
        }
        
        private void Connect(InputAction.CallbackContext _)
        {
            _snakeConnection.FindUnconnected();
        }
        
        private void Disconnect(InputAction.CallbackContext _)
        {
            _snakeConnection.BreakConnected();
        }

        private void Start()
        {
            _mobility = GetComponent<IMobility>();
            _snakeConnection = GetComponent<FindingCoupler>();
        }

        private void Update()
        {
            _mobility.MoveBy(_move.ReadValue<Vector2>());
        }

        public void OnEnable()
        {
            _playerMap.Enable();
           
        }

        private void OnDisable()
        {
            _playerMap.Disable();
        }

        public void OnDestroy()
        {
            _connect.performed -= Connect;
            _disconnect.performed -= Disconnect;
        }
    }
}