using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private float fireRate = 5;
    [SerializeField] private float nextFire;
    [SerializeField] private GameObject shootingPoint; //point at which it shoots from
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 4;

    void FixedUpdate()
    {
        CheckIfTimeToFire();
    }

    //creates and shoots a fireball
    void CheckIfTimeToFire()
    {
        nextFire += Time.fixedDeltaTime;

        //checks if its time to shoot a new fireball
        if (fireRate <= nextFire)
        {
            //shoots in direction of player
            Vector2 direction = player.transform.position - shootingPoint.transform.position;
            GameObject clone = Instantiate(fire, shootingPoint.transform.position, transform.rotation);
            clone.GetComponent<Rigidbody2D>().velocity = direction * speed;
            nextFire = 0;
        }
    }
}
