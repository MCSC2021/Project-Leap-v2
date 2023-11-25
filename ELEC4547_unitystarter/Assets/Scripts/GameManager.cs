using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startplaying;

    public NodeMovement theNM;

    public static GameManager instance;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startplaying)
        {
            if (Input.anyKeyDown)
            {
                startplaying = true;
                theNM.hasStarted = true;

                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
