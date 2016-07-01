using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

    [SerializeField]
    GameObject ProceedNextLevelText;

    public int CurrentEnemies;

    int DefaultSpawnAbleEnemies = 4; // standard enemies on field.
    public int spawnAbleEnemies;
    [SerializeField]
    int MaxEnemies = 10000;

    GameObject[] EnemyObjecten;

    public bool WaveCap;
    public bool stopSpawn;

    bool ProceedToNextWave;

    AudioSource _audiosource;
    [SerializeField]
    AudioClip _waveclearedSound;
    
    public int waveCounter = 1;

    // Use this for initialization
    void Start () {
        ProceedNextLevelText.SetActive(false);
        spawnAbleEnemies += DefaultSpawnAbleEnemies;
        _audiosource = gameObject.GetComponent<AudioSource>();
    }

    void CheckInput()
    {
        if(ProceedToNextWave)
        {
            ProceedNextLevelText.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {
                // wanneer pressed nieuw wave
                _audiosource.volume = 0.1f;
                _audiosource.PlayOneShot(_waveclearedSound);
                Reset();
                ProceedToNextWave = false;
            }
        }
        if(!ProceedToNextWave)
        {
            ProceedNextLevelText.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update ()
    {
        CheckEnemiesInScene();
        CheckInput();
        EnemyObjecten = GameObject.FindGameObjectsWithTag("Enemy"); // zoek game object met tag Enemy en zet het in een array.

        CurrentEnemies = EnemyObjecten.Length; // aantal items in array in een int variable zetten om te zien hoeveel erin zit.


    }
    

    void Reset()
    {
        stopSpawn = false;
        WaveCap = false;
        waveCounter++;
        DefaultSpawnAbleEnemies += 2;
        spawnAbleEnemies += DefaultSpawnAbleEnemies + DefaultSpawnAbleEnemies/2;
        
        
    }
    void CheckEnemiesInScene()
    {
        if (spawnAbleEnemies == 0)
        {

            stopSpawn = true;

        }
        if (CurrentEnemies == 0 && spawnAbleEnemies == 0)
        {

            //CountDownt();
            ProceedToNextWave = true;
        }


        if (CurrentEnemies == MaxEnemies)
        {
            stopSpawn = true;
        }
        if (CurrentEnemies != MaxEnemies)
        {
            WaveCap = false;
        }

        if (stopSpawn)
        {
            WaveCap = true;
        }
    }

}
