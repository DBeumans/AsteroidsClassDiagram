using UnityEngine;
using System.Collections;

public class PowerUpsSpawning : MonoBehaviour {

    [SerializeField]
    Transform[] spawnPoints;

    [SerializeField]
    GameObject potion_life;
    [SerializeField]
    GameObject potion_full;
    [SerializeField]
    GameObject potion_low;

    bool spawn_potion_life;
    bool spawn_potion_full;
    bool spawn_potion_low;

    float time;
    float timestop;
    [SerializeField]
    float Seconds = 3;


    float potionSpawnLuck;


    // Use this for initialization
    void Start ()
    {
        timestop = 24 * Seconds + 1f;
        potionSpawnLuck = Random.Range(0f, 1f);
    }

    void Update()
    {
        time++;
        if(time >= timestop)
        {
            potionSpawnLuck = Random.Range(0f, 1f);
            CheckPotionToSpawn();
            time = 0f;
        }

        SpawnPotions();
    }

    void CheckPotionToSpawn()
    {
        if (potionSpawnLuck > 0.1 && potionSpawnLuck < 0.2)
        {
            spawn_potion_life = true;
            SpawnPotions();
            
        }

        if (potionSpawnLuck > 0.2 && potionSpawnLuck < 0.4)
        {
            spawn_potion_full = true;
            SpawnPotions();
            
        }

        if (potionSpawnLuck > 0.4 && potionSpawnLuck < 1)
        {
            spawn_potion_low = true;
            SpawnPotions();
            
        }
    }

    void SpawnPotions()
    {

        
        if (spawn_potion_life)
        {
            Debug.Log("Potion_life");
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(potion_life, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            potionSpawnLuck = Random.Range(0f, 1f);
            spawn_potion_life = false;
        }
        if(spawn_potion_full)
        {
            Debug.Log("Potion_full");
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(potion_full, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            potionSpawnLuck = Random.Range(0f, 1f);
            spawn_potion_full = false;
        }
        if(spawn_potion_low)
        {
            Debug.Log("Potion_low");
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(potion_low, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            potionSpawnLuck = Random.Range(0f, 1f);
            spawn_potion_low = false;
        }

    }
}
