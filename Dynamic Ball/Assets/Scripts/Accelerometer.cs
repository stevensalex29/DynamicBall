using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour{
    
    public float speed = 10.0f;
    Rigidbody rb;
    GameObject startButton;
    float xStart = 0, zStart = 0;
    float horz = 0, vert = 0;
    GameObject goal;

    // Start is called before the first frame update
    void Start(){
        goal = GameObject.Find("PlayerBall").GetComponent<CollectRing>().getGoal();
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
            rb.AddForce(acc * speed);
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

        else if (col.gameObject.tag == "DeathBox")
        {
            goal.SetActive(false);
            //Reset position and rotation
            gameObject.transform.SetPositionAndRotation(GameObject.Find("StartPosition").transform.position, Quaternion.identity);

            //Reset rings and ring counter
            GameObject[] rings = gameObject.GetComponent<CollectRing>().getAllRings();
            for (int i = 0; i < rings.Length; i++)
            {
                rings[i].SetActive(true);
            }
            gameObject.GetComponent<CollectRing>().setCoinCounter(0);

            //Reset movement
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void Calibration()
    {
        xStart = Input.acceleration.x;
        zStart = Input.acceleration.z;
    }
}
