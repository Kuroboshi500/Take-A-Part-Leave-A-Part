using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private int _health = 100;
    public float totalHealth => _health;

    // Events that can be used later to trigger animations or anything similar
    public event UnityAction onEnemyDeath;
    public event UnityAction<int> onEnemyDamaged;


    void enemyDamaged(var attacker, float dmg)
    {
        _health -= (int)Mathf.Round(dmg);
        Debug.Log("Enemy Current damage taken " + dmg + "\n Current Health is: " + _health);

        onEnemyDamaged?.Invoke(_health);
        if (_health <= 0)
        {
            Debug.Log("Death to enemy");
            onEnemyDeath?.Invoke();
        }
    }

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
}
