using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //FLOATS---------------------
    [SerializeField]
    float MovementSpeed = 7;
    [SerializeField]
    float SlamSpeed = 15;
    [SerializeField]
    float jumpPower = 20f;
    // INT-----------------------
    public int teleportCounter;
    // SCRIPTS-------------------
    PlayerMovement _player;
    PlayerShooting _playershooting;
    // TRANSFORMS----------------
    [SerializeField]
    Transform Playertransform;
    [SerializeField]
    Transform groundedEnd;
    //GAMEOBJECTS----------------
    [SerializeField]
    GameObject _camtar;
    // COMPONENTS----------------
    Animator anim;
    Rigidbody2D rb2d;
    AudioSource _audiosource;
    [SerializeField]
    AudioClip _audioclip;
    //BOOLEANS-------------------
    [SerializeField]
    bool grounded = false;
    bool canDoubleJump = false;
    //bool _takeover = false;
    bool StopAnimationPlaying;

    //public bool ChangeBackground;

    void Start()
    {
        // Get component function.
        GetComponent();
        SetValues();

        _camtar.SetActive(true);
        _player.enabled = true;
    }
    void SetValues()
    {
        teleportCounter = teleportCounter + 1;
    }
    void GetComponent()
    {
        _playershooting = GetComponent<PlayerShooting>();
        _player = GetComponent<PlayerMovement>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        _audiosource = gameObject.GetComponent<AudioSource>();
        _audiosource.volume = 0.1f;
    }
    void Update()
    {
        Inputs();
        raycasting();
        CallAnimations();
        CheckVariables();
        
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    void CheckVariables()
    {
        if(teleportCounter == 2)
        {
           // gameObject.layer = LayerMask.NameToLayer("Player1");
           SetLayerRecursively(this.gameObject, 13);
           

        }
        if(teleportCounter == 1)
        {
            // gameObject.layer = LayerMask.NameToLayer("Player");
            SetLayerRecursively(this.gameObject, 9);
            

        }
    }

    void CallAnimations()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("willow_stop_anim"))
        {
            StopAnimationPlaying = true;
        }
        else if(!StopAnimationPlaying)
        {
            anim.SetBool("StopRunning", false);
            anim.SetBool("ToIdle", true);
        }
        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.A)))
        {
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {

            }
            /*
            ****

            FALLING ANIMATION

            ****
            else if(!grounded)
            {
                anim.SetBool("IsRunning", false);
                //anim.SetBool("IsFalling", true);
            }
            */
            else
            {
                anim.SetBool("IsRunning", false);
                anim.SetBool("StopRunning", true);
                //anim.SetBool("IsFalling", false);
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("StopRunning", false);
            anim.SetBool("IsRunning", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("StopRunning", false);
            anim.SetBool("IsRunning", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsJumping", true);
            
        }
    }
    void Inputs()
    {
        // MOVEMENT
        // LEFT
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            
        }
        
        //RIGHT
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
            
        }

        // Slam 
        if(Input.GetKey(KeyCode.S) && grounded == false)
        {
            transform.Translate(Vector2.down * SlamSpeed * Time.deltaTime);
        }
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(teleportCounter == 1)
            {
                _audiosource.PlayOneShot(_audioclip);
                Playertransform.transform.position += transform.position = new Vector3(0, 0, 20f);
                
                ChangeBackground = true;
                teleportCounter++;
            }
            else
            {
                //Debug.Log("Cant go any further!");
                

            }
     

        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            if (teleportCounter == 2)
            {
                _audiosource.PlayOneShot(_audioclip);
                Playertransform.transform.position += transform.position = new Vector3(0, 0, -20);
                ChangeBackground = false;
                teleportCounter--;
            }
            else
            {
                Debug.Log("Cant go any further!");
                
            }

        }

        // JUMP && DOUBLE JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {         
            if(grounded)
            {
                
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower * 2);
                canDoubleJump = true;
            }
            else if(canDoubleJump)
            {
                canDoubleJump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower * 2);
            }
        }

        
    }

    void raycasting()
    {
        Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);

        

        if(this.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
        }
        if(this.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {
            grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground1"));
        }
        


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(9, 10);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpecialEnemy"))
        {

            Debug.Log("Press E to take over!");
            _takeover = true;
        }


    }
}
