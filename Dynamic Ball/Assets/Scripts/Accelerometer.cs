using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour{

    public float speed = 10.0f;
    Rigidbody rb;
    GameObject startButton;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        startButton = GameObject.Find("Start");
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){

        Vector3 acc = Input.acceleration;

        if (!startButton.activeSelf)
        {
            rb.AddForce(acc.x * speed, 0, acc.y * speed);
        }else
        {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
       
    }
}
