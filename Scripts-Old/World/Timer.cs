using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField]
    Text TimerText;

    
    public float seconds, minutes, hours;
	
	// Update is called once per frame
	void Update ()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        TimerText.text = minutes.ToString("00") + " : " + seconds.ToString("00");

        if(minutes >= 60)
        {
            hours++;
            minutes = 0;
        }
	}
}
