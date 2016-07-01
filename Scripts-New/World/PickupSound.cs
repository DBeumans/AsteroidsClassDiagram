using UnityEngine;
using System.Collections;

public class PickupSound : MonoBehaviour {

    AudioSource _audiosource;
    [SerializeField]
    AudioClip pickupsound;

    void Start()
    {
        _audiosource = gameObject.GetComponent<AudioSource>();
    }
	// Use this for initialization
	public void playSound()
    {
        _audiosource.PlayOneShot(pickupsound);
    }
}
