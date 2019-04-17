using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public float stopTime;
    public float moveSpeed;
    public float xDistance;
    public float yDistance;
    public float zDistance;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 stopPosition;
    private bool stopped;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        endPosition = new Vector3(startPosition.x + xDistance, startPosition.y + yDistance, startPosition.z + zDistance);
        stopPosition = endPosition;
        stopped = false;
        currentTime = stopTime;
    }

    // Update is called once per frame
    void Update()
    {
        // move platform towards destination
        if(gameObject.transform.position != stopPosition)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, stopPosition, moveSpeed * Time.deltaTime);
        }
        else // stop moving when at destination
        {
            stopped = true;
        }

        // decrement timer while stopped
        if (stopped)
        {
            currentTime -= Time.deltaTime;
            // when timer hits zero, reset attributes, toggle stop position for platform to move to
            if(currentTime <= 0)
            {
                currentTime = stopTime;
                stopped = false;
                if (stopPosition == endPosition) stopPosition = startPosition;
                else stopPosition = endPosition;
            }
        }
            
        
    }
}
