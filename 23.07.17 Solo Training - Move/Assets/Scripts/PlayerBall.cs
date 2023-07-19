using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public Rigidbody playerRigid = default;
    private float speed = 20.0f;
    private float jumpFower = 15.0f;

    public bool isJump = false;

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody>();
        playerRigid.velocity = Vector3.zero;
    }


    private void FixedUpdate()
    {
        float zInput = Input.GetAxisRaw("Vertical");
        float xInput = Input.GetAxisRaw("Horizontal");
        float yinput = Input.GetAxisRaw("Jump");

        if (yinput > 0 && !isJump)
        {
            //playerRigid.velocity = new Vector3(transform.position.x, jumpFower, transform.position.z);
            playerRigid.AddForce(Vector3.up * jumpFower, ForceMode.Impulse);
            isJump = true;
        }

        if (zInput > 0)
        {            
            playerRigid.AddForce(0f, transform.position.y, speed);
            
        }
        else if (zInput < 0)
        {
            playerRigid.AddForce(0f, transform.position.y, -speed);
        }

        if (xInput > 0)
        {
            playerRigid.AddForce(speed, transform.position.y, 0f);
        }
        else if (xInput < 0)
        {
            playerRigid.AddForce(-speed, transform.position.y, 0f);
        }
        /*else if(xInput==0)
        {
            playerRigid.velocity = new Vector3(playerRigid.velocity.x/2, playerRigid.velocity.y, playerRigid.velocity.z);
        }*/
        
    }

    private void Update()
    {
        float yinput = Input.GetAxisRaw("Jump");

        if (yinput > 0 && !isJump)
        {
            //playerRigid.velocity = new Vector3(transform.position.x, jumpFower, transform.position.z);
            playerRigid.AddForce(Vector3.up * jumpFower, ForceMode.Impulse);
            isJump = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground" && isJump)
        {
            isJump = false;
        }

    }

}
