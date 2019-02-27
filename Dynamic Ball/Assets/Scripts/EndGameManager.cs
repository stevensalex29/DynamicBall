using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Rings").GetComponent<Text>().text = "You Collected " + PlayerPrefs.GetInt("totalRings") + " rings!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
