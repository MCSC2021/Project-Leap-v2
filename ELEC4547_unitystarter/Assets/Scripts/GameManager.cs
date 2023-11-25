using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startplaying;

    public NodeMovement theNM;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

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
        currentScore += scorePerNote;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
