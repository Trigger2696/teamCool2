using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    
    public Text text;
    private int score=0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ////void OnCollisionEnter(Collision collision)
        //{
        //    //string name = collision.collider.name;
        //        if(collision.collider.tag == "PickUp"){
        //        Destroy(collision.collider.gameObject);
        //    }

    

        }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Pick Up")
        {
            score++;
            text.text = score.ToString();
            Destroy(collider.gameObject);


        }
    }

    

}

