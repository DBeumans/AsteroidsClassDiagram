using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    EnemyCollisionCheck _enemyColCheck;
    [SerializeField]
    PlayerHealth _playerHealth;

    [SerializeField]
    float SendDamage;
    
    void Start()
    {
        _enemyColCheck = gameObject.GetComponent<EnemyCollisionCheck>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        SendDamage = 20f;
    }


    public void Attack()
    {
        _playerHealth.GetDamage(SendDamage);
        
    }
}
