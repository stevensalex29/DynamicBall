using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour{
    
    float speed = 15.0f;
    float maxSpeed = 8.0f;
    Rigidbody rb;
    GameObject startButton;
    float xStart = 0, zStart = 0;
    float horz = 0, vert = 0;
    GameObject goal;

    private void Awake()
    {
        goal = GameObject.Find("PlayerBall").GetComponent<CollectRing>().getGoal();
        rb = GetComponent<Rigidbody>();
        startButton = GameObject.Find("Start");
    }

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){
        if (!startButton.activeSelf)
        {
            horz = Input.acceleration.x; // - xStart;
            vert = -Input.acceleration.z + zStart;

            Vector3 acc = new Vector3(horz, 0, vert);
            rb.AddForce(acc * speed);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    // Collide with goal and call next level
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Goal")
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            GameObject.Find("Win").GetComponent<ParticleScript>().playParticle = true;
            gameObject.GetComponent<CollectRing>().activeGoal = false;
            //GameObject.Find("GameManager").GetComponent<GameManager>().nextLevel();
            GameObject.Find("GameManager").GetComponent<GameManager>().next = true;
            col.gameObject.SetActive(false);
        }

        else if (col.gameObject.tag == "DeathBox")
        {
            if(goal == null) goal = GameObject.Find("PlayerBall").GetComponent<CollectRing>().getGoal();
            rb = GetComponent<Rigidbody>();
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

            //Reset blocks if any exist in the scene
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
            for(int i = 0; i < blocks.Length; i++)
            {
                blocks[i].transform.position = blocks[i].GetComponent<PushBlockInfo>().startPos;
            }

            //Reset movement
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void Calibration()
    {
        //xStart = Input.acceleration.x;
        zStart = Input.acceleration.z;
    }
}
