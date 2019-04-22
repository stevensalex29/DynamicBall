using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlockInfo : MonoBehaviour
{
    public Vector3 startPos;
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        }
    }
}
