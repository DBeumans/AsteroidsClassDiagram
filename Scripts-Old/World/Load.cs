using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Load : MonoBehaviour {

    [SerializeField]
    Text ScoreText;
    [SerializeField]
    Text WaveText;
    [SerializeField]
    Text Time_Hours;
    [SerializeField]
    Text Time_Minutes;
    [SerializeField]
    Text Time_Seconds;

    [SerializeField]
    GameObject playerHighScorePrefab;

    public float score;
    public float wave;
    public float minutes, seconds, hours;
	// Use this for initialization
	void Start ()
    {
        
        score = PlayerPrefs.GetFloat("Score");
        wave = PlayerPrefs.GetFloat("Wave");
        minutes = PlayerPrefs.GetFloat("Minutes");
        seconds = PlayerPrefs.GetFloat("Seconds");
        hours = PlayerPrefs.GetFloat("Hours");
        Debug.Log(hours + "H" + minutes + "M" + seconds + "S");


    }

    void Update()
    {
        ScoreText.text = "Score: " + score.ToString();
        WaveText.text = "Wave: " + wave.ToString();
        Time_Hours.text = hours.ToString("00");
        Time_Minutes.text = minutes.ToString("00");
        Time_Seconds.text = seconds.ToString("00");
        
    }
	

}
