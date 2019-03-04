using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRing : MonoBehaviour
{
    private int coinCounter;
    private int tRings;
    private GameObject[] rings;
    private GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = 0;
        // set goal object
        goal = GameObject.FindGameObjectWithTag("Goal");
        goal.SetActive(false);
        // get total rings of level
        tRings = GameObject.FindGameObjectsWithTag("Ring").Length;
        // set initial ring display
        GameObject.Find("CoinCounter").GetComponent<UnityEngine.UI.Text>().text = "Rings: " + coinCounter.ToString() + "/" + tRings;
        // get ring objects
        rings = GameObject.FindGameObjectsWithTag("Ring");

    }

    // Update is called once per frame
    void Update()
    {
        if(coinCounter == tRings / 2)
        {
            goal.SetActive(true);
        }
    }

    // Get the goal object
    public GameObject getGoal()
    {
        return goal;
    }

    // Set the coin counter
    public void setCoinCounter(int t)
    {
        coinCounter = t;
        GameObject.Find("CoinCounter").GetComponent<UnityEngine.UI.Text>().text = "Rings: " + coinCounter.ToString() + "/" + tRings;
    }

    // Returns all coins of current level
    public GameObject[] getAllRings()
    {
        return rings;
    }

    // Get coin counter
    public int getRings()
    {
        return coinCounter;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ring")
        {
            collision.gameObject.SetActive(false);
            coinCounter++;
            GameObject.Find("CoinCounter").GetComponent<UnityEngine.UI.Text>().text = "Rings: " + coinCounter.ToString() + "/" + tRings;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ring") {
            Destroy(collision.gameObject);
            coinCounter++;
            GameObject.Find("CoinCounter").GetComponent<UnityEngine.UI.Text>().text = "Rings: " + coinCounter.ToString() + "/" + tRings;
        }
    }
}
