using UnityEngine;
using System.Collections;

public class EnemyCollisionCheck : MonoBehaviour {


    EnemyAi _enemy;
    [SerializeField]
    EnemyAttack _enemyAttack;

    [SerializeField]
    bool PlayerInSight;

    void Start()
    {
        _enemy = gameObject.transform.parent.GetComponent<EnemyAi>();
        _enemyAttack = gameObject.GetComponent<EnemyAttack>();


    }

    void AttackPlayer()
    {

        
    }

    // Update is called once per frame
    void Update ()
    {
        if(PlayerInSight)
        {             
            _enemy.ChasePlayer = true;
            _enemyAttack.Attack();
            _enemy.isAttacking = true;
            _enemy.isWalking = false;

        }

        if(!PlayerInSight)
        {
            _enemy.ChasePlayer = false;
            _enemy.isWalking = true;
            _enemy.isAttacking = false;
            
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(this.gameObject.layer == LayerMask.NameToLayer("Enemy_Front"))
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") && other.gameObject.tag == "GoLeft") // naar links front.
            {
                _enemy.Left = true;
                _enemy.Right = false;
                //Debug.Log("Going Left");
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") && other.gameObject.tag == "GoRight") // naar rechts front.
            {
                _enemy.Right = true;
                _enemy.Left = false;
                //Debug.Log("Going Right");
            }
        }
        
        if(this.gameObject.layer == LayerMask.NameToLayer("Enemy_Back"))
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground1") && other.gameObject.tag == "GoLeft") // naar links back.
            {
                _enemy.Left = true;
                _enemy.Right = false;
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground1") && other.gameObject.tag == "GoRight") // naar rechts back
            {
                _enemy.Right = true;
                _enemy.Left = false;
            }
        }
        


        //------------------------------------------------------------------------------

        if (this.gameObject.layer == LayerMask.NameToLayer("Enemy_Front"))
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerInSight = true;
                
            }
            

        }
        if(this.gameObject.layer == LayerMask.NameToLayer("Enemy_Back"))
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player1"))
            {
                PlayerInSight = true;
            }
           
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            PlayerInSight = false;
        }
        if (other.gameObject.layer != LayerMask.NameToLayer("Player1"))
        {
            PlayerInSight = false;
        }
    }

}
