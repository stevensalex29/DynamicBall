using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRing : MonoBehaviour
{
    private int coinCounter;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = 0;
        GameObject.Find("CoinCounter").GetComponent<UnityEngine.UI.Text>().text = "Rings: " + coinCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ring")
        {
            Destroy(collision.gameObject);
            coinCounter++;
            GameObject.Find("CoinCounter").GetComponent<UnityEngine.UI.Text>().text = "Coins: " + coinCounter.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ring") {
            Destroy(collision.gameObject);
            coinCounter++;
            GameObject.Find("CoinCounter").GetComponent<UnityEngine.UI.Text>().text = "Coins: " + coinCounter.ToString();
        }
    }
}
