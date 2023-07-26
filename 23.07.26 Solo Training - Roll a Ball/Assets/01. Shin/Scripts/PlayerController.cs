using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigid = default;

    private float maxSpeed = 5.0f;
    private float jumpForce = 30.0f;

    public bool isJump = false;
    public bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float jump = Input.GetAxis("Jump");            

        if(!isJump && jump != 0)
        {
            Debug.Log("ют╥б");
            isJump = true;
            playerRigid.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
        }


    }
    private void FixedUpdate()
    {
        float zInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
    
        playerRigid.AddForce(new Vector3(xInput, 0f, zInput), ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJump = false;
        }
    }
}
