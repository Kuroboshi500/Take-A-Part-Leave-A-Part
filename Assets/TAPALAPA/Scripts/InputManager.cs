using UnityEngine;

namespace TAPALAPA.Scripts
{
    [CreateAssetMenu(fileName = "New Input Manager", menuName = "Input Manager", order = -1000)]
    public class InputManager : ScriptableObject
    {
        private InputActions _inputActions;

        private void OnEnable()
        {
            _inputActions ??= new InputActions();
        }

        private void OnDisable()
        {
            _inputActions = null;
        }

        public void SetPlayerActionsEnabled(bool isEnabled)
        {
            if (isEnabled)
            {
                _inputActions.Player.Enable();
            }
            else
            {
                _inputActions.Player.Disable();
            }
        }
    }
}