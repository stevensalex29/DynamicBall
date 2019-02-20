﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        startButton.SetActive(true);
        HowToText.SetActive(true);
        RText.SetActive(true);
        StartText.SetActive(true);
        Background.SetActive(true);
    }
}
