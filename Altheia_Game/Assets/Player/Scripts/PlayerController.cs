using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player controls
    public float walkSpeed = 10f;
    public float runSpeed = 15f;
    public float jumpForce = 10f;
    public Camera fpCamera;

    //player references
    Transform playerTF;
    Rigidbody playerRb;

    //Check if grounded
    public bool isGrounded = true;
    private float hitDistance = 10.5f;
    public LayerMask isGroundedlayer;

    //Animator
    public Animator camAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerTF = this.gameObject.GetComponent<Transform>();
        playerRb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.W)) //walk forward
        {
            playerTF.position += playerTF.forward * walkSpeed * Time.deltaTime;
            camAnimator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.A)) // walk left
        {
            playerTF.position -= playerTF.right * walkSpeed * Time.deltaTime;
            camAnimator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.S)) //walk backwards
        {
            playerTF.position -= playerTF.forward * walkSpeed * Time.deltaTime;
            camAnimator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.D)) // walk right
        {
            playerTF.position += playerTF.right * walkSpeed * Time.deltaTime;
            camAnimator.SetBool("isWalking", true);
        }
        if (!Input.anyKey)
        {
            camAnimator.SetBool("isWalking", false);
        }


        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)) // Jump
        {
            playerTF.position += playerTF.forward * runSpeed * Time.deltaTime;
            camAnimator.SetBool("isRunning", true);
            camAnimator.SetBool("isWalking", false);
        }
        else
        {
            camAnimator.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(playerTF.up * jumpForce, ForceMode.Impulse);
        }
        if(Physics.Raycast(transform.position - new Vector3(0,0.85f,0), -Vector3.up, hitDistance, isGroundedlayer)){
            isGrounded = true;
            camAnimator.SetBool("Jump", false);
        }
        else
        {
            isGrounded = false;
            camAnimator.SetBool("Jump", true);
        }
        

    }
    
}
