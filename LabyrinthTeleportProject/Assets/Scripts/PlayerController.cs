using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 12f;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    private void FixedUpdate()
    {
        PlayerGroundCheck();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void PlayerGroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),
            out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch(terrainType)
            {
                default:
                    speed = 12;
                    break;
                case "Low":
                    speed = 6;
                    break;
                case "High":
                    speed = 18;
                    break;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
