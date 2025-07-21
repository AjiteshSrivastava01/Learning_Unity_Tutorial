using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int jumpHeight = 7;
    public int playerSpeed = 2;
    [SerializeField] private Transform groundCheckTransform; // Adding the "[Serealized Field]" tag and making the variable private exposes it in the inspector the same way makling it "public" would.
    private bool jumpKeyWasPressed = false;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    [SerializeField] private LayerMask playerMask;
    private Vector3 prevPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Catch when SPace Key is Pressed
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            // Debug.Log("Space Key Pressed");
            jumpKeyWasPressed = true;
        }

        // Check for movement key input
        horizontalInput = Input.GetAxis("Horizontal");

        
       // Record last position where the player was on a platform
       if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length != 0)
       {
           prevPosition = GetComponent<Transform>().position;
       }
       
        if (GetComponent<Transform>().position.y < -10)
        {
            Debug.Log("Falling...");
            transform.position = prevPosition;
        }

    }

    // Called every Physics Update (100 times per second by default)
    private void FixedUpdate()
    {
       
        // Apply physics force for jumping
        if (jumpKeyWasPressed == true && (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length != 0))
        {
            Debug.Log("Jumped");
            rigidBodyComponent.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        // Apply physics force for movement
        rigidBodyComponent.velocity = new Vector3(horizontalInput * playerSpeed, GetComponent<Rigidbody>().velocity.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
        }
    }

}
