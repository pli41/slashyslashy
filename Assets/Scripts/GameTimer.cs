using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {

    public GameManager gm;
    public Text timerText;
    public PlayerController player; 

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timerText.text = gm.timeLeft.ToString();

	}

    void CheckPlayer()
    {
        if (!player)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
