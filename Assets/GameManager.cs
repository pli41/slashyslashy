using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float timeLimit;
    public float timeLeft;

    public bool timeUp;

    private float timer;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft = timeLimit - timer;

        if (timeLeft > 0)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
	}
}
