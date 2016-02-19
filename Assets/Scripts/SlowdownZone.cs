using UnityEngine;
using System.Collections;

public class SlowdownZone : MonoBehaviour {

    public float slowedTimeScale;
    public GameObject tutorial;
	// Use this for initialization
	void Start () {
        tutorial.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = slowedTimeScale;
            ShowTutorial();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = 1f;
            HideTutorial();
        }
    }

    void ShowTutorial()
    {
        tutorial.SetActive(true);
    }

    void HideTutorial()
    {
        tutorial.SetActive(false);
    }
}
