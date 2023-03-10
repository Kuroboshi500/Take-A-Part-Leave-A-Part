using UnityEngine;

namespace TAPALAPA.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        
        private void Start()
        {
            inputManager.SetPlayerActionsEnabled(true);
        }
    }
}