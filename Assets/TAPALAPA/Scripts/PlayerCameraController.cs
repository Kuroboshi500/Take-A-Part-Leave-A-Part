using Cinemachine;
using UnityEngine;

namespace TAPALAPA.Scripts
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        [SerializeField] private Transform bodyTransform;
        
        [SerializeField] private Transform cameraTransform;

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        private float _yaw;

        private float _pitch;
        
        private void OnEnable()
        {
            inputManager.PlayerLookEvent += OnInputLook;
        }
        
        private void OnDisable()
        {
            inputManager.PlayerLookEvent -= OnInputLook;
        }

        private void Update()
        {
            bodyTransform.localRotation = Quaternion.Euler(0f, _yaw, 0f);
            cameraTransform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
        }

        private void OnInputLook(Vector2 input)
        {
            _yaw += input.x;
            _pitch = Mathf.Clamp(_pitch + input.y, -90f, 90f);
        }
    }
}