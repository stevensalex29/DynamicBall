using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMoveScript : MonoBehaviour
{
    Rigidbody rgbd;
    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translateHorz = Input.GetAxis("Horizontal") * speed;
        float translateVert = Input.GetAxis("Vertical") * speed;

        rgbd.AddForce(translateHorz, 0, translateVert);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Goal")
        {
            col.gameObject.SetActive(false);
        }
    }
}
