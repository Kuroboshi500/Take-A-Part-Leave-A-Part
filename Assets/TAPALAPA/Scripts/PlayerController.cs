using System;
using UnityEngine;

namespace TAPALAPA.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        [SerializeField] private CharacterController characterController;

        [SerializeField] private float movementSpeed = 10f;

        private Vector2 _movementInput;

        private void OnEnable()
        {
            inputManager.PlayerMoveEvent += OnInputMove;
        }

        private void OnDisable()
        {
            inputManager.PlayerMoveEvent += OnInputMove;
        }

        private void Update()
        {
            var movement = new Vector3
            {
                x = _movementInput.x,
                z = _movementInput.y
            };

            characterController.SimpleMove(movement * movementSpeed);
        }

        private void OnInputMove(Vector2 input)
        {
            _movementInput = input;
        }
    }
}