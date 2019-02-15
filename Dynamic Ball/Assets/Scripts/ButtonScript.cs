using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start the game
    public void StartGame() {
        GameObject.FindGameObjectWithTag("StartLine").SetActive(false);
        gameObject.SetActive(false);
        GameObject.Find("Restart").SetActive(true);
        GameObject.Find("HowToText").SetActive(false);
        GameObject.Find("RestartText").SetActive(false);
        GameObject.Find("StartText").SetActive(false);
        GameObject.Find("Background").SetActive(false);
    }

    // Restart the game
    public void RestartGame()
    {
        GameObject.Find("PlayerBall").transform.SetPositionAndRotation(new Vector3(0.5762594f, 9.607f, -11.205f), Quaternion.identity);
        GameObject.Find("Start").SetActive(true);
        GameObject.Find("HowToText").SetActive(true);
        GameObject.Find("RestartText").SetActive(true);
        GameObject.Find("StartText").SetActive(true);
        GameObject.Find("Background").SetActive(true);
        GameObject.FindGameObjectWithTag("StartLine").SetActive(true);
        gameObject.SetActive(false);
    }
}
