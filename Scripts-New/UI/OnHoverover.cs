using UnityEngine;
using System.Collections;

public class OnHoverover : MonoBehaviour {

    AudioSource _audiosource;
    [SerializeField]
    AudioClip sound;

    [SerializeField]
    AudioClip clicksound;

	// Use this for initialization
	void Start () {
        _audiosource = gameObject.GetComponent<AudioSource>();
        _audiosource.volume = 0.2f;
	}

    public void Hover()
    {
        //Debug.Log("works");
        _audiosource.PlayOneShot(sound);   
    }

    public void PlayClickSound()
    {
        _audiosource.PlayOneShot(clicksound);
    }

}
