using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //Attributes
    GameObject startButton;
    GameObject HowToText;
    GameObject RText;
    GameObject StartText;
    GameObject Background;
    GameObject restartButton;
    GameObject PlayerBall;
    Vector3 startPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Menu")
        {
            
        }
        else
        {
            // Initialize variables
            startButton = GameObject.Find("Start");
            HowToText = GameObject.Find("HowToText");
            RText = GameObject.Find("RText");
            StartText = GameObject.Find("SText");
            Background = GameObject.Find("Background");
            restartButton = GameObject.Find("Restart");
            PlayerBall = GameObject.Find("PlayerBall");
            startPosition = GameObject.Find("StartPosition").transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start the game
    public void StartGame() {
        // Set starting items as false
        gameObject.SetActive(false);
        HowToText.SetActive(false);
        RText.SetActive(false);
        StartText.SetActive(false);
        Background.SetActive(false);
    }

    // Restart the game
    public void RestartGame()
    {
        // Set starting items as true, move ball back
        PlayerBall.transform.SetPositionAndRotation(startPosition, Quaternion.identity);

        // Reset rings
        GameObject[] rings = GameObject.Find("PlayerBall").GetComponent<CollectRing>().getAllRings();
        for(int i = 0; i < rings.Length; i++)
        {
            rings[i].SetActive(true);
        }

        GameObject.Find("PlayerBall").GetComponent<CollectRing>().setCoinCounter(0);


        // Reset UI
        startButton.SetActive(true);
        HowToText.SetActive(true);
        RText.SetActive(true);
        StartText.SetActive(true);
        Background.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void HowTo()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
