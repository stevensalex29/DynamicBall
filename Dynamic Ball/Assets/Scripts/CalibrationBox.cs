using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationBox : MonoBehaviour
{
    GameObject calibBox;

    // Start is called before the first frame update
    void Start()
    {
        calibBox = GameObject.Find("CalibBox");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.z > -0.7f && Input.acceleration.z < -0.2f)
        {
            calibBox.GetComponent<Image>().color = Color.green;
        }
        else
        {
            calibBox.GetComponent<Image>().color = Color.red;
        }
    }

    void FixedUpdate()
    {
        //Debug.Log(Input.acceleration.z);
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-Input.acceleration.z * 200.0f, -130.0f, 0.0f);
    }
}
