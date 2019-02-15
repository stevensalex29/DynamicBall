using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour{

    public float speed = 10.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){

        Vector3 acc = Input.acceleration;

        rb.AddForce(acc.x * speed, 0, acc.y * speed);
    }
}
