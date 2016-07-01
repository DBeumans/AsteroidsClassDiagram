using UnityEngine;
using System.Collections;

public class CheckSpawningCollision : MonoBehaviour {

    PlayerMovement player;

    public bool spawn_front;
    public bool spawn_back;

    Spawning_front Spawn_Front;
    Spawning_back Spawn_Back;

	// Use this for initialization
	void Start () {
        Spawn_Front = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<Spawning_front>();
        Spawn_Back = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<Spawning_back>();
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
