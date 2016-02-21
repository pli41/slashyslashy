using UnityEngine;
using System.Collections;

public class UIManager_Level : MonoBehaviour {

    public GameObject winUI;
    public GameObject loseUI;
    public GameObject endGameUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowEndPanel(bool win)
    {
        endGameUI.SetActive(true);
        if (win)
        {
            if (LevelManager.currentLevel.Equals("Level_3"))
            {
                winUI.transform.Find("NextLevelButton").gameObject.SetActive(false);
            }
            winUI.SetActive(true);
            loseUI.SetActive(false);
        }
        else
        {
            winUI.SetActive(false);
            loseUI.SetActive(true);
        }
    }
}
