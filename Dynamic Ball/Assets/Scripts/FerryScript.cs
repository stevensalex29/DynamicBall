﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerryScript : MonoBehaviour
{
    MovePlatforms movePlatforms;
    // Start is called before the first frame update
    void Start()
    {
        movePlatforms = gameObject.GetComponent<MovePlatforms>();
        movePlatforms.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "PlayerBall")
        {
            movePlatforms.enabled = true; ;
        }
    }
}