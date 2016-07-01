using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour {

    public float Score;
    LevelManager _LevelManager;

    void Start()
    {
        _LevelManager = gameObject.GetComponent<LevelManager>();
        Score = 0;
        
    }
    void Update()
    {
        _LevelManager.ScoreText.text = Score.ToString();
    }
    public void RecieveScore(float value)
    {
        Score += value;
    }
}
