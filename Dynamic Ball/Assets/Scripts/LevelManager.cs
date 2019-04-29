using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 14; i++)
        {
            string name = GameObject.FindGameObjectWithTag(i.ToString()).name;
            if(PlayerPrefs.HasKey(name + "Stats")){
                GameObject.Find(name + "Stats").GetComponent<Text>().text = PlayerPrefs.GetString(name + "Stats") + " Rings";
            }
            else
            {
                GameObject.Find(name + "Stats").GetComponent<Text>().text = "";
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
