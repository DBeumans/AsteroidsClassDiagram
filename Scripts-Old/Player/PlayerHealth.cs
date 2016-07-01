using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    CheckCollision _checkCol;

    public float lives;

    public float CurrentHealth;
    [SerializeField]
    float MaxHealth;

    [SerializeField]
    bool AttackCooldown;

    float defaultTimeState;
    [SerializeField]
    float timer;
    [SerializeField]
    float seconds;

    public bool potion_life_front;
    public bool potion_full_front;
    public bool potion_low_front;

    public bool potion_life_back;
    public bool potion_full_back;
    public bool potion_low_back;

    PowerUps _powerups;

    PickupSound 

    // Use this for initialization
    void Start ()
    {
        lives = 3;
        MaxHealth = 100f;
        CurrentHealth = 100f;

        defaultTimeState = 24f * seconds + 12f;
        timer = defaultTimeState;

        _powerups = GameObject.FindObjectOfType<PowerUps>();

    }
    
    void Update()
    {
        _checkCol = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<CheckCollision>();
        if (AttackCooldown)
        {
            timer--;
            
        }
        if (timer <= 0)
        {
            timer = defaultTimeState;
            AttackCooldown = false;
        }

        if (CurrentHealth <= 0)
        {

            if (lives <= 0)
            {
                _checkCol.Respawn();
            }
            else
            {
                lives--;
                CurrentHealth = MaxHealth;
            }
        }
    }
    public void GetDamage(float damage)
    {
        if(!AttackCooldown)
        {
            CurrentHealth = CurrentHealth - damage;
            AttackCooldown = true;
            Debug.Log(CurrentHealth);
        }
        else
        {
           // Debug.Log("nothing");
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Potion_life")
        {
            if (lives != 3)
            {
                Debug.Log("potion_life_back");
               
                lives++;
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.tag == "Potion_full")
        {
           
            CurrentHealth = 100;
            Debug.Log("potion_full_back");
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Potion_low")
        {
            if(CurrentHealth >=80)
            {
                
                CurrentHealth = 100;
            }
           
            CurrentHealth += 20;
            Debug.Log("potion_low_back");
            Destroy(other.gameObject);
        }
    }
}
