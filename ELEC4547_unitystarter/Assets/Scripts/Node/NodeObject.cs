using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public int Line;
    // Start is called before the first frame update
    void Start()
    {
        float xPos = transform.position.x;
        int Line = PositionUtility.CalculatePositionValue(xPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.Ispressing[Line])
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.z) > 0.1f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit(transform.position);
                }
                else if (Mathf.Abs(transform.position.z) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit(transform.position);
                }
                else if (transform.position.z > 0.025 || transform.position.z < -0.025)
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit(transform.position);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
        }
    }
}
