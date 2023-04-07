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
            Debug.Log("attack triggers");
            // this transform does not work well for our purposes and just sends the arms flying
           // col.gameObject.transform.position = col.gameObject.transform.position + new Vector3(col.gameObject.transform.position.x , col.gameObject.transform.position.y, col.gameObject.transform.position.z + 5);
            if (col.tag == "Enemy")
            {
                Debug.Log("attack collided");
                onEnemyHit?.Invoke(col.gameObject, baseDamage);
            }
            //col.gameObject.transform.position = col.gameObject.transform.position + new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, col.gameObject.transform.position.z- 5);
        }
        
        public void leftAttack() { weaponCollide(leftArm); }
        public void rightAttack() { weaponCollide(rightArm); }



        // currently there is an issue stating that something below does not exist (NullReferenceException
        
        private void OnEnable()
        {
            InputManager.PlayerLeftAttackEvent += leftAttack;
            InputManager.PlayerRightAttackEvent += rightAttack;
        }
        private void OnDisable()
        {
            InputManager.PlayerLeftAttackEvent -= leftAttack;
            InputManager.PlayerRightAttackEvent -= rightAttack;
        }
    }
}