using UnityEngine;
using System.Collections;

public class PowerUpsSpawning : MonoBehaviour {

    [SerializeField]
    Transform[] spawnPoints;
	
	
	
	[SerializeField]
	GameObject[] Potions;

	[SerializeField]
	bool[] spawn_potions;

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
		spawnPotions = spawn_potions.lenght;
		for(int i=0;i<potions_array;i++)
		{
			if (potionSpawnLuck > 0.1 && potionSpawnLuck < 0.2)
			{
				spawnPotions[0] = true;
				SpawnPotions();
            
			}

			if (potionSpawnLuck > 0.2 && potionSpawnLuck < 0.4)
			{
				spawnPotions[1] = true;
				SpawnPotions();
            
			}

			if (potionSpawnLuck > 0.4 && potionSpawnLuck < 1)
			{
				spawnPotions[2] = true;
				SpawnPotions();
            
			}
		}
		
        
    }

    void SpawnPotions()
    {
		spawnPotions = spawn_potions.lenght;
        for(int i=0;i<potions_array;i++)
		{
			if (spawnPotions[0])
			{
				Debug.Log("Potion_life");
				int spawnPointIndex = Random.Range(0, spawnPoints.Length);
				Instantiate(Potions[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
				potionSpawnLuck = Random.Range(0f, 1f);
				spawn_potion_life = false;
			}
			if(spawnPotions[1])
			{
				Debug.Log("Potion_full");
				int spawnPointIndex = Random.Range(0, spawnPoints.Length);
				Instantiate(Potions[1], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
				potionSpawnLuck = Random.Range(0f, 1f);
				spawn_potion_full = false;
			}
			if(spawnPotions[2])
			{
				Debug.Log("Potion_low");
				int spawnPointIndex = Random.Range(0, spawnPoints.Length);
				Instantiate(Potions[2], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
				potionSpawnLuck = Random.Range(0f, 1f);
				spawn_potion_low = false;
			}
		}
        

    }
}
