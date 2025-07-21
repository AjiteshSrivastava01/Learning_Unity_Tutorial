using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int playerSpeed = 500;
    [SerializeField] private int playerMovementSpeed = 500;
    private bool moveLeft = false;
    private bool moveRight = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }
        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
    }

    // Updaet called once per PHYSICS frame
    private void FixedUpdate()
    {
        // Constantly Add Forward Force
        rb.AddForce(0, 0, playerSpeed * Time.deltaTime);

        if (moveRight)
        {
            rb.AddForce(playerMovementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (moveLeft)
        {
            rb.AddForce(-playerMovementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
