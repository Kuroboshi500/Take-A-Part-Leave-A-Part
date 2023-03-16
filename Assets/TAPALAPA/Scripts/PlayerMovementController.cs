using UnityEngine;

namespace TAPALAPA.Scripts
{
    public class PlayerMovementController : MonoBehaviour
    {
        // Singleton referense (discovered from the fps workshop)
        public static PlayerMovementController instance;

        [SerializeField] private InputManager inputManager;

        [SerializeField] private CharacterController characterController;

        [SerializeField] private float movementSpeed = 5f;

        private Vector2 _movementInput;

        // enabling the singleton (discovered from the fps workshop)
        private void Start()
        {
            instance = this;
        }
        private void OnEnable()
        {
            inputManager.PlayerMoveEvent += OnInputMove;

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDisable()
        {
            inputManager.PlayerMoveEvent += OnInputMove;

            Cursor.lockState = CursorLockMode.None;
        }

        private void Update()
        {
            var movementInput = new Vector3
            {
                x = _movementInput.x,
                z = _movementInput.y
            };

            var movement = transform.TransformVector(movementInput);

            characterController.SimpleMove(movement * movementSpeed);
        }

        private void OnInputMove(Vector2 input)
        {
            _movementInput = input;
        }
    }
}