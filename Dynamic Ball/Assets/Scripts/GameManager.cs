using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Attributes
    private List<string> levels;
    private int currentLevel;
    
    // Use this for initialization
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene(); //reset playerPrefs if at starting level
        string sceneName = currentScene.name;
        //if (sceneName == "Level1Tutorial")
        //{
        //    PlayerPrefs.DeleteAll();
        //}

        if (PlayerPrefs.HasKey("currentLevel"))
            currentLevel = PlayerPrefs.GetInt("currentLevel"); //setup current level in playerprefs
        else
            PlayerPrefs.SetInt("currentLevel", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Loads the next level scene
    public void nextLevel()
    {
        currentLevel++;
    
        if (currentLevel == levels.Count)
        {
            PlayerPrefs.SetInt("currentLevel", 0);
        }

        else
        {
            PlayerPrefs.SetInt("currentLevel", currentLevel);
            SceneManager.LoadScene(levels[currentLevel]);
        }
    }
}
