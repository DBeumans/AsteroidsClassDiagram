using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    float destroyTimer;


    void Start ()
	{
        destroyTimer = 10f;
        Destroy(gameObject, destroyTimer);
	}
}