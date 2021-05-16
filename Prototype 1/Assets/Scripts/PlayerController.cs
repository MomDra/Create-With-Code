using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 20;
    [SerializeField]
    float rpm;
    [SerializeField]
    float horsePower = 0;
    float turnSpeed = 45;
    Rigidbody playerRb;
    [SerializeField]
    GameObject centerOfMass;
    [SerializeField]
    TextMeshProUGUI speedometerText;
    [SerializeField]
    TextMeshProUGUI rpmText;
    [SerializeField]
    List<WheelCollider> allWheels;
    [SerializeField]
    int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    private void Update()
    {
        if(transform.position.y < -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertialInput = Input.GetAxis("Vertical");
        // Moves the car forward based on vertical input
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * vertialInput);
        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * vertialInput);
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + "km/h");
            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }

        if(IsOnGround() && playerRb.velocity.magnitude*3.6f < 1)
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * vertialInput * 10);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
            return true;
        else
            return false;
    }
}
