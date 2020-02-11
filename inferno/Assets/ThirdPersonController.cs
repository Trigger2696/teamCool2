using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public float speed;
    public float slopeForce;
    public float slopeForceRayLength;
    public float jumpForce = 10f;
    /*float gravity = -9.81f;*/
    //Update is called once per frame
    public Rigidbody rb;
    public CapsuleCollider col;

    public LayerMask groundLayer;

    void Update()
    {
        PlayerMovement();        
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");


        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (onSlope())
        {
            transform.Translate(Vector3.down, Space.Self);

            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                
            }*/
        }
    }
    private bool onSlope()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, slopeForceRayLength))
            if (hit.normal != Vector3.up)
                return true;

        return false;
    }

    private bool isGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, slopeForceRayLength))
        {
            if (hit.collider != null)
                return true;
        }
        return false;
    }
}
