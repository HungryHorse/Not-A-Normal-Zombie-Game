using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Zombie;
    public int noToSpawn;
    float delay;
    public float delayRate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(noToSpawn > 0)
        {
            if (delay <= 0)
            {
                Instantiate(Zombie, transform.position, transform.rotation);
                noToSpawn -= 1;
                delay = 10f;
            }
        }

        delay -= delayRate * Time.deltaTime;
	}
}
