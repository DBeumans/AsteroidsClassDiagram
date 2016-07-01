using UnityEngine;
using System.Collections;

public class CheckSpawningCollision : MonoBehaviour {

    PlayerMovement player;

    public bool spawn_front;
    public bool spawn_back;

    Spawning _spawning

	// Use this for initialization
	void Start () {
        _spawning = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<Spawning>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        
	}

    void FixedUpdate()
    {
        CheckPlayerPos();
    }
	

    void CheckPlayerPos()
    {
        if(player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            spawn_back = false;
            spawn_front = true;
        }
        if(player.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {
            spawn_front = false;
            spawn_back= true;
        }
    }

    void Update()
    {
        if(spawn_back)
        {
            Spawn_Back.EnableSpawn = true;
            Spawn_Front.EnableSpawn = false;
        }
        if(spawn_front)
        {
            Spawn_Front.EnableSpawn = true;
            Spawn_Back.EnableSpawn = false;
        }
    }
}
