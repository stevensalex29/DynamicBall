using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour
{
    GameObject startButton;
    float distToGround; // to prevent mid-air jumping

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("Start");
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 ) && !startButton.activeSelf && IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
        }
    }

    // Raycast downwards to check if the ground is below the object
    bool IsGrounded()
    {
        //game object position, direction of raycast, max distance to ground + 0.1 to account for variation
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    public void OnPointerDown(BaseEventData eventData)
    {
        if (!startButton.activeSelf && IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        }
    }
}
