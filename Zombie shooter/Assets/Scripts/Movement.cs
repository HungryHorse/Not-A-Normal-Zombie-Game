using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {

    public int health;
    int zombieDamage;
    public float Speed;
    float cooldown;
    float enabledTime;
    public float timeTickDown;
    public float cooldownRate;
    public Rigidbody PlayerRig;
    Vector3 movement;
    GameObject Player;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            movement = new Vector3(0, 0, 1);
            PlayerRig.AddForce(movement * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-1, 0, 0);
            PlayerRig.AddForce(movement * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = new Vector3(0, 0, -1);
            PlayerRig.AddForce(movement * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(1, 0, 0);
            PlayerRig.AddForce(movement * Speed);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Q) && cooldown <= 0)
        {
            Player.GetComponent<NavMeshObstacle>().enabled = false;
            Player.GetComponent<BoxCollider>().enabled = false;
            enabledTime = 10;
            cooldown = 40;
        }

        if(enabledTime <= 0)
        {
            Player.GetComponent<NavMeshObstacle>().enabled = true;
            Player.GetComponent<BoxCollider>().enabled = true;
        }

        if(enabledTime > 0)
        {
            enabledTime -= timeTickDown * Time.deltaTime;
        }

        if(cooldown > 0)
        {
            cooldown -= cooldownRate * Time.deltaTime;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}
