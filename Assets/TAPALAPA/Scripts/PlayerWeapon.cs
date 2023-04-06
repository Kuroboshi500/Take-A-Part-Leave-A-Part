using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField][Range(1,100)]
    private int baseDamage = 20;
    [SerializeField]
    private float cooldown = .5f;

    public event UnityAction<GameObject, float> onEnemyHit;

    private void weaponCollide(Collider col)
    {
        if (col.tag == "Enemy")
        {
            onEnemyHit?.Invoke(col.gameObject, baseDamage);
        }
    }
}
