using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatforms : MonoBehaviour
{
    public float degreesPerSecondX;
    public float degreesPerSecondY;
    public float degreesPerSecondZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(degreesPerSecondX * Time.deltaTime, degreesPerSecondY * Time.deltaTime, degreesPerSecondZ * Time.deltaTime));
    }
}
