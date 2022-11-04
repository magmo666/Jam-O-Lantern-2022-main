using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float damage = 0.01f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sun")
        {
            Sun sun = collision.gameObject.GetComponent<Sun>();
            sun.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
