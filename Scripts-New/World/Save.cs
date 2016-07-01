using UnityEngine;
using System.Collections.Generic;


public class Save : MonoBehaviour {

    ScoreHandler _scorehandler;
    Timer _timer;
    WaveManager _wavemanager;
    // naam > points > wave > hours > minutes > seconds    

    float playerMoney;
    float inkomendeScore;
    float inkomendeWave;
    float inkomendeMinutes, inkomendeSeconds, inkomendeHours;
    public bool SaveCompleted;

    void Start ()
    {

        
        _wavemanager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WaveManager>();
        _timer = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Timer>();
        _scorehandler = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<ScoreHandler>();
	}
    public void SaveFile()
    {

        inkomendeScore = _scorehandler.Score;
        inkomendeWave = _wavemanager.waveCounter;
        inkomendeMinutes = _timer.minutes;
        inkomendeSeconds = _timer.seconds;
        inkomendeHours = _timer.hours;  

        playerMoney += inkomendeScore;
        Debug.Log(playerMoney);

        PlayerPrefs.SetFloat("Score", inkomendeScore);
        PlayerPrefs.SetFloat("Wave", inkomendeWave);
        PlayerPrefs.SetFloat("Seconds", inkomendeSeconds);
        PlayerPrefs.SetFloat("Minutes", inkomendeMinutes);
        PlayerPrefs.SetFloat("Hours", inkomendeHours);
        PlayerPrefs.SetFloat("PlayerMoney", playerMoney);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("Score"));
        Debug.Log(PlayerPrefs.GetFloat("Wave"));
        Debug.Log(PlayerPrefs.GetFloat("Seconds"));
        Debug.Log(PlayerPrefs.GetFloat("Minutes"));
        Debug.Log(PlayerPrefs.GetFloat("Hours"));
        Debug.Log(PlayerPrefs.GetFloat("PlayerMoney"));

        SaveCompleted = true;


    }
	
}
