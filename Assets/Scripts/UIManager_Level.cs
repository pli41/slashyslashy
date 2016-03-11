using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager_Level : MonoBehaviour {

    public GameObject winUI;
    public GameObject loseUI;
    public GameObject endGameUI;
    public Image tutorialBtn;
    public GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        InitializeTutorial();
    }
	
	// Update is called once per frame
	void Update () {
        //HandleTutorial();
	}

    public void ShowEndPanel(bool win)
    {
        InitializeTutorial();
        endGameUI.SetActive(true);
        if (win)
        {
            if (LevelManager.currentLevel.Equals("Level_3"))
            {
                winUI.transform.Find("NextLevelButton").gameObject.SetActive(false);
            }
            winUI.SetActive(true);
            loseUI.SetActive(false);
            winUI.GetComponent<RectTransform>().Find("NextLevelButton").GetComponent<Button>().Select();
        }
        else
        {
            winUI.SetActive(false);
            loseUI.SetActive(true);
            loseUI.GetComponent<RectTransform>().Find("RetryButton").GetComponent<Button>().Select();
        }
    }

    public void InitializeTutorial()
    {
        if (LevelManager.currentLevel == "Level_1")
        {
            tutorialBtn.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("Tutorial") == 1)
            {
                tutorialBtn.color = Color.green;
            }
            else
            {
                tutorialBtn.color = Color.red;
            }
            gm.SetTimeSlowZones();
        }
        
    }

    public void HandleTutorial()
    {
        Debug.Log("handle tutorial");
        if (LevelManager.currentLevel == "Level_1")
        {
            tutorialBtn.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("Tutorial") == 0)
            {
                PlayerPrefs.SetInt("Tutorial", 1);
                tutorialBtn.color = Color.green;
                //ColorBlock cb = tutorialBtn.colors;
                //cb.normalColor = Color.green;
                //tutorialBtn.colors = cb;
            }
            else
            {
                PlayerPrefs.SetInt("Tutorial", 0);
                tutorialBtn.color = Color.red;

                //ColorBlock cb = tutorialBtn.colors;
                //cb.normalColor = Color.red;
                //tutorialBtn.colors = cb;
            }

            gm.SetTimeSlowZones();
        }
        else
        {
            tutorialBtn.gameObject.SetActive(false);
        }
    }
}
