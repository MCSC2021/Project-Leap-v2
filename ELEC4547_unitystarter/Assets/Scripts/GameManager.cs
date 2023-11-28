using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startplaying;

    public NodeMovement theNM;
    public ReadUSB IMU;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public bool[] Ispressing = { false, false, false, false, false };
    
    public int scorePerPerfectNote = 150;

    public int currentMultipler;
    public int multiplerTracker;
    public int[] multiplerThresholds;

    public GameObject NormalPS, GoodPS, PerfectPS;

    // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI MultiplerText;
    public TextMeshProUGUI ComboText;

    public float combo;
    public float totalNotes;
    public float normalNotes;
    public float goodNotes;
    public float perfectNotes;
    public float missNotes;
    float percentage = 0f;
    public GameObject resultsScreen;
    public TextMeshProUGUI percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    public String state;
    public NodeObject[] nodeObjects;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultipler = 1;
        MultiplerText.text = "Multipler: 1x";
        combo = 0;
        totalNotes = FindObjectsOfType<NodeObject>().Length;
        nodeObjects = FindObjectsOfType<NodeObject>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state){
            case "Start":
                resultsScreen.SetActive(false);
                normalNotes = 0; combo = 0; goodNotes = 0; perfectNotes = 0; missNotes = 0; currentMultipler = 1; currentScore = 0; percentage = 0f;
                break;
            case "Play":
                if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
                {
                    resultsScreen.SetActive(true);
                    normalsText.text = normalNotes.ToString();
                    goodsText.text = goodNotes.ToString();
                    perfectsText.text = perfectNotes.ToString();
                    missesText.text = missNotes.ToString();

                    percentHitText.text = percentage.ToString("F1") + "%";

                    string rankVal = "F";
                    if (percentage > 40)
                    {
                        rankVal = "D";
                        if (percentage > 55)
                        {
                            rankVal = "C";
                            if (percentage > 70)
                            {
                                rankVal = "B";
                                if (percentage > 85)
                                {
                                    rankVal = "A";
                                    if (percentage > 95)
                                    {
                                        rankVal = "S";
                                        if (percentage == 100)
                                        {
                                            rankVal = "SSS";

                                        }
                                    }

                                }
                            }
                        }
                    }

                    rankText.text = rankVal;

                    finalScoreText.text = currentScore.ToString();
                    startplaying = false;
                }
                break;
            default:
                startplaying = false;
                break;
        }
    }

    public void NoteHit()
    {
        combo++;
        if (currentMultipler -1 < multiplerThresholds.Length)
        {
            multiplerTracker++;
            if (multiplerThresholds[currentMultipler - 1] <= multiplerTracker)
            {
                multiplerTracker = 0;
                currentMultipler++;
                MultiplerText.text = "Multipler: " + currentMultipler + "x";
            }
        }
        
        UpdateScoreText();
        UpdateCombo();
    }

    private void UpdateCombo()
    {
        ComboText.text = combo.ToString() + " Combo";
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void NormalHit(Vector3 hitPosition)
    {
        currentScore += scorePerNote * currentMultipler;
        percentage += 0.3f * 100 / totalNotes;
        NoteHit();
        SpwanPS(hitPosition, NormalPS);
        normalNotes++;
    }

    public void GoodHit(Vector3 hitPosition)
    {
        currentScore += scorePerGoodNote * currentMultipler;
        percentage += 0.6f * 100 / totalNotes;
        NoteHit();
        SpwanPS(hitPosition, GoodPS);
        goodNotes++;
    }

    public void PerfectHit(Vector3 hitPosition)
    {
        currentScore += scorePerPerfectNote * currentMultipler;
        percentage +=  100 / totalNotes;
        NoteHit();
        SpwanPS(hitPosition, PerfectPS);
        perfectNotes++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        currentMultipler = 1;
        multiplerTracker = 0;
        combo = 0;
        MultiplerText.text = "Multipler: " + currentMultipler + "x";
        missNotes++;
        UpdateCombo();
    }

    private void SpwanPS(Vector3 position, GameObject itemToSpawn)
    {
        Instantiate(itemToSpawn, position, Quaternion.identity);
    }

    public void HandPress(int i)
    {
        Ispressing[i-1] = true;
    }
    public void HandRelease(int i)
    {
        Ispressing[i-1] = false;
    }

    public void Startplay()
    {
        startplaying = true;
        theNM.hasStarted = true;
        theMusic.Play();
        state = "Play";
    }

    public void ReStartplay()
    {
        startplaying = false;
        theNM.hasStarted = false;
        state = "Start";
        
        foreach (NodeObject nodeObject in nodeObjects)
        {
            nodeObject.Reset();
        }
    }
}
