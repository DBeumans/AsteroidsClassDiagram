using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float speed;

    public float DestoryTimer;

    ShopManager _shopmanager;

    PlayerMovement player;

    EnemyHealth _enemyHealth;
    


    void Start()
    {
        _shopmanager = GameObject.FindObjectOfType<ShopManager>();
        DestoryTimer = _shopmanager.Bullet_Range;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Destroy(gameObject, DestoryTimer);
    }

    void Update()
    {

        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(player.teleportCounter == 1)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Bullet");
        }
        if(player.teleportCounter == 2)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Bullet1");
        }
    }

 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("GROUND HITTED!");
        }
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

}
