using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float turnSpeed = 25.0f;
    [SerializeField] float rpm;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] float horsePower = 0;
    private Rigidbody playerRb;
    [SerializeField] GameObject MassOfCenter;
    [SerializeField] TextMeshProUGUI kmh;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = MassOfCenter.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    { if(IsGround())
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput );
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            kmh.SetText("Speed:" + speed + " Kmh");
            rpm = Mathf.RoundToInt(speed % 10) * 40;
            rpmText.SetText("RPM:" + rpm);
        }
        
        
    }

    bool IsGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
           
         }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
