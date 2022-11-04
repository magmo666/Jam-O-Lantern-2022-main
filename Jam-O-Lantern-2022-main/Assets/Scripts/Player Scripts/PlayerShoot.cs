using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    //i was gonna extend it from PlayerController but then id have to change things from private to protected
    //and id rather not mess with anything at risk of anything breaking bc i am v dumb - your least fav programmer, Cat
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject shootingPoint;
    [SerializeField] private GameObject sun;
    [SerializeField] private float speed = 4;

    public PlayerInputActions playerControls;
    private InputAction fire;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
    }

    private void OnDisable()
    {
        fire.Disable();
    }

    private void Update()
    {
        if(fire.WasPressedThisFrame() && sun != null) //if sun is destroyed, cannot shoot anymore
        {
            fireBullet();
        }
    }

    private void fireBullet()
    {
        Vector2 direction = sun.transform.position - shootingPoint.transform.position;
        GameObject clone = Instantiate(projectile, shootingPoint.transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
