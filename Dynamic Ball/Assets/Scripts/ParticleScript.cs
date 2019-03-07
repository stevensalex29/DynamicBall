using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    GameManager gameManager;
    GameObject goal;

    public bool playParticle = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        if (playParticle)
        {
            gameObject.transform.position = goal.transform.position;
            gameObject.GetComponent<ParticleSystem>().Play();
            playParticle = false;
        }
    }
}
