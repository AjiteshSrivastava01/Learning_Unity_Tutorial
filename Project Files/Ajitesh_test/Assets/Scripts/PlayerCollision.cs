using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Variables
    [SerializeField] BlockPlayerMovement movement;

    // Methods
    private void OnCollisionEnter(Collision collisionInfo)
    {
        // Debug.Log(collisionInfo.collider.name);
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an OBSTACLE");
            movement.enabled = false;
            FindObjectOfType<GameManagerScript>().EndGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
