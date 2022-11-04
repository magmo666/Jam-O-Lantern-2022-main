using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEnemy : EnemyMovement
{
    [SerializeField] private float decrease = 0.01f; //rate at which it shrinks
    [SerializeField] private Vector3 scale; //its initial scale size
    private void Start()
    {
        scale = new Vector3(decrease, decrease, decrease);
        StartCoroutine(Extinguish());
    }
    IEnumerator Extinguish()
    {
        while (enemy.transform.localScale.y > 0.1f) // if it is bigger than this size then continue to shrink
        {
            enemy.transform.localScale -= scale;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        Destroy(enemy); //once it is smaller than a certain size, get rid of it.
    }
}
