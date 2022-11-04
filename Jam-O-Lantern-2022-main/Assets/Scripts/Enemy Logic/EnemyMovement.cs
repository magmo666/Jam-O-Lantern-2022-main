using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject enemy;

    [SerializeField] protected float speed = -10f;
    
    public void Update()
    {
        if (player == null)
        {
            Debug.Log("No player has been detected.");
            return;
        }
        float step = speed * Time.deltaTime;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, step);
    }
}
