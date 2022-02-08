using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private float speedMovement = 4f;
    private float speedAdditional = 2f;
    private float vertical = 0f;
    private float horizontal = 0f;
    private float currentHeight = 0f;
    private float jumpHeight = 2f;

    private float rotationMultiplier = 3f;
    private float rotationAxis = 0f;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControler();
        RotationController();

    }

    void KeyboardControler()
    {
        vertical = Input.GetAxis("Vertical") * speedMovement;
        horizontal = Input.GetAxis("Horizontal") * speedMovement;

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            currentHeight = jumpHeight;
        }
        else if (!characterController.isGrounded)
        {
            currentHeight += Physics.gravity.y * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedMovement += speedAdditional;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedMovement -= speedAdditional;
        }
        Vector3 move = new Vector3(horizontal, currentHeight, vertical);
        move = transform.rotation * move;
        characterController.Move(move * Time.deltaTime);
    }

    void RotationController()
    {
        rotationAxis = Input.GetAxis("Camera Rotation") * rotationMultiplier;
        transform.Rotate(0f, rotationAxis, 0f);
    }


}