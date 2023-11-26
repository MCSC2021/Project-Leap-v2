using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if(transform.position.z > 0.1 || transform.position.z < -0.1)
                {
                    GameManager.instance.NormalHit();
                }
                else if (transform.position.z > 0.05 || transform.position.z < -0.05)
                {
                    GameManager.instance.GoodHit();
                }
                else if (transform.position.z > 0.025 || transform.position.z < -0.025)
                {
                    GameManager.instance.PerfectHit();
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
