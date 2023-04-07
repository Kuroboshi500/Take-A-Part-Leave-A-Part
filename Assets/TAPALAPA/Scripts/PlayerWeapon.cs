using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace TAPALAPA.Scripts
{

    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField]
        [Range(1, 100)]
        private int baseDamage = 20;
        //[SerializeField]
        //private float cooldown = .5f;

        [SerializeField]
        private Collider leftArm;
        [SerializeField]
        private Collider rightArm;

        public static event UnityAction<GameObject, float> onEnemyHit = delegate { };

        private void weaponCollide(Collider col)
        {
            col.gameObject.transform.position = col.gameObject.transform.position + new Vector3(col.gameObject.transform.position.x + 5, col.gameObject.transform.position.y, col.gameObject.transform.position.z);
            if (col.tag == "Enemy")
            {
                Debug.Log("attack triggered");
                onEnemyHit?.Invoke(col.gameObject, baseDamage);
            }
            col.gameObject.transform.position = col.gameObject.transform.position + new Vector3(col.gameObject.transform.position.x - 5, col.gameObject.transform.position.y, col.gameObject.transform.position.z);
        }
        
        private void leftAttack() { weaponCollide(leftArm); }
        private void rightAttack() { weaponCollide(rightArm); }

        private void Start()
        {
            leftArm = GameObject.Find("LeftArm").GetComponent<Collider>();
            rightArm = GameObject.Find("RightArm").GetComponent<Collider>();

        }
        private void OnEnable()
        {
            inputManager.PlayerLeftAttackEvent += leftAttack;
            inputManager.PlayerRightAttackEvent += rightAttack;
        }
        private void OnDisable()
        {
            inputManager.PlayerLeftAttackEvent -= leftAttack;
            inputManager.PlayerRightAttackEvent -= rightAttack;
        }
    }
}