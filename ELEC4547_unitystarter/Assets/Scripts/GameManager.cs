using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startplaying;

    public NodeMovement theNM;
    public ReadUSB IMU;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public int currentMultipler;
    public int multiplerTracker;
    public int[] multiplerThresholds;

    // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI MultiplerText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultipler = 1;
        MultiplerText.text = "Multipler: 1x";
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
        if(currentMultipler -1 < multiplerThresholds.Length)
        {
            multiplerTracker++;
            if (multiplerThresholds[currentMultipler - 1] <= multiplerTracker)
            {
                multiplerTracker = 0;
                currentMultipler++;
                MultiplerText.text = "Multipler: " + currentMultipler + "x";
            }
        }
        
        currentScore += scorePerNote * currentMultipler;
        UpdateScoreText();
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        currentMultipler = 1;
        multiplerTracker = 0;
        MultiplerText.text = "Multipler: " + currentMultipler + "x";
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

}
