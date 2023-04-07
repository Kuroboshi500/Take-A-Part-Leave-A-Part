using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TAPALAPA.Scripts
{
    [CreateAssetMenu(fileName = "New Input Manager", menuName = "Input Manager", order = -1000)]
    public class InputManager : ScriptableObject, InputActions.IPlayerActions
    {
        public event UnityAction<Vector2> PlayerMoveEvent = delegate {  };
        
        public event UnityAction<Vector2> PlayerLookEvent = delegate {  };

        public event UnityAction PlayerLeftAttackEvent = delegate { };
        
        public event UnityAction PlayerRightAttackEvent = delegate { };

        private InputActions _inputActions;

        private void OnEnable()
        {
            _inputActions ??= new InputActions();
            
            _inputActions.Player.SetCallbacks(this);
        }

        private void OnDisable()
        {
            _inputActions.Player.SetCallbacks(null);
            
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

        public void OnMove(InputAction.CallbackContext context)
        {
            PlayerMoveEvent.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            PlayerLookEvent.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLeftAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                PlayerLeftAttackEvent.Invoke();
                Debug.Log(context);
            }
        }

        public void OnRightAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                PlayerRightAttackEvent.Invoke();
                Debug.Log(context);

            }
        }
    }
}