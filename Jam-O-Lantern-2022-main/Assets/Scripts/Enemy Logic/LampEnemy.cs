using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampEnemy : EnemyMovement
{
    [SerializeField] private float range = 2f; //range of lamp enemy
    [SerializeField] private GameObject lampBase; //center of lamp base
    Vector3 centerPosition; //center position of lamp base
    void Start()
    {
        centerPosition = lampBase.transform.position;
    }

    public void Update()
    {
        float distance = Vector3.Distance(centerPosition, this.transform.position);

        if (distance <= range) //move towards player up to certain distance
        {
            base.Update(); //references EnemyMovement.Update()
        } else //prevents the enemy from getting stuck once it hits the circle radius
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, centerPosition,
                (speed / 4) * Time.deltaTime);
        }
    }

}
