using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private Rigidbody2D rb;


    [SerializeField] private Transform playerContainerTransform;


    private Vector2 moveDirection = Vector2.zero;

    [Header("Player Movement Settings")]
    //controls how fast player moves
    [SerializeField] private float speed;


    public PlayerInputActions playerControls;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();


    }

    private void OnDisable()
    {
        move.Disable();
    }

    //Update is called once every frame
    void Update()
    {
        //reads the input of WASD as a Vector2 (X, Y)

        moveDirection = move.ReadValue<Vector2>();




    }



    //fixed update is also called once every frame but is frame rate independent (good for physics (rigidbody stuff))
    private void FixedUpdate()
    {



        //this is the line of code that actually moves the player
        //also prevents some forces from affecting the player when not moving because movedirection = 0 when not moving;


        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);


        //flips the player
        switch (move.ReadValue<Vector2>().x)
        {
            case < 0:
                playerContainerTransform.rotation = new Quaternion(0f, 180f, 0f, 0f);

                break;

            case > 0:
                playerContainerTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);

                break;
        }


    }



}