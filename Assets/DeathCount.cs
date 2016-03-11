using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathCount : MonoBehaviour {

    public static int deathCount;
    static Text numberText;


	// Use this for initialization
	void Start () {
        numberText = transform.Find("number").GetComponent<Text>();
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            GetComponent<Image>().enabled = false;
            deathCount = 3;
            
        }
        UpdateText();
    }
	


    public static void UpdateText()
    {
        numberText.text = deathCount.ToString();
    } 

}
