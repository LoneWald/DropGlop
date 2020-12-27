using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;

    public Vector3 startPos = new Vector3(0, 0, 0);
    public bool collisiya;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hoverHorizontal = Input.GetAxis("Horizontal");
        float hoverVertcal = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hoverHorizontal, 0.0f, hoverVertcal);

        rb.AddForce(movement * speed);

        if(Input.GetButton("Cancel"))
            SceneManager.LoadScene(0);
        if (Input.GetKey("r")){
            transform.position = startPos;
            transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            rb.velocity = Vector3.zero;
         }
        if (collisiya == true)
        {
            count++;
            if (count > 3){
            collisiya = false; 
            count = 0;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "res")
        {
            transform.position = startPos;
            transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            rb.velocity = Vector3.zero;
            collisiya = true;
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(2);
        }
    }
}
