using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlockInfo : MonoBehaviour
{
    public Vector3 startPos;
    public float maxX, maxY, maxZ;
    public bool checkX, checkY, checkZ;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // prevents blocks from getting stuck in places they shouldn't / the player from going under them
        if(checkX && transform.position.x < maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }

        if (checkY && transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }

        if (checkZ && transform.position.z > maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        }
    }
}
