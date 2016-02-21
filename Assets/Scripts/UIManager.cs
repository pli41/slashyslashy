using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public AudioClip hover;
    public AudioClip select;

    public Text playBtn;
    public Text creditBtn;
    public Text quitBtn;


    AudioSource aus;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Tutorial", 1);
        aus = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnMouseEnterBtn(string buttonName)
    {
        PlayAudio(hover);

        if (buttonName.Equals("Play"))
        {
            playBtn.color = Color.grey;
        }
        else if (buttonName.Equals("Credit"))
        {
            creditBtn.color = Color.grey;
        }
        else if (buttonName.Equals("Quit"))
        {
            quitBtn.color = Color.grey;
        }
        
    }

    public void OnMouseClickPlay()
    {
        PlayAudio(select);
        StartGame();
    }

    public void OnMouseClickQuit()
    {
        PlayAudio(select);
        Application.Quit();
    }

    public void OnMouseExitBtn(string buttonName)
    {

        if (buttonName.Equals("Play"))
        {
            playBtn.color = Color.black;
        }
        else if (buttonName.Equals("Credit"))
        {
            creditBtn.color = Color.black;
        }
        else if (buttonName.Equals("Quit"))
        {
            quitBtn.color = Color.black;
        }
        
    }

    public void StartGame()
    {
        LevelManager.currentLevel = "Level_1";
        SceneManager.LoadScene("Level_1");
    }

    void PlayAudio(AudioClip clip)
    {
        aus.Stop();
        aus.PlayOneShot(clip);
    }
    
    
}
