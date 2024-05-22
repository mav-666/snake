using Electricity.Couplers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class SnakeInput : MonoBehaviour
    {
        [SerializeField] private InputActionAsset actions;

        private IMobility _mobility;
        private FindingCoupler _snakeConnection;
        
        private InputAction _move;
        private InputActionMap _playerMap;
        
        private void Awake()
        {
            _playerMap = actions.FindActionMap("Player");

            _move = _playerMap.FindAction("Move");
            
            var connect = _playerMap.FindAction("Connect");
            connect.performed += ctx =>
            {
                if (ctx.interaction == null)
                    _snakeConnection.FindUnconnected();
            };

            var disconnect = _playerMap.FindAction("Disconnect");
            disconnect.performed += _ => _snakeConnection.BreakConnected();
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

        public void OnDisable()
        {
            _playerMap.Disable();
        }
    }
}