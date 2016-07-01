using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheckCollision : MonoBehaviour {


    // Use this for initialization

    bool respawn_front;
    bool respawn_back;
    Save _save;
    PlayerHealth _playerhealth;


    void Start()
    {

        _playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _save = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Save>();
    }

    void Update()
    {
  
        if (_save.SaveCompleted)
        {
            //_playerhealth.CurrentHealth = 0;
            SceneManager.LoadScene(2);
        }
    }


    public void Respawn()
    {
        _save.SaveFile();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        // FRONT
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {   
            if(this.gameObject.layer == LayerMask.NameToLayer("Death"))
            {
                Respawn();
            }

        }

        // BACK
        if (other.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {

            if (this.gameObject.layer == LayerMask.NameToLayer("Death"))
            {
                Respawn();
            }
        }
       

    }
}
