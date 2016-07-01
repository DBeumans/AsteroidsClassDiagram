using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HighScore : MonoBehaviour {


    Dictionary<string, Dictionary<string, int>> PlayerStats;

    int changeCounter = 0;

    void Start()
    {
        SetScore("Danilo", "wave", 970);
        SetScore("Danilo", "hours", 1);
        SetScore("Danilo", "minutes", 12);
        SetScore("Danilo", "seconds", 12);

        SetScore("Piet", "wave", 10000);
        SetScore("Bob", "wave", 44);
        SetScore("Rob", "wave", 21);
        SetScore("Kob", "wave", 3);
        Debug.Log( GetScore("Danilo", "wave") );
    }

    void Init()
    {
        if(PlayerStats != null)
            return;

        PlayerStats = new Dictionary<string, Dictionary<string, int>>();
    }

    public int GetScore(string username, string scoreType)
    {
        Init();

        if(PlayerStats.ContainsKey(username) == false)
        {
            return 0;
        }
        if(PlayerStats[username].ContainsKey(scoreType) == false)
        {
            return 0;
        }

        return PlayerStats[username][scoreType];
    }

    public void SetScore(string username, string scoreType, int value)
    {
        Init();
        changeCounter++;

        if (PlayerStats.ContainsKey(username) == false)
        {
            PlayerStats[username] = new Dictionary<string, int>();
        }
        PlayerStats[username][scoreType] = value;

    }
    public void ChangeScore(string username, string scoreType, int amount)
    {
        Init();
        int currentScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currentScore + amount);
    }

    public string[] GetPlayerNames()
    {
        Init();
        return PlayerStats.Keys.ToArray();
    }

    public string[] GetPlayerNames(string sortingScoreType)
    {
        Init();

        return PlayerStats.Keys.OrderByDescending(  n => GetScore(n, sortingScoreType) ).ToArray();
        
    }

    public int GetChangeCounter()
    {
        return changeCounter;
    }

}
