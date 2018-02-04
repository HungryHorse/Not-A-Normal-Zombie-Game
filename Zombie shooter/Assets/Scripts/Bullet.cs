using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject bullet;
    GameObject Player;
    float lifetime = 5f;
    public int damage;

    void Awake()
    {
        Player = GameObject.Find("Player");
        Destroy(bullet, lifetime);
        damage = Player.GetComponent<Shooting>().bulletDamage;
    }


    void OnCollisionEnter(Collision collision)
    {
        Destroy(bullet);

        if(collision.gameObject.tag == "Zombie")
        {
            
        }
    }
}
