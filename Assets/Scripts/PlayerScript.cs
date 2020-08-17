using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript PlayerInstance;
    public bool IsVelocityChange;
    public float MovementSpeed;
    public float RotationSpeed;

    private Rigidbody myRB;
    private Animator myAnim;
    private float movementRate;
    private float rotationRate;
    private float strafeRate;
    private Vector3 movementVector;
    private Vector3 directionVector;

    private void OnEnable()
    {
        myAnim = GetComponent<Animator>();

        if(PlayerInstance == null)
        {
            PlayerInstance = this;
        }

        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        myRB.AddForce(-myRB.velocity, ForceMode.VelocityChange);
        
        ReadMovementInput();

        ApplyMovement();

    }

    void AutoMove()
    {
        movementVector = transform.forward * MovementSpeed;
    }

    void ReadMovementInput()
    {
        movementRate = Input.GetAxis("Vertical");
        movementRate *= Time.deltaTime;

        strafeRate = Input.GetAxis("Horizontal");
        strafeRate *= Time.deltaTime;

        rotationRate = RotationSpeed * Input.GetAxis("Mouse X");
        rotationRate *= Time.deltaTime;

        if (movementRate != 0 || strafeRate != 0 || rotationRate != 0)
        {
            myAnim.SetBool("IsWalking", true);
        }
        else
        {
            myAnim.SetBool("IsWalking", false);
        }

        movementVector = (transform.right * strafeRate + transform.forward * movementRate).normalized * MovementSpeed;
    }

    void ApplyMovement()
    {
        if (IsVelocityChange)
        {
            myRB.AddForce(movementVector, ForceMode.VelocityChange);
        }
        else
        {
            myRB.AddForce(movementVector, ForceMode.Acceleration);
        }

        transform.Rotate(0, rotationRate, 0);
    }
}
