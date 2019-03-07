﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Attributes
    private List<string> levels;
    private int currentLevel;
    private int totalRings;
    public bool next;

    // Use this for initialization
    void Start()
    {
        levels = new List<string> {"TutorialScene","Level2","Level3","Level4","Level5","Level6","Level7", "Level8"};
        Scene currentScene = SceneManager.GetActiveScene(); //reset playerPrefs if at starting level
        string sceneName = currentScene.name;
        if (sceneName == "TutorialScene")
        {
            PlayerPrefs.DeleteAll();
        }

        if (PlayerPrefs.HasKey("currentLevel"))
            currentLevel = PlayerPrefs.GetInt("currentLevel"); //setup current level in playerprefs
        else
            PlayerPrefs.SetInt("currentLevel", 0);

        if (PlayerPrefs.HasKey("totalRings"))
            totalRings = PlayerPrefs.GetInt("totalRings"); //setup current level in playerprefs
        else
            PlayerPrefs.SetInt("totalRings", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (next)
        {
            Invoke("nextLevel", 4.0f);
            next = false;
        }
    }

    // Loads the next level scene
    public void nextLevel()
    {
        // set total rings
        int rings = GameObject.Find("PlayerBall").GetComponent<CollectRing>().getRings();
        int total = PlayerPrefs.GetInt("totalRings");
        int t = total + rings;
        PlayerPrefs.SetInt("totalRings",t);

        currentLevel++;
          
        if (currentLevel == levels.Count)
        {
            PlayerPrefs.SetInt("currentLevel", 0);
            SceneManager.LoadScene("EndGame");
        }else
        {
            PlayerPrefs.SetInt("currentLevel", currentLevel);
            SceneManager.LoadScene(levels[currentLevel]);
        }
    }
}
