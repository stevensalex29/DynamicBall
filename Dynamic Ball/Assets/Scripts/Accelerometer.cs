using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour{
    
    public float speed = 10.0f;
    Rigidbody rb;
    GameObject startButton;
    float xStart = 0, zStart = 0;
    float horz = 0, vert = 0;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        startButton = GameObject.Find("Start");
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){

        if (!startButton.activeSelf)
        {
            horz = Input.acceleration.x - xStart;
            vert = -Input.acceleration.z + zStart;

            Vector3 acc = new Vector3(horz, 0, vert);
            rb.AddForce(acc * 10.0f);
            //rb.AddForce(acc.x * speed, 0, acc.y * speed);
        }else
        {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    // Collide with goal and call next level
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Goal")
        {
            col.gameObject.SetActive(false);
            GameObject.Find("GameManager").GetComponent<GameManager>().nextLevel();
        }
    }

    public void Calibration()
    {
        xStart = Input.acceleration.x;
        zStart = Input.acceleration.z;
    }
}
