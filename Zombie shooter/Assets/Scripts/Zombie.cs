using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    public int Hp;
    public GameObject ZombieObj;
    NavMeshAgent navAgent;
    public Transform target;
    GameObject Player;
    int bulletDamage;

	// Use this for initialization
	void Start ()
    {
        navAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        target = Player.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        navAgent.SetDestination(target.position);

        bulletDamage = Player.GetComponent<Shooting>().bulletDamage;
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Hp -= bulletDamage;
        }
        if(collision.gameObject.tag == "Bullet" && Hp <= 0)
        {
            Destroy(ZombieObj);
        }

    }
}
