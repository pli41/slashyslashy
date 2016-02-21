using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public UIManager_Level UIManager;

    public Rigidbody2D playerRigid;
    public AudioSource BGM;

    public AudioClip win;

    public float timeLimit;
    public int timeLeft;

    public bool timeUp;
    public bool isMainMenu;

    public bool endGame;

    private float timer;
    
	// Use this for initialization
	void Start () {
        endGame = false;
        playerRigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!isMainMenu && !endGame)
        {
            CheckPlayerExist();
            timeLeft = (int)(timeLimit - timer);

            if (timeLeft > 0)
            {
                if (!endGame)
                {
                    timer += Time.deltaTime;
                }
                
            }
            else
            {
                Endgame(false);
            }
        }
        
	}

    void FixedUpdate()
    {

    }

    public void SetTimeSlowZones()
    {
        Debug.Log("Set timeslow zone");
        GameObject[] slowzones = GameObject.FindGameObjectsWithTag("Slowzone");
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            foreach (GameObject slowzone in slowzones)
                slowzone.SetActive(false);
        }
        else
        {
            foreach (GameObject slowzone in slowzones)
                slowzone.SetActive(true);
        }
    }

    public void CheckPlayerExist()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.Log("player not exist");
            Endgame(false);
        }
    }

    public void Endgame(bool win)
    {
        endGame = true;
        UIManager.ShowEndPanel(win);
    }


    public void LoadNextLevel()
    {
        string currentLevel = LevelManager.currentLevel;
        Debug.Log(currentLevel);
        int levelNum = int.Parse(currentLevel[currentLevel.Length - 1].ToString()) + 1;
        Debug.Log(levelNum);
        string newLevel = currentLevel.Remove(currentLevel.Length-1, 1) + levelNum.ToString();
        LevelManager.currentLevel = newLevel;
        SceneManager.LoadScene(newLevel);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(LevelManager.currentLevel);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
