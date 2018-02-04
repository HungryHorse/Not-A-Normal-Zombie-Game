using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    public int Hp;
    public int damage;
    float attackCooldown;
    public float cooldownRate;
    public GameObject ZombieObj;
    NavMeshAgent navAgent;
    public Transform target;
    GameObject Player;

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

        if(attackCooldown > 0)
        {
            attackCooldown -= cooldownRate * Time.deltaTime;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Hp -= collision.gameObject.GetComponent<Bullet>().damage;
        }
        if(collision.gameObject.tag == "Bullet" && Hp <= 0)
        {
            Destroy(ZombieObj);
        }
        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && attackCooldown <= 0)
        {
            Player.GetComponent<Movement>().health -= damage;
            attackCooldown = 10;
        }
        if (collision.gameObject.tag == "Player" && Player.GetComponent<Movement>().health <= 0)
        {
            Destroy(Player);
        }
    }
}
