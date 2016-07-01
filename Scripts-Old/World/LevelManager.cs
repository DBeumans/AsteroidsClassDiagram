using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    GameObject PauzeUI;
    [SerializeField]
    GameObject InGameUI;

    [SerializeField]
    bool PauzeEnabled = false;

    [SerializeField]
    Text WaveText;
    public Text ScoreText;
    [SerializeField]
    Text ZombiesLeft;

    [SerializeField]
    Text currentHealth;
    [SerializeField]
    Text lives;
        

    WaveManager _wavemanager;
    PlayerHealth _playerHealth;

    // Use this for initialization
    void Start ()
    {
        PauzeUI.SetActive(false);

        _wavemanager = GetComponent<WaveManager>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInputs();
        ScreenUpdate();

    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PauzeEnabled)
            {
                PauzeScreenEnabled();
            }
            else if(PauzeEnabled)
            {
                PauzeScreenDisabled();
            }
            
        }
        
    }

    void ScreenUpdate()
    {


        ZombiesLeft.text = _wavemanager.CurrentEnemies.ToString(); // naar UI, zodat je het in game kan zien.
        WaveText.text = _wavemanager.waveCounter.ToString();
        lives.text = _playerHealth.lives.ToString() + "/3";
        currentHealth.text = _playerHealth.CurrentHealth.ToString("00") + "%";

    }

    public void PauzeScreenEnabled()
    {
        InGameUI.SetActive(false);
        PauzeEnabled = true;
        PauzeUI.SetActive(true);
        Time.timeScale = 0;   
    }

    public void PauzeScreenDisabled()
    {
        InGameUI.SetActive(true);
        PauzeUI.SetActive(false);
        Time.timeScale = 1;
        PauzeEnabled = false;
    }

    public void MainMenu(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
