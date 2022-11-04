using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LEDInteract : MonoBehaviour
{
    [SerializeField] private GameObject text;
    public PlayerInputActions playerControls;
    private InputAction interact;
    [SerializeField] private GameObject lightCollider;
    [SerializeField] private float offTime = 4;

    private void Awake()
    {
        text.SetActive(false);
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        interact = playerControls.Player.Interact;
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    //while player is in switch collider, text appears on screen and if the interact button is pressed,
    //it will disable the light collider.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has hit switch collider.");
            text.SetActive(true);
            if(interact.ReadValue<float>() == 1)
            {
                Debug.Log("Interact button has been pressed.");
                StartCoroutine(lightTimer());
                
            }
        }
    }

    //TextMeshPro object will disappear from canvas when player leaves the switch collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has left switch collider.");
            text.SetActive(false);
        }
    }

    //light collider will be disabled for a given amount of seconds
    IEnumerator lightTimer()
    {
        lightCollider.SetActive(false);
        yield return new WaitForSeconds(offTime);
        lightCollider.SetActive(true);
    }
}
