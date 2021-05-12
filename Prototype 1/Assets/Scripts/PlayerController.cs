using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // float speed = 20;
    [SerializeField]
    float horsePower = 0;
    float turnSpeed = 45;
    Rigidbody playerRb;
    [SerializeField]
    GameObject centerOfMass;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertialInput = Input.GetAxis("Vertical");
        // Moves the car forward based on vertical input
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * vertialInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * vertialInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
