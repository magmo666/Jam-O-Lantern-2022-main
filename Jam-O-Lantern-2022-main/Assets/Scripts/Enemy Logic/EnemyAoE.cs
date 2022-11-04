using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAoE : MonoBehaviour
{

    IEnumerator coroutine; //coroutine variable that will be used to start/stop DamageOverTime
    public int decreaseHealth = 10; //amount of damage dealth to player's health
    public float damageInterval = 0.5f; //time interval which player takes damage

    Transform parentTransform;

    private void Awake()
    {
        parentTransform = transform.parent;
        transform.position = parentTransform.position;
        transform.localScale = parentTransform.localScale;
    }

    //starts the DamageOverTime coroutine if a player collides with the AoE collider and isn't running already.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {     
            Debug.Log("Player has collided with enemy collider.");

            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            //health.TakeDamage(decreaseHealth);
            if (coroutine != null) return; 
            coroutine = DamageOverTime(health);
            StartCoroutine(coroutine);
        }
    }

    //stops the DamageOverTime coroutine when the player leaves the collider and if the coroutine was ever started
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has left collider.");
            if (coroutine == null) return;
            StopCoroutine(coroutine);
            coroutine = null;
        }

    }


    //does set amount of damage to player at a fixed interval until coroutine is stopped
    public virtual IEnumerator DamageOverTime(PlayerHealth health)
    {
        while (true)
        {
            Debug.Log("Player has taken damage.");
            health.TakeDamage(decreaseHealth);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}

