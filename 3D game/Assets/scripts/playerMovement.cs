using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine
public class playerMovement : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 2f;
    public float jumpForce = 6f;

    public int score = 0;

    public Boolean onFloor;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.Space) && onFloor == true)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "chest")
        {
            score++;
            gameManager.Instance.Score++;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "opp")
        {
            score--;
            gameManager.Instance.Score--;
            Destroy(gameObject);
            SceneManager.LoadScene("won");
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") { onFloor = true; }
    }

    void OnCollisionExit(Collision collision)
    {
        onFloor = false;
    }

}
