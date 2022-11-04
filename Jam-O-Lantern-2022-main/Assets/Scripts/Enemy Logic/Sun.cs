using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private GameObject sun;
    // Start is called before the first frame update
    void Start()
    {
        health = this.GetComponent<Collider2D>().GetComponent<Transform>().localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < .1)
        {
            Destroy(sun);
        }
        
        Vector3 size = new Vector3(health, health);
        sun.GetComponent<Transform>().localScale = size;

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
