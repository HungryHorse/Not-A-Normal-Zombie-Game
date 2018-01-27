using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject projectile;
    public GameObject gun;
    GameObject bullet;
    public float velocity;
    public int bulletDamage = 10;
    public int gunChoice = 0;
    public int noOfGuns;
    float rechamberTime;
    public float rateOfRechamber;


	// Use this for initialization
	void Start ()
    {
        rechamberTime = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(scroll > 0f)
        {
            gunChoice++;
            if(gunChoice > noOfGuns - 1)
            {
                gunChoice = 0;
            }
        }
        else if(scroll < 0f)
        {
            gunChoice--;
            if(gunChoice < 0)
            {
                gunChoice = noOfGuns - 1;
            }
        }


        if (Input.GetButtonDown("Fire1") && gunChoice == 0 && rechamberTime <= 0)
        {
            bulletDamage = 10;

            bullet = Instantiate(projectile, gun.transform.position, transform.rotation);
            
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * velocity;

            rechamberTime = 5;
        }

        if(Input.GetButton("Fire1") && gunChoice == 1 && rechamberTime <= 0)
        {
            bulletDamage = 7;

            bullet = Instantiate(projectile, gun.transform.position, transform.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * velocity;

            rechamberTime = 3;
        }

        if (Input.GetButtonDown("Fire1") && gunChoice == 2 && rechamberTime <= 0)
        {
            bulletDamage = 20;

            bullet = Instantiate(projectile, gun.transform.position, transform.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * velocity;

            rechamberTime = 10;
        }

        if (rechamberTime > 0)
        {
            rechamberTime -= rateOfRechamber * Time.deltaTime;
        }
    }

}
