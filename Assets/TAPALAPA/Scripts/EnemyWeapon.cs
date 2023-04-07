using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Primary function is to be used to damage a player
public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private int baseDamage = 10;

    [SerializeField]
    private Collider weapon;

    public static event UnityAction<GameObject, float> onPlayerHit = delegate { };

}
