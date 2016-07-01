using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHighscoreList : MonoBehaviour {

    public GameObject PlayerScoreEntryPrefab;

    float inkomendeWave,hoogsteWave;
    float inkomendeScore, hoogsteScore;
    float inkomendeMinuten, hoogsteMinuten;
    float inkomendeHours, hoogsteHours;
    float inkomendeSeconds, hoogsteSeconds;

	// Use this for initialization
	void Start () {

        // Get Values
        inkomendeWave = PlayerPrefs.GetFloat("Wave");
        inkomendeScore = PlayerPrefs.GetFloat("Score");
        inkomendeMinuten = PlayerPrefs.GetFloat("Minutes");
        inkomendeSeconds = PlayerPrefs.GetFloat("Seconds");
        inkomendeHours = PlayerPrefs.GetFloat("Hours");
        //get values
        hoogsteWave = PlayerPrefs.GetFloat("Highscore_Wave");
        hoogsteScore = PlayerPrefs.GetFloat("Highscore_Score");
        hoogsteHours = PlayerPrefs.GetFloat("Highscore_Hours");
        hoogsteMinuten = PlayerPrefs.GetFloat("Highscore_Minutes");
        hoogsteSeconds = PlayerPrefs.GetFloat("Highscore_Seconds");

        if(inkomendeWave < hoogsteWave)
        {

            
            Debug.Log("Als inkomende wave kleiner is moet dit uitgevoerd worden");
            
        }
        else
        {
            hoogsteWave = inkomendeWave;
            hoogsteScore = inkomendeScore;
            hoogsteHours = inkomendeHours;
            hoogsteMinuten = inkomendeMinuten;
            hoogsteSeconds = inkomendeSeconds;

            Debug.Log("Er is nu een nieuwe highscore gezet!");
        }
        // save
        PlayerPrefs.SetFloat("Highscore_Wave", hoogsteWave);
        PlayerPrefs.SetFloat("Highscore_Score", hoogsteScore);
        PlayerPrefs.SetFloat("Highscore_Hours", hoogsteHours);
        PlayerPrefs.SetFloat("Highscore_Minutes", hoogsteWave);
        PlayerPrefs.SetFloat("Highscore_Seconds", hoogsteSeconds);
        PlayerPrefs.Save();
        SetScore();
    }

    void SetScore()
    {
        GameObject go = (GameObject)Instantiate(PlayerScoreEntryPrefab);
        go.transform.SetParent(this.transform);

        //-------------------------------------------------------------

        

        go.transform.Find("Points").GetComponent<Text>().text = hoogsteScore.ToString();
        go.transform.Find("Wave").GetComponent<Text>().text = hoogsteWave.ToString();
        go.transform.Find("Hours").GetComponent<Text>().text = hoogsteHours.ToString();
        go.transform.Find("Minutes").GetComponent<Text>().text = hoogsteMinuten.ToString();
        go.transform.Find("Seconds").GetComponent<Text>().text = hoogsteSeconds.ToString();
    }
}
