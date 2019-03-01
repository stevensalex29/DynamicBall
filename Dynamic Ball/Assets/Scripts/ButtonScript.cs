using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //Attributes
    GameObject startButton;
    GameObject RText;
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

        if (sceneName == "Menu" || sceneName == "HowToPlay" || sceneName == "EndGame")
        {
            
        }
        else
        {
            // Initialize variables
            startButton = GameObject.Find("Start");
            RText = GameObject.Find("RText");
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
        RText.SetActive(false);
        Background.SetActive(false);
    }

    // Restart the game
    public void RestartGame()
    {
        // Set starting items as true, move ball back
        PlayerBall.transform.SetPositionAndRotation(startPosition, Quaternion.identity);
        PlayerBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        PlayerBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        // Reset rings
        GameObject[] rings = GameObject.Find("PlayerBall").GetComponent<CollectRing>().getAllRings();
        for(int i = 0; i < rings.Length; i++)
        {
            rings[i].SetActive(true);
        }

        PlayerBall.GetComponent<CollectRing>().setCoinCounter(0);


        // Reset UI
        startButton.SetActive(true);
        RText.SetActive(true);
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
        Debug.Log("Test button end scene");
        Application.Quit();
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
