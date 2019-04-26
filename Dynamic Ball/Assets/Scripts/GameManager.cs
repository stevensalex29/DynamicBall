using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Attributes
    private List<string> levels;
    private int currentLevel;
    private int totalRings;
    private string levelStats;
    private int maxRings;
    private string sName;
    public bool next;
    

    // Use this for initialization
    void Start()
    {
        levels = new List<string> {"TutorialScene","RegularTutorial1", "RegularTutorial2","RegularTutorial3","PushTutorial1","PushTutorial2","MoveTutorial1","MoveTutorial2","RotateTutorial1","RotateTutorial2","RoadBlocks"};
        Scene currentScene = SceneManager.GetActiveScene(); //reset playerPrefs if at starting level
        string sceneName = currentScene.name;
        sName = sceneName;
        maxRings = GameObject.FindGameObjectsWithTag("Ring").Length;

        // set current level player prefs
        if (sceneName == "TutorialScene")
        {
            PlayerPrefs.SetInt("currentLevel", 0);
        }
        if (PlayerPrefs.HasKey("currentLevel"))
            currentLevel = PlayerPrefs.GetInt("currentLevel"); //setup current level in playerprefs

        // set total rings player prefs
        if (PlayerPrefs.HasKey("totalRings"))
            totalRings = PlayerPrefs.GetInt("totalRings"); //setup current level in playerprefs
        else
            PlayerPrefs.SetInt("totalRings", 0);

        // create stat pref automatically
        string pref = sceneName + "Stats";
        if (PlayerPrefs.HasKey(pref))
            levelStats = PlayerPrefs.GetString(pref); //setup current level in playerprefs

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

        // if level has already been played, update ring count
        if (levelStats != null)
        {
            string[] split = levelStats.Split(new string[] { "/" }, System.StringSplitOptions.None);
            int pastRings = int.Parse(split[0]);
            if(rings > pastRings)
            {
                string pref = rings + "/" + maxRings;
                int t = (total - pastRings) + rings;
                PlayerPrefs.SetString(sName + "Stats", pref);
                PlayerPrefs.SetInt("totalRings", t);
            }   
        }
        else // otherwise, do first ring add
        {
            string pref = rings + "/" + maxRings;
            int t = total + rings;
            PlayerPrefs.SetString(sName + "Stats", pref);
            PlayerPrefs.SetInt("totalRings", t);
        }


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
