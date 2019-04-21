﻿using System.Collections;
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
    GameObject goal;
    GameObject calibration;
    

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
            goal = GameObject.Find("PlayerBall").GetComponent<CollectRing>().getGoal();
            startButton = GameObject.Find("Start");
            RText = GameObject.Find("RText");
            Background = GameObject.Find("Background");
            restartButton = GameObject.Find("Restart");
            PlayerBall = GameObject.Find("PlayerBall");
            startPosition = GameObject.Find("StartPosition").transform.position;
            calibration = GameObject.Find("Calibration");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start the game
    public void StartGame() {
        // Set starting items as false
#if UNITY_EDITOR
        gameObject.SetActive(false);
        RText.SetActive(false);
        Background.SetActive(false);
        calibration.SetActive(false);

#elif UNITY_ANDROID
        if (Input.acceleration.z > -0.7f && Input.acceleration.z < -0.2f) //Only starts the game if player holds the phone correctly
        {
            gameObject.SetActive(false);
            RText.SetActive(false);
            Background.SetActive(false);
            calibration.SetActive(false);
        }
#endif

    }

    // Restart the game
    public void RestartGame()
    {
        if (goal != null)
        {
            goal.SetActive(false);
        }
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

        //Reset blocks if any exist in the scene
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].transform.position = blocks[i].GetComponent<PushBlockInfo>().startPos;
        }


        // Reset UI
        startButton.SetActive(true);
        RText.SetActive(true);
        Background.SetActive(true);
        calibration.SetActive(true);
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
