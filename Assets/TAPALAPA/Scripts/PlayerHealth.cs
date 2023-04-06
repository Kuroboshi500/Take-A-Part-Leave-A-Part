using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private int _health = 50;
    public float totalHealth => _health;
    
    // Events that can be used later to trigger animations or anything similar
    public event UnityAction onPlayerDeath;
    public event UnityAction<int> onPlayerDamaged;
    

    void playerDamaged(var attacker, float dmg)
    {
        _health -= (int)Mathf.Round(dmg);
        Debug.Log("Player Current damage taken " + dmg + "\n Current Health is: " + _health);

        onPlayerDamaged?.Invoke(_health);
        if(_health <= 0)
        {
            Debug.Log("Death to player");
            onPlayerDeath?.Invoke();
        }
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

}
