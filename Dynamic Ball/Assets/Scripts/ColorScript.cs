using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    public int red;
    public int green;
    public int blue;

    public Material mat;

    private GameObject[] objectList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (red < 255) {
            red = 255;
        }
        if (green < 255)
        {
            green = 255;
        }
        if (blue < 255)
        {
            blue = 255;
        }


        objectList = GameObject.FindGameObjectsWithTag("changeColor");

        for (int i = 0; i < objectList.Length; i++) {
            objectList[i].GetComponent<Renderer>().material = mat;
        }

        ParticleSystem.MainModule color = GameObject.Find("Win").GetComponent<ParticleSystem>().main;
        color.startColor = new Color(1 - mat.color.r, 1 - mat.color.g, 1 - mat.color.b, 1);
    }
}
