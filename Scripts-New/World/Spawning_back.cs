using UnityEngine;
using System.Collections;

public class Spawning_back : MonoBehaviour {

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject potion_life;
    [SerializeField]
    GameObject potion_full;
    [SerializeField]
    GameObject potion_low;

    

    bool spawn_potion_life;
    bool spawn_potion_full;
    bool spawn_potion_low;

    float time = 0f;
    float timestop;
    [SerializeField]
    float Seconds = 1f;

    float time_powerup = 0f;
    float time_powerup_stop;
    [SerializeField]
    float seconds_powerup;

    WaveManager _levelManager;
    public bool EnableSpawn = false;

    float potionSpawnLuck;

    bool AbleSpawn;
    // Use this for initialization
    void Start()
    {
        timestop = 24 * Seconds + 1f;
        time_powerup_stop = 24 * seconds_powerup + 12f;
        potionSpawnLuck = Random.Range(0f, 1f);
        _levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WaveManager>();
        
    }
    void Update()
    {
        
        if (!_levelManager.WaveCap)
        {
            if (EnableSpawn)
            {
                AbleSpawn2(true);
            }
        }
        time_powerup++;
        if (time_powerup >= time_powerup_stop)
        {
            potionSpawnLuck = Random.Range(0f, 1f);
            CheckPotionToSpawn();
            time_powerup = 0f;
        }
        else
        {
           
        }

        
    }

    void AbleSpawn2(bool value)
    {
        if(value)
        {
            time++;
            
            if(time >= timestop)
            {
                
                Spawn();
                time = 0f;
            }

           
        }
       
    }

    void CheckPotionToSpawn()
    {
        if (potionSpawnLuck > 0.1 && potionSpawnLuck < 0.2)
        {
            spawn_potion_life = true;
            Spawn_Potion();

        }

        if (potionSpawnLuck > 0.2 && potionSpawnLuck < 0.4)
        {
            spawn_potion_full = true;
            Spawn_Potion();

        }

        if (potionSpawnLuck > 0.4 && potionSpawnLuck < 1)
        {
            spawn_potion_low = true;
            Spawn_Potion();

        }
    }

    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        _levelManager.spawnAbleEnemies--;
    }

    void Spawn_Potion()
    {
        if (spawn_potion_life)
        {
           
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(potion_life, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            potionSpawnLuck = Random.Range(0f, 1f);
            spawn_potion_life = false;
        }
        if (spawn_potion_full)
        {
            
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(potion_full, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            potionSpawnLuck = Random.Range(0f, 1f);
            spawn_potion_full = false;
        }
        if (spawn_potion_low)
        {
            
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(potion_low, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            potionSpawnLuck = Random.Range(0f, 1f);
            spawn_potion_low = false;
        }
    }
}
