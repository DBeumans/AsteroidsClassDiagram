using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    float CurrentHealth = 100f;
    [SerializeField]
    float MaxHealth = 100f;


    Animator _anim;
    EnemyAi _enemyAI;
    AudioSource _audiosource;
    [SerializeField]
    AudioClip enemy_hit;

    float defaultTimeState;
    [SerializeField]
    float timer;
    float seconds;
    ShopManager _shopmanager;
    public int GetDamage;

    void Start()
    {
        _shopmanager = GameObject.FindObjectOfType<ShopManager>();
        GetDamage = _shopmanager.Bullet_Damage;
        _anim = gameObject.GetComponent<Animator>();
        _enemyAI = gameObject.GetComponent<EnemyAi>();
        _audiosource = GetComponent<AudioSource>();

        seconds = 1.4f;
        defaultTimeState = 24f * seconds + 12f;
        timer = defaultTimeState;
    }


	// Update is called once per frame
	void Update ()
    {
        
	    if(CurrentHealth <= 0)
        {
            _anim.SetBool("isDeath", true);
            timer--;
        }
        if(timer <= 0)
        {
            _enemyAI.MovementSpeed = 0;
            Destroy(gameObject);

            
        }


    }

    public void RecieveDamage(float damage)
    {
        CurrentHealth = CurrentHealth - damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            _audiosource.PlayOneShot(enemy_hit, 1f);
            Destroy(other.gameObject);
            RecieveDamage(GetDamage);
        }
    }
}
