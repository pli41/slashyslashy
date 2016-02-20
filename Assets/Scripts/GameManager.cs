using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Rigidbody2D playerRigid;
    public AudioSource BGM;

    public AudioClip win;

    public float timeLimit;
    public int timeLeft;

    public bool timeUp;
    public bool isMainMenu;

    private float timer;
	// Use this for initialization
	void Start () {
        
        playerRigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        


        timeLeft = (int)(timeLimit - timer);

        if (timeLeft > 0)
        {
            timer += Time.deltaTime;
        }
        else
        {
            
        }
	}

    void FixedUpdate()
    {

    }

    public void Win()
    {
        BGM.Stop();
        BGM.PlayOneShot(win);
        Invoke("LoadNextLevel", 2f);
    } 

    void LoadNextLevel()
    {
        string currentLevel = LevelManager.currentLevel;
        Debug.Log(currentLevel);
        int levelNum = int.Parse(currentLevel[currentLevel.Length - 1].ToString()) + 1;
        Debug.Log(levelNum);
        string newLevel = currentLevel.Remove(currentLevel.Length-1, 1) + levelNum.ToString();
        SceneManager.LoadScene(newLevel);
    }
}
