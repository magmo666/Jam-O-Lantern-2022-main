using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float timeToExtinguish = 2f; //time in seconds it takes to be extinguished
    [SerializeField] private GameObject fireContainer; //entire fire container

    void Start()
    {
        //called as soon as object is instantiated
        StartCoroutine(Extinguish(timeToExtinguish));
    }

    //if it hits the player, it will destroy itself.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            Destroy(fireContainer);
        }
    }

    //will destroy itself after a set amount of seconds
    IEnumerator Extinguish(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(fireContainer);
    }
}
