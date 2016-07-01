using UnityEngine;
using System.Collections;

public class _startGame : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject startParticle;

    [SerializeField]
    Transform spawnPointPlayer;

    void Awake()
    {
        //player.SetActive(true);
        Instantiate(startParticle, spawnPointPlayer.position, spawnPointPlayer.rotation);
        player.SetActive(true);
       
    }
	void Start ()
    {
        player.SetActive(false);
        //player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
