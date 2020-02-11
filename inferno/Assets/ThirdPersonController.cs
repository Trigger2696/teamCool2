using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    
    public float speed;
    public float slopeForce;
    public float slopeForceRayLength;
    /*public float jumpForce = 10f;*/
    //Update is called once per frame
    
    
    void Update()
    {
        PlayerMovement();        
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

       
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        //transform.Translate(playerMovement, Space.Self);
        transform.position += new Vector3(hor, ver);
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 playerJump = new Vector3(0f, 1f, 0f) * jumpForce * Time.deltaTime;
            transform.Translate(playerJump, Space.Self);
        }*/
        if (onSlope())
        {
            transform.Translate(Vector3.down, Space.Self);   
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
}
